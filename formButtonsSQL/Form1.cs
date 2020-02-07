using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormButtons
{
    public partial class Form1 : Form
    {
        string cntStr;
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cntStr = @"Data Source=DESKTOP-QH6VFQ9\SQLEXPRESS;Initial Catalog=DB;Integrated Security=True";
            connection = new SqlConnection(cntStr);

            //using (connection = new SqlConnection(cntStr))
            //{
            //    try
            //    {
            //        connection.Open();
            //        textBox.Text = connection.State.ToString();
            //    }
            //    catch (Exception)
            //    {
            //        throw new Exception();
            //    }
            //}
        }

        private void insertBt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Empl (FirstName, LastName, Age, Wage) " +
                "VALUES ('" + textFirstName.Text + "', '" +
                textLastName.Text + "', " +
                textAge.Text + ", " +
                textWage.Text + ")"
                , connection
            );

            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                textBox.Text = "Success";

            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message;
            }
            connection.Close();

        }

        private void selectBt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Empl"
                , connection
            );

            WriteTextBox(cmd);

        }

        private void WriteTextBox(SqlCommand cmd)
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            string str = "";
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    str += reader[i] + " ";
                }
                str += Environment.NewLine;
            };
            textBox.Text = str;

            connection.Close();
        }

        private void deleteBt_Click(object sender, EventArgs e)
        {
            if (textFirstName.Text == "") return;

            SqlCommand cmd = new SqlCommand(
                "DELETE Empl WHERE FirstName = '" + textFirstName.Text + "'"
                , connection
            );

            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                textBox.Text = "Deleted";
            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message;
            }

            connection.Close();
        }

        private void sortBt_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Empl ORDER BY FirstName, LastName", connection);
            
            WriteTextBox(cmd);

        }

        private void updateBt_Click(object sender, EventArgs e)
        {
            if (textID.Text == "") return;

            string updateString = "";
            if(textFirstName.Text != "") updateString +=  "FirstName = '" + textFirstName.Text + "',";
            if(textLastName.Text != "") updateString +=  "LastName = '" + textLastName.Text + "',";
            if(textAge.Text != "") updateString +=  "Age = '" + textAge.Text + "',";
            if(textWage.Text != "") updateString +=  "Wage = '" + textWage.Text + "',";

            SqlCommand cmd = new SqlCommand();
            if (updateString != "") cmd = new SqlCommand("UPDATE Empl SET " + updateString.Substring(0, updateString.Length - 1) + " WHERE ID = " + textID.Text, connection);

            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                textBox.Text = "Updated";
            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message;
            }

            connection.Close();
        }
    }
}
