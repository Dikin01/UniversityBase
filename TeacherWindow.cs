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
    

    public partial class TeacherWindow : Form
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

            foreach(var i in controls)
            {
                pairs.Add(i, new TextBox_Customize(i, true));
            }

            return pairs;
        }

        private Dictionary<TextBox, TextBox_Customize> textBoxes = new Dictionary<TextBox, TextBox_Customize>(); //Список всех кнопок с начальными значениями
        private List<Button> buttons = new List<Button>();
        

        public TeacherWindow()
        {
            InitializeComponent();                        
        }
        private void TeacherWindow_Load(object sender, EventArgs e)
        {
            PrintTeacheres();

            textBoxes = GetTextBoxes(GetControls<TextBox>(this));
            buttons = GetControls<Button>(this);

            foreach (TextBox i in textBoxes.Keys)
                i.ForeColor = Color.Gray;

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintTeacheres();
        }

        private void PrintTeacheres()
        {
            string CommandText = "SELECT * FROM Преподаватель";
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

        private void AddNewTeacher(int number, string name, string surName, string patronymic,
         int experience, string position, int numberDepartment)
        {
            cn.Open();
            try
            {
                string cmdText = "INSERT INTO Преподаватель VALUES (@Number, @Name, @SurName, @Patronymic," +
                    " @Position, @Experience, @NumberDepartment)";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number.ToString());
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@SurName", surName);
                cmd.Parameters.AddWithValue("@Patronymic", patronymic);
                cmd.Parameters.AddWithValue("@Experience", experience.ToString());
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@NumberDepartment", numberDepartment.ToString());

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

        private void UpdateTeacher(int number, string name, string surName, string patronymic,
         int experience, string position, int numberDepartment)
        {
            cn.Open();
            try
            {
                string cmdText = "UPDATE Преподаватель SET [Табельный номер] = @Number," +
                    "[Фамилия преподавателя] = @SurName, [Имя преподавателя] = @Name, [Отчество преподавателя] = @Patronymic," +
                    "[Стаж работы] = @Experience, [Должность преподавателя] = @Position, [Идентификатор кафедры] = @NumberDepartment " +
                    "WHERE [Табельный номер] = @Number";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number.ToString());
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@SurName", surName);
                cmd.Parameters.AddWithValue("@Patronymic", patronymic);
                cmd.Parameters.AddWithValue("@Experience", experience.ToString());
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@NumberDepartment", numberDepartment.ToString());

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


        private void DeleteTeacher(int number)
        {
            cn.Open();
            try
            {
                string cmdText = "DELETE FROM Преподаватель WHERE [Табельный номер] = @Number";
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

        private void addNewTeacher(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox1.Text);
            int exp = Convert.ToInt32(textBox6.Text);
            int id = Convert.ToInt32(textBox7.Text);
            AddNewTeacher(num, textBox3.Text, textBox2.Text, textBox4.Text, exp, textBox5.Text, id);
            PrintTeacheres();
        }

        private void deleteTeacher(object sender, EventArgs e)
        {
            DeleteTeacher(Convert.ToInt32(textBox8.Text));
            PrintTeacheres();
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
            foreach(var i in textBoxes.Where(x => x.Key.Tag != null && x.Key.Tag.Equals(tag))){
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
                if(!string.IsNullOrEmpty(textBox.Text) && 
                    !textBox.Text.Equals(textBoxes[textBox].DefaultText))
                    Convert.ToInt32(textBox.Text);
            }
            catch(FormatException)
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

        private void updateTeacher(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox15.Text);
            int exp = Convert.ToInt32(textBox10.Text);
            int id = Convert.ToInt32(textBox9.Text);
            UpdateTeacher(num, textBox13.Text, textBox14.Text, textBox12.Text, exp, textBox11.Text, id);
            PrintTeacheres();
        }
    }

    
}
