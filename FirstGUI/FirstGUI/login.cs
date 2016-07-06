using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstGUI
{
    public partial class login : Form
    {
        private Form1 mainWindow;
        
        public login()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }


        //Login button
        private void button2_Click(object sender, EventArgs e)
        {
            string uName = textBox9.Text;
            string uPassword = textBox1.Text;
            //Boolean loop = true;
            var dbCon = DBConnection.Instance();

            if (dbCon.IsConnect())
            {
                Boolean ans = false;
                Boolean connectionProblem = false;
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT UserName,Password FROM Users";
               
                try
                {
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string userName = reader.GetString(0);
                        string password = reader.GetString(1);
                        Console.WriteLine(userName + "," + password);
                        if(uName.Equals(userName) &&uPassword.Equals(password))
                        {
                            ans = true;
                        }
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                    connectionProblem = true;
                }
                if(ans)
                {
                    mainWindow = new Form1();
                    this.Hide();
                    mainWindow.Show();
                   // dbCon.Close();
                }
                else if(connectionProblem == false && ans == false)
                {
                    MessageBox.Show("Wrong username or password");
                }
               
            }
           


        }

        //Cancelbutton
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
