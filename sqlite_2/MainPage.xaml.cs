using sqlite_2.model;
using sqlite_2.studentService;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sqlite_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private studentService2 service = new studentService2();
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int student_roll = Convert.ToInt32(txt_rollNumber.Text);
            String student_name = txt_name.Text;
            
                studentModel student = new studentModel()
                {
                    rollNumber = Convert.ToInt32(student_roll),
                    name = student_name,
                    status=1,
                };
                bool result = service.Save(student);
                if (result == true)
                {
                    txt_result.Text = "SUCESS";
                }
            
        }

        private void showlist(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(listAll));
        }

        private void btn_seachContact(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(delete));
        }


        //private void createConnect()
        //{
        //    SQLiteConnection connect = new SQLiteConnection("Student.db");
        //    String sql = "create table if not exists Student(id integer primary key autoincrement not null, name varchar(250) unique)";
        //    var statement = connect.Prepare(sql);
        //    statement.Step();
        //    String sqlInsert = "insert into Student()";
        //    if (statement.Step() == SQLiteResult.ROW)
        //    {
        //        String name = (String)statement[""];
        //    }
        //}

    }
}
