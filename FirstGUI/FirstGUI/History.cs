using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace FirstGUI
{
    class History
    {
        private History()
        {

        }

        //get database connection and passing back 
        private dynamic connect()
        {
            var dbCon = DBConnection.Instance();

            return dbCon;
        }

        //return usrs names
        public string[] users()
        {
            var conn = connect();
            ArrayList names = new ArrayList();
            if (conn.IsConnect())
            {
               
                 string  query = "SELECT UserName FROM Users";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string userName = reader.GetString(0);
                        names.Add(userName);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
               
            }
            else
            {
                MessageBox.Show("Connection error");
            }
            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;
        }

        //get user action
        public string[] userAction(string userID)
        {
            var conn = connect();
            ArrayList names = new ArrayList();
            if (conn.IsConnect())
            {
                //where ProductID='" + arr[0] + "';"; 
                string query = "SELECT * FROM History WHERE UserID ='" + userID +"';";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string userName = reader.GetString(0);
                        names.Add(userName);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }

            }
            else
            {
                MessageBox.Show("Connection error");
            }
            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;
        }

    }
}
