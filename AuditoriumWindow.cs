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


    public partial class AuditoriumWindow : Form
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


        public AuditoriumWindow()
        {
            InitializeComponent();
        }
        private void AuditoriumWindow_Load(object sender, EventArgs e)
        {
            PrintAuditoriums();

            textBoxes = GetTextBoxes(GetControls<TextBox>(this));
            buttons = GetControls<Button>(this);

            foreach (TextBox i in textBoxes.Keys)
                i.ForeColor = Color.Gray;

        }

        private void printTable(object sender, EventArgs e)
        {
            PrintAuditoriums();
        }

        private void PrintAuditoriums()
        {
            string CommandText = "SELECT * FROM Аудитория";
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

        private void AddAudit(uint number, string type, uint body, uint floor,
         uint capacity)
        {
            cn.Open();
            try
            {
                string cmdText = "INSERT INTO Аудитория VALUES (@Number, @Type, @Body, @Floor," +
                    " @Capacity)";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number.ToString());
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Body", body.ToString());
                cmd.Parameters.AddWithValue("@Floor", floor.ToString());
                cmd.Parameters.AddWithValue("@Capacity", capacity.ToString());                

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

        private void UpdateAudit(uint number, string type, uint body, uint floor,
         uint capacity)
        {
            cn.Open();
            try
            {
                string cmdText = "UPDATE Аудитория SET [Номер аудитории] = @Number," +
                    "[Тип аудитории] = @Type, Корпус = @Body, Этаж = @Floor," +
                    "Вместимость = @Capacity " +
                    "WHERE [Номер аудитории] = @Number";
                OleDbCommand cmd = new OleDbCommand(cmdText);
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Number", number.ToString());
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Body", body.ToString());
                cmd.Parameters.AddWithValue("@Floor", floor.ToString());
                cmd.Parameters.AddWithValue("@Capacity", capacity.ToString());

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


        private void DeleteAudit(uint number)
        {
            cn.Open();
            try
            {
                string cmdText = "DELETE FROM Аудитория WHERE [Номер аудитории] = @Number";
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

        private void addAudit(object sender, EventArgs e)
        {
            uint num = Convert.ToUInt32(textBox1.Text);
            uint body = Convert.ToUInt32(textBox3.Text);
            uint floor = Convert.ToUInt32(textBox4.Text);
            uint cap = Convert.ToUInt32(textBox6.Text);            
            AddAudit(num, textBox2.Text, body, floor, cap);
            PrintAuditoriums();
        }

        private void deleteAuditorium(object sender, EventArgs e)
        {
            DeleteAudit(Convert.ToUInt32(textBox8.Text));
            PrintAuditoriums();
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

        private void updateAudit(object sender, EventArgs e)
        {
            uint num = Convert.ToUInt32(textBox15.Text);
            uint body = Convert.ToUInt32(textBox13.Text);
            uint floor = Convert.ToUInt32(textBox12.Text);
            uint cap = Convert.ToUInt32(textBox10.Text);
            UpdateAudit(num, textBox14.Text, body, floor, cap);
            PrintAuditoriums();
        }
    }


}
