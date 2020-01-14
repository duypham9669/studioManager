using sqlite_2.common;
using sqlite_2.model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite_2.DAO
{
    class studentDAO
    {
        public bool Save(studentModel student)
        {
            var sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
            var querry = "insert into Student_2 (rollNumber, name, status) values (?,?,?)";
            using (var stt = sqlConnection.Prepare(querry))
            {
                stt.Bind(1, student.rollNumber);
                stt.Bind(2, student.name);
                stt.Bind(3, student.status);
                var result = stt.Step();
                Debug.WriteLine("result=" + result);
                return true;
            }
        }
        public List<studentModel> GetList()
        {
            List<studentModel> list = new List<studentModel>();
            var sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
            String querry = "select * from Student_2 where status=1";
            using (var result = sqlConnection.Prepare(querry))
            {
                while (SQLiteResult.ROW == result.Step())
                {
                    String rollNumber = result["rollNumber"].ToString();
                    String name = (string)result["name"];
                    String status = result["status"].ToString(); ;

                    var student = new studentModel()
                    {
                        rollNumber = Convert.ToInt32(rollNumber),
                        name = name,
                        status = Convert.ToInt32(status),
                       
                    };
                    list.Add(student);
                }
            }
            return list;
        }
        public List<studentModel> GetListDelete()
        {
            List<studentModel> list = new List<studentModel>();
            var sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
            String querry = "select * from Student_2 where status=0";
            using (var result = sqlConnection.Prepare(querry))
            {
                while (SQLiteResult.ROW == result.Step())
                {
                    String rollNumber = result["rollNumber"].ToString();
                    String name = (string)result["name"];
                    String status = result["status"].ToString(); ;

                    var student = new studentModel()
                    {
                        rollNumber = Convert.ToInt32(rollNumber),
                        name = name,
                        status = Convert.ToInt32(status),

                    };
                    list.Add(student);
                }
            }
            return list;
        }

        //public studentModel GetDetail(int id)
        //{
        //    List<studentModel> list = new List<studentModel>();
        //    var sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
        //    var querry = "select * from Student where id=" + id;
        //    using (var result = sqlConnection.Prepare(querry))
        //    {
        //        while (SQLiteResult.ROW == result.Step())
        //        {
        //            String id2 = result["id"].ToString();
        //            String name = (string)result["name"];
        //            String address = (string)result["address"];
        //            String age = (string)result["address"];
        //            var student = new student()
        //            {
        //                id = id,
        //                name = name,
        //                address = address,
        //                age = Int32.Parse(age),
        //            };
        //            list.Add(student);
        //        }
        //        return list[0];
        //    }
        //}

        public bool deleteStudent(int id)
        {
            var sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
            var querry = "UPDATE Student_2 SET status=0 WHERE rollNumber=" +id;
            using (var stt = sqlConnection.Prepare(querry))
            {
                var result = stt.Step();
                Debug.WriteLine("result=" + result);

            }
            return true;
        }

        //public bool Delete(int id)
        //{
        //    SQLiteConnection sqlConnection = SQLiteConnect.CreateInstance().SQLiteConnection;
        //    var querry = "DELETE FROM Student WHERE id =" + id;
        //    using (var stt = sqlConnection.Prepare(querry))
        //    {
        //        var result = stt.Step();
        //        Debug.WriteLine("result=" + result);
        //        return true;
        //    }
        //}
    }
}