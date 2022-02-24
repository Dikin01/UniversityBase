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

    public partial class GroupWindow : Form
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


        public GroupWindow()
        {
            InitializeComponent();
        }
        private void GroupWindow_Load(object sender, EventArgs e)
        {
            PrintGroups();

            textBoxes = GetTextBoxes(GetControls<TextBox>(this));
            buttons = GetControls<Button>(this);

            foreach (TextBox i in textBoxes.Keys)
                i.ForeColor = Color.Gray;

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintGroups();
        }

        private void PrintGroups()
        {
            string CommandText = "SELECT * FROM Группа";
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

        private void AddGroup(string number, string faculty, uint count, uint idDepartament)
        {
            cn.Open();
            try
            {
                string cmdText = "INSERT INTO Группа VALUES (@Number, @Faculty, @Count," +
                    " @Id)";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number);
                cmd.Parameters.AddWithValue("@Faculty", faculty);
                cmd.Parameters.AddWithValue("@Count", count.ToString());
                cmd.Parameters.AddWithValue("@Id", idDepartament.ToString());
               

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

        private void UpdateGroup(string number, string faculty, uint count, uint idDepartament)
        {
            cn.Open();
            try
            {
                string cmdText = "UPDATE Группа SET [Номер группы] = @Number," +
                    "Факультет = @Faculty, [Количество студентов] = @Count, [Идентификатор кафедры] = @Id " +
                    "WHERE [Номер группы] = @Number";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number.ToString());
                cmd.Parameters.AddWithValue("@Faculty", faculty);
                cmd.Parameters.AddWithValue("@Count", count.ToString());
                cmd.Parameters.AddWithValue("@Id", idDepartament.ToString());


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


        private void DeleteGroup(string number)
        {
            cn.Open();
            try
            {
                string cmdText = "DELETE FROM Группа WHERE [Номер группы] = @Number";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Number", number.ToString());

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

        private void addGroup(object sender, EventArgs e)
        {
            uint body = Convert.ToUInt32(textBox3.Text);
            uint floor = Convert.ToUInt32(textBox4.Text);
            
            AddGroup(textBox1.Text, textBox2.Text, body, floor);
            PrintGroups();
        }

        private void deleteGroup(object sender, EventArgs e)
        {
            DeleteGroup(textBox8.Text);
            PrintGroups();
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

        private void updateGroup(object sender, EventArgs e)
        {
            uint Count = Convert.ToUInt32(textBox13.Text);
            uint Id = Convert.ToUInt32(textBox12.Text);

            UpdateGroup(textBox15.Text, textBox14.Text, Count, Id);
            PrintGroups();
        }

       
    }


}
