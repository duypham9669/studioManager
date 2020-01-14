using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite_2.common
{
    class SQLiteConnect
    {
        private static SQLiteConnect instance;
        public SQLiteConnection SQLiteConnection { get; set; }

        private static string DatabaseName = "Student.db";

        public static SQLiteConnect CreateInstance()
        {
            if (instance == null)
            {
                instance = new SQLiteConnect();
            }
            return instance;
        }
        public SQLiteConnect()
        {
            SQLiteConnection = new SQLiteConnection(DatabaseName);
            createTable();
        }
        private void createTable()
        {
            var sql = @"Create table if not exists Student_2 (rollNumber integer primary key, name varchar(200), status integer)";
            using (var statement = SQLiteConnection.Prepare(sql))
            {
                statement.Step();
            }

        }
    }
}

