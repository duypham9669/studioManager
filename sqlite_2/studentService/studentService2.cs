using sqlite_2.DAO;
using sqlite_2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlite_2.studentService
{
    class studentService2
    {
        
            studentDAO studentdao = new studentDAO();
            public bool Save(studentModel student)
            {
                return studentdao.Save(student);
            }
            public List<studentModel> GetList()
            {
                return studentdao.GetList();
            }
            public List<studentModel> GetListDelete()
            {
                return studentdao.GetListDelete();
            }


            public bool deleteStudent(int id)
            {
                return studentdao.deleteStudent(id);
            }
        }
}
