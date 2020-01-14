using sqlite_2.model;
using sqlite_2.studentService;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace sqlite_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class listAll : Page
    {
        private studentService2 service = new studentService2();
        private List<studentModel> liststudent = new List<studentModel>();
        public listAll()
        {
            this.InitializeComponent();
            run();
        }
        private void run()
        {
            liststudent.Clear();
            liststudent = service.GetList();

            for(int i=0; i<liststudent.Count; i++)
            {
                listStudent2.Items.Add("roll number: " + liststudent[i].rollNumber + " name: " + liststudent[i].name);
            };

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btn_delete(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(delete));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            liststudent.Clear();
            
            liststudent = service.GetListDelete();

            for (int i = 0; i < liststudent.Count; i++)
            {
                listStudent2.Items.Add("roll number: " + liststudent[i].rollNumber + " name: " + liststudent[i].name);
            };
        }

        private void Button_Click_nomal(object sender, RoutedEventArgs e)
        {
            liststudent.Clear();
            liststudent = service.GetList();

            for (int i = 0; i < liststudent.Count; i++)
            {
                listStudent2.Items.Add("roll number: " + liststudent[i].rollNumber + " name: " + liststudent[i].name);
            };

        }
    }
}
