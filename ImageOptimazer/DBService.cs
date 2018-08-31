using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace ImageOptimizer
{
    internal class DBService
    {
        private readonly string _connectionString;
        private readonly string _dbFileName;

        public DBService()
        {
            _dbFileName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\opti\123.mdb";
            string dbDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\opti";
            _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _dbFileName;

            if (!File.Exists(_dbFileName))
            {
                if (!Directory.Exists(dbDirectory)) Directory.CreateDirectory(dbDirectory);
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ImageOptimazer.123.mdb"))
                using (FileStream fileStream = File.Create(_dbFileName))
                    stream.CopyTo(fileStream);


                CreateNewDB();
            }
        }

        /// <summary>
        /// save configuration settings
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetConfigurationSettings(string key, string value)
        {
            using (var con = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = con.CreateCommand())
            {
                con.Open();

                cmd.CommandText = @"update Settings set  [Value] = @value  where [key] = @key";
                cmd.Parameters.Add(new OleDbParameter("@value", value));
                cmd.Parameters.Add(new OleDbParameter("@key", key));

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// read configuration settings
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> SettingsReader()
        {
            var settings = new Dictionary<string, string>();
            const string strSQL = @"Select * from Settings";
            using (var con = new OleDbConnection(_connectionString))
            using (var command = new OleDbCommand(strSQL, con))
            {
                con.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        settings.Add(reader[0].ToString(), reader[1].ToString());
                    }
                }

                con.Close();
                return settings;
            }
        }

        /// <summary>
        /// save new image file data
        /// </summary>
        /// <param name="row"></param>
        public void SaveNewData(TableItem row)
        {
            using (var con = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText =
                    @"Insert INTO Images ([Date], SizeB, SizeA, Status, PathF, KrakenU) VALUES (@Date, @SizeB, @SizeA, @Status, @PathF, @KrakenU)";

                cmd.Parameters.Add(new OleDbParameter("@Date", row.DateTimeItem.ToString("d")));
                cmd.Parameters.Add(new OleDbParameter("@SizeB", row.SizeBefore));
                cmd.Parameters.Add(new OleDbParameter("@SizeA", row.SizeAfter));
                cmd.Parameters.Add(new OleDbParameter("@Status", row.StatusItem));
                cmd.Parameters.Add(new OleDbParameter("@PathF", row.FileName.FullName));
                cmd.Parameters.Add(new OleDbParameter("@KrakenU", row.KrakenURL));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// update context for image file
        /// </summary>
        /// <param name="item"></param>
        public void UpdateImageData(TableItem item)
        {
            using (var con = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"update  Images set SizeB = @SizeB,  SizeA = @SizeA, Status = @Status, KrakenU = @KrakenU where PathF = @PathF";

                cmd.Parameters.Add(new OleDbParameter("@SizeB", item.SizeBefore));
                cmd.Parameters.Add(new OleDbParameter("@SizeA", item.SizeAfter));
                cmd.Parameters.Add(new OleDbParameter("@Status", item.StatusItem));
                cmd.Parameters.Add(new OleDbParameter("@KrakenU", item.KrakenURL));
                cmd.Parameters.Add(new OleDbParameter("@PathF", item.FileName));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// delete info about image file
        /// </summary>
        /// <param name="path"></param>
        public void DeleteImadgeData(string path)
        {
            using (var con = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Images WHERE PathF =  @PathF";

                cmd.Parameters.Add(new OleDbParameter("@PathF", path));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// checking uniqueness for image file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsFindImadgeData(string path)
        {
            bool result = false;
            const string strSQL = @"Select PathF from Images";
            using (var con = new OleDbConnection(_connectionString))
            using (var command = new OleDbCommand(strSQL, con))
            {
                con.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == path)
                        {
                            result = true;
                            break;
                        }
                    }
                }

                con.Close();
            }
            return result;
        }

        /// <summary>
        /// load context for unworked image file from previous sessions
        /// </summary>
        /// <returns></returns>
        public List<TableItem> DataInitialization()
        {
            var rowList = new List<TableItem>();
            const string strSQL = "Select * From Images Where  Status = 1 Or Status = 3 ";
            using (var con = new OleDbConnection(_connectionString))
            using (var command = new OleDbCommand(strSQL, con))
            {
                con.Open();

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new TableItem
                            {
                                DateTimeItem = (DateTime) reader[1],
                                Id = UInt32.Parse(reader[0].ToString()),
                                SizeBefore = UInt32.Parse(reader[2].ToString()),
                                SizeAfter = UInt32.Parse(reader[3].ToString()),
                                StatusItem = (TableItem.StatusType) Int16.Parse(reader[4].ToString()),
                                FileName = new FileInfo(reader[5].ToString()),
                                KrakenURL = reader[6].ToString(),
                                ItemInProcess = false
                            };

                        rowList.Add(item);
                    }
                }

                con.Close();
            }
            return rowList;
        }

        /// <summary>
        /// create new data base
        /// </summary>
        public void CreateNewDB()
        {
            using (var con = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = con.CreateCommand())
            {
                cmd.CommandText =
                    @"Create table Images (Id AUTOINCREMENT PRIMARY KEY, [Date] DATETIME, SizeB LONG, SizeA LONG, Status SHORT, PathF LONGTEXT, KrakenU LONGTEXT)";
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"Create table Settings ([key] VARCHAR(80), [Value] VARCHAR(80))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"Insert INTO Settings ([key], [Value])  VALUES('Threads', '1' )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"Insert INTO Settings ([key], [Value])  VALUES('keyAPI', 'Type your-api-key' )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"Insert INTO Settings ([key], [Value])  VALUES('secret', 'Type your-api-secret' )";
                cmd.ExecuteNonQuery();
            }
        }
    }
}