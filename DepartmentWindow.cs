using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace UB._1
{
    public partial class DepartmentWindow : Form
    {
        OleDbConnection cn = Form1.cn;

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


        public DepartmentWindow()
        {
            InitializeComponent();
        }
        private void DepartmentWindow_Load(object sender, EventArgs e)
        {
            PrintDep();



            textBoxes = GetTextBoxes(GetControls<TextBox>(this));
            buttons = GetControls<Button>(this);

            foreach (TextBox i in textBoxes.Keys)
                i.ForeColor = Color.Gray;

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintDep();
        }

        private void PrintDep()
        {
            string CommandText = "SELECT * FROM Кафедра";
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
        private void addDep(object sender, EventArgs e)
        {


           // AddDep(Convert.ToUInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToUInt32(textBox4.Text), Convert.ToUInt32(textBox5.Text));
            PrintDep();
        }

        private void AddDep(uint id, string name, string shortName, uint count, uint idDept)
        {
            cn.Open();
            try
            {
                string cmdText = $"INSERT INTO Предмет VALUES (@id, @name, @shortName, @count, @idDept);";


                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@count", count);
                cmd.Parameters.AddWithValue("@shortName", shortName);
                cmd.Parameters.AddWithValue("@idDept", idDept);


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

        private void updateSubject(object sender, EventArgs e)
        {


            //UpdateSubject(Convert.ToUInt32(textBox11.Text), textBox12.Text, textBox13.Text, Convert.ToUInt32(textBox14.Text), Convert.ToUInt32(textBox15.Text));
            PrintDep();
        }

        private void UpdateSubject(uint id, string name, string shortName, uint count, uint idDept)
        {
            cn.Open();
            try
            {

                string cmdText = "UPDATE Предмет SET [Идентификатор предмета] = @id," +
                    "[Название предмета] = @name, [Короткое название предмета] = @shortName, [Количество студентов] = @count," +
                    "[Идентификатор кафедры] = @idDept " +
                    "WHERE [Идентификатор предмета] = @id;";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@shortName", shortName);
                cmd.Parameters.AddWithValue("@count", count);
                cmd.Parameters.AddWithValue("@idDept", idDept);



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


        private void DeleteSubject(uint id)
        {
            cn.Open();
            try
            {

                string cmdText = "DELETE FROM Предмет WHERE [Идентификатор предмета] = @id";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@id", id);


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


        private void deleteSubject(object sender, EventArgs e)
        {

            //DeleteSubject(Convert.ToUInt32(textBox21.Text));
            //PrintSubject();

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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
