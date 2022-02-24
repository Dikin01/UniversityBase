using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace UB._1
{
    public partial class MSysWindow : Form
    {
        public static string connString = "Provider = Microsoft.Jet.OLEDB.4.0;" +
        " Data Source = Database1.mdb; " +
        "Persist Security Info = False; " + "Jet OLEDB:Create System Database=true; " +
        @"Jet OLEDB:System database = C:\Users\kondi\AppData\Roaming\Microsoft\Access\System.mdw";

        OleDbConnection cn = new OleDbConnection(connString);      


        public MSysWindow()
        {
            InitializeComponent();
        }
        private void MSysWindow_Load(object sender, EventArgs e)
        {
            PrintSubject();          

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintSubject();
        }

        private void PrintSubject()
        {
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(DataGridView1_DataError);

            string CommandText = "SELECT * FROM MSysObjects";
            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(CommandText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
            
            

        }

        public void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
           anError.ThrowException = false;
        }

        private void clearTable(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
        private void add(object sender, EventArgs e)
        {


            AddTeacher();
            
        }

        private void AddTeacher()
        {
            cn.Open();
            try
            {
                string cmdText = $"EXEC [6Добавление преподавателя]";


                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SystemSounds.Exclamation.Play();
            }
            finally
            {
                cn.Close();
            }

            string CommandText = "SELECT * FROM Преподаватель";
            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(CommandText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void update(object sender, EventArgs e)
        {

            UpdateSubject();
            
        }

        private void UpdateSubject()
        {
            cn.Open();
            try
            {

                string cmdText = "EXEC [6Повысить количество студентов на предмете]";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SystemSounds.Exclamation.Play();
            }
            finally
            {
                cn.Close();
            }
        }


        private void DeleteTeachers()
        {
            cn.Open();
            try
            {

                string cmdText = "EXEC [6Сократить преподавателей]";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;



                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                SystemSounds.Exclamation.Play();
            }
            finally
            {
                cn.Close();
            }

            string CommandText = "SELECT * FROM Преподаватель";
            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(CommandText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }


        private void delete(object sender, EventArgs e)
        {

            DeleteTeachers();            

        }

              

        private void button7_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [5Поиск групп без студентов]";

            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [Вместимость всех аудиторий разных типов]";

            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [5Объединение КафедраПреподаватель]";

            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [Кафедры по ставкам] 1, 2";

            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [Кафедры по ставкам] 0, 15";

            cn.Open();            

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [Предметы кафедры] 1";

            cn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string cmdText = "EXEC [Занятия в аудитории] 1201";

            cn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();
        }
    }
}
