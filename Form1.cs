using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UB._1
{
    public partial class Form1 : Form
    {
        private string dataBasePath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
        public static OleDbConnection cn { get;  private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection(dataBasePath);
        }        

        private void OpenTeacherWindow(object sender, EventArgs e)
        {
            new TeacherWindow().ShowDialog();
        }


        private void OpenAuditoriumWindow(object sender, EventArgs e)
        {
            new AuditoriumWindow().ShowDialog();
        }

        private void OpenGroupWindow(object sender, EventArgs e)
        {
            new GroupWindow().ShowDialog();
        }

        private void OpenDepartmentWindow(object sender, EventArgs e)
        {
            new DepartmentWindow().ShowDialog();
        }

        private void OpenClassWindow(object sender, EventArgs e)
        {
            new ClassWindow().ShowDialog();
        }

        private void OpenSubjectWindow(object sender, EventArgs e)
        {
            new SubjectWindow().ShowDialog();
        }

        private void MSySWindow(object sender, EventArgs e)
        {
            new MSysWindow().ShowDialog();
        }
    }
}
