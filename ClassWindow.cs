using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Media;

namespace UB._1
{
    public partial class ClassWindow : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kondi\Desktop\Database1.mdb");

        public List<T> GetControls<T>(Control control) where T : Control
        {
            List<T> control_list = new List<T>();
            foreach (Control c in control.Controls)
            {
                if (c is T)
                {
                    control_list.Add(c as T);
                }
            }
            return control_list;
        } //Метод для получения списка всех элементов типа Т


        public Dictionary<TextBox, TextBox_Customize> GetTextBoxes(List<TextBox> controls)
        {
            Dictionary<TextBox, TextBox_Customize> pairs = new Dictionary<TextBox, TextBox_Customize>();

            foreach (var i in controls)
            {
                pairs.Add(i, new TextBox_Customize(i, true));
            }

            return pairs;
        }

        private Dictionary<TextBox, TextBox_Customize> textBoxes = new Dictionary<TextBox, TextBox_Customize>(); //Список всех кнопок с начальными значениями
        private List<Button> buttons = new List<Button>();


        public ClassWindow()
        {
            InitializeComponent();
        }
        private void ClassWindow_Load(object sender, EventArgs e)
        {
            PrintClasses();
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker3.Format = DateTimePickerFormat.Long;
            dateTimePicker4.Format = DateTimePickerFormat.Time;
            dateTimePicker6.Format = DateTimePickerFormat.Long;
            dateTimePicker5.Format = DateTimePickerFormat.Time;


            textBoxes = GetTextBoxes(GetControls<TextBox>(this));
            buttons = GetControls<Button>(this);

            foreach (TextBox i in textBoxes.Keys)
                i.ForeColor = Color.Gray;

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintClasses();
        }

        private void PrintClasses()
        {
            string CommandText = "SELECT * FROM Занятие";
            cn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(CommandText, cn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
            cn.Close();

        }

        private void clearTable(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
        private void addClass(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime time = dateTimePicker2.Value;

            AddClass(textBox1.Text, date, time, Convert.ToUInt32(textBox4.Text));
            PrintClasses();
        }

        private void AddClass(string type, DateTime date, DateTime time, uint numAuid)
        {
            cn.Open();
            try
            {
                string cmdText = $"INSERT INTO Занятие VALUES ('{type}', #{date.Month}/{date.Day}/{date.Year}#, #{time.Hour}:{time.Minute}#, {numAuid});";

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

        private void updateGroup(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker3.Value;
            DateTime time = dateTimePicker4.Value;

            UpdateClass(textBox15.Text, date, time, Convert.ToUInt32(textBox2.Text));
            PrintClasses();
        }

        private void UpdateClass(string type, DateTime date, DateTime time, uint number)
        {
            cn.Open();
            try
            {
                string dateS = $"#{date.Month}/{date.Day}/{date.Year}#";
                string timeS = $"#{time.Hour}:{time.Minute}#";

                string cmdText = $"UPDATE Занятие SET [Тип] = '{type}'," +
                    $"[День проведения] = {dateS}, [Время проведения] = {timeS}, [Номер аудитории] = {number} " +
                   $"WHERE ([Номер аудитории] = {number} ) AND ([День проведения] = {dateS}) AND ([Время проведения] =  {timeS});";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                /*cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@date", $"#{date.Month}/{date.Day}/{date.Year}#");
                cmd.Parameters.AddWithValue("@time", $"#{time.Hour}:{time.Minute}#");
                cmd.Parameters.AddWithValue("@number", number);*/


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


        private void DeleteClass(DateTime date, DateTime time, uint number)
        {
            cn.Open();
            try
            {
                string dateS = $"#{date.Month}/{date.Day}/{date.Year}#";
                string timeS = $"#{time.Hour}:{time.Minute}#";
                string cmdText = $"DELETE FROM Занятие WHERE ([Номер аудитории] = {number}) AND ([День проведения] = {dateS}) AND ([Время проведения] =  {timeS});";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                /*cmd.Parameters.AddWithValue("@date", $"#{date.Month}/{date.Day}/{date.Year}#");
                cmd.Parameters.AddWithValue("@time", $"#{time.Hour}:{time.Minute}#");
                cmd.Parameters.AddWithValue("@Number", number.ToString());*/

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


        private void deleteClass(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker6.Value;
            DateTime time = dateTimePicker5.Value;
            DeleteClass(date, time, Convert.ToUInt32(textBox12.Text));
            PrintClasses();

        }

        private void EnabledButtonsByTag(string tag, bool enabled)
        {
            foreach (Button i in buttons.Where(x => x.Tag != null && x.Tag.Equals(tag)))
            {
                i.Enabled = enabled;
            }
        }

        private bool isFilledTextBoxesWithTag(string tag)
        {
            bool state = true;
            foreach (var i in textBoxes.Where(x => x.Key.Tag != null && x.Key.Tag.Equals(tag)))
            {
                state = state && !i.Key.Text.Equals(i.Value.DefaultText) && !string.IsNullOrEmpty(i.Key.Text);
            }
            return state;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Equals(textBoxes[textBox].DefaultText))
                textBox.Clear();
            textBox.ForeColor = Color.Black;
        }

        private void textBox_TextChange(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            bool isFilled = isFilledTextBoxesWithTag(textBox.Tag.ToString());

            EnabledButtonsByTag(textBox.Tag.ToString(), isFilled);
        }

        private void textBox_TextChangeToInt32(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox_TextChange(sender, e);

            try
            {
                if (!string.IsNullOrEmpty(textBox.Text) &&
                    !textBox.Text.Equals(textBoxes[textBox].DefaultText))
                    Convert.ToInt32(textBox.Text);
            }
            catch (FormatException)
            {
                SystemSounds.Exclamation.Play();
                textBox.Text = null;
            }

        }

        private void textBox_TextChangeToUInt32(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox_TextChange(sender, e);

            try
            {
                if (!String.IsNullOrEmpty(textBox.Text) &&
                     !textBox.Text.Equals(textBoxes[textBox].DefaultText))
                    Convert.ToUInt32(textBox.Text);
            }
            catch (FormatException)
            {
                SystemSounds.Exclamation.Play();
                textBox.Text = null;
            }


        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBoxes[textBox].DefaultText;
                textBox.ForeColor = textBoxes[textBox].DefaultColor;
            }
        }

    }
}
