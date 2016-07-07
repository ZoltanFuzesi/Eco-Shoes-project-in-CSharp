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
        private static string supplierName;
        private static string customerName;
        private static string productName;
        private static string addUser;
        private static string actualUser;

        public History(string user)
        {

            actualUser = user;

        }
        //get actual user
        private static string getActualUser()
        {
            // MessageBox.Show("History Actual user " + actualUser);
            return actualUser;
        }
        //get database connection and passing back 
        private static dynamic connect()
        {
            var dbCon = DBConnection.Instance();

            return dbCon;
        }

        //return admin users names
        public static string[] users()
        {
            var conn = connect();
            ArrayList names = new ArrayList();
            if (conn.IsConnect())
            {

                string query = "SELECT UserName FROM Users";
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
        public static string[] userAction(string userID)
        {
            var conn = connect();
            ArrayList names = new ArrayList();
            if (conn.IsConnect())
            {
                //where ProductID='" + arr[0] + "';"; 
                string query = "SELECT * FROM History WHERE UserID ='" + userID + "';";
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

        //fill customer drop box
        public static string[] customerDropBox()
        {
            ArrayList names = new ArrayList();
            var conn = connect();

            if (conn.IsConnect())
            {

                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT CustomerName FROM Customer";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string customerName = reader.GetString(0);
                        names.Add(customerName);
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
                MessageBox.Show("Not connected to customer");
            }


            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;

        }

        //fill customer bougth products drop box
        public static string[] customerBougthDropBox(string customer)
        {
            ArrayList names = new ArrayList();
            var conn = connect();

            if (conn.IsConnect())
            {

                string id = getCustomerID(customer);
                Console.WriteLine(customer + " + " + id);
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT ProductDesc,Time FROM Buying WHERE CustomerID ='" + id + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string productDesc = reader.GetString(0);
                        string time = reader.GetString(1);
                        string desc = "Customer : " + customer + " , bougth product: " + productDesc + " @ " + time;
                        names.Add(desc);
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
                MessageBox.Show("Not connected to customer");
            }


            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;

        }

        //Get customer ID
        private static string getCustomerID(string name)
        {
            string id = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                string query = "SELECT CustomerID FROM Customer WHERE CustomerName ='" + name + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetString(0);

                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }
            return id;
        }



        public static string[] getAllOtherLog()
        {
            string empty = "0";
            ArrayList names = new ArrayList();
            var conn = connect();

            if (conn.IsConnect())
            {
                string query = "SELECT * FROM Log WHERE UserID =  '" + empty + "'  ORDER BY LogIn desc";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string logID = reader.GetString(0);
                        string username = reader.GetString(1);
                        string userID = reader.GetString(2);
                        string logIn = reader.GetString(3);
                        string logOut = reader.GetString(4);
                        string AccessDenied = reader.GetString(5);
                        String row = username + " : " + logIn + ", " + ", " + logOut + ", " + AccessDenied;
                        names.Add(row);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }

            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;
        }

        //Get user ID
        private static string getUserID(string name)
        {
            string id = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                string query = "SELECT UserID FROM Users WHERE UserName ='" + name + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetString(0);

                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }
            return id;
        }

        //selected user log records
        public static String[] getUserLog(string user)
        {
            string index = getUserID(user);
            ArrayList names = new ArrayList();
            var conn = connect();

            if (conn.IsConnect())
            {
                string query = "SELECT LogIn, LogOut, AccessDenied FROM Log WHERE UserID = '" + index + "' ORDER BY LogIn desc";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string LogIn = reader.GetString(0);
                        string LogOut = reader.GetString(1);
                        string AccessDenied = reader.GetString(2);
                        string row = user + ", " + LogIn + ", " + ", " + LogOut + ", " + AccessDenied;
                        names.Add(row);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }
            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;
        }
        //Selected user cations
        public static string[] getUserActions(string user)
        {

            string index = getUserID(user);
            ArrayList names = new ArrayList();
            var conn = connect();

            if (conn.IsConnect())
            {
                string query = "SELECT Action, T, Name , Date  FROM History WHERE UserID = '" + index + "' ORDER BY Date desc";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string action = reader.GetString(0);
                        string does = reader.GetString(1);
                        string with = reader.GetString(2);
                        string when = reader.GetString(3);
                        string row = user + ", " + action + ", " + does + ", " + with + "," + when;
                        names.Add(row);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }
            string[] arr = new string[names.Count];
            arr = (string[])names.ToArray(typeof(string));

            return arr;
        }


        //Insert to history all activity in program
        public static void insertHistory(string action, string with, string name)
        {
            Console.WriteLine("The actual user " + getActualUser() + "the ID " + getUserID(getActualUser()));
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // string name = "";
            string actualUserID = getUserID(getActualUser());
            Console.WriteLine("Actual user " + getActualUser() + " ID " + getUserID(getActualUser()) + " Action with " + name);
            var conn = connect();
            if (conn.IsConnect())
            {
                /* if (with.Equals("Supplier"))
                 {
                     name = getSuppliername();
                 }
                 else if (with.Equals("Customer"))
                 {
                     name = getcustomername();
                 }
                 else if (with.Equals("Product"))
                 {
                     name = getProductname();
                 }
                 else if (with.Equals("User"))
                 {
                     name = getAddUsername();
                 }*/
                try
                {                                                                                              //need format   2016 - 06 - 01 12:03:48 
                    string query = "INSERT INTO History(UserID,Action,T,Name,Date) values('" + actualUserID + "','" + action + "','" + with + "','" + name + "','" + timeStamp + "');";
                    var cmd = new MySqlCommand(query, conn.Connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        //set Supplier Name
        public static void setSupplierName(string supname)
        {
            supplierName = supname;
        }

        //get supplier name
        private static string getSuppliername()
        {
            return supplierName;
        }

        //set Customer Name
        public static void setCustomerName(string cusname)
        {
            customerName = cusname;
        }

        //get customer name
        private static string getcustomername()
        {
            return customerName;
        }

        //set Product Name
        public static void setPrductName(string proname)
        {
            productName = proname;
        }

        //get product name
        private static string getProductname()
        {
            return productName;
        }

        //set addUser Name
        public static void setAddUserName(string username)
        {
            addUser = username;
        }

        //get addUser name
        private static string getAddUsername()
        {
            return addUser;
        }

        public static void setLog(string login, string logOut,string userName)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            String accesLog = "";
            string actualUserID = "0";
            actualUser = userName;
            if (login.Equals(logOut))
            {
                actualUserID = "0";
                accesLog = "Access-Denied";
                
            }
            else
            {
                accesLog = "Access-Granted";
                actualUserID = getUserID(getActualUser());
            }
            var conn = connect();
            if (conn.IsConnect())
            {
                try
                {
                    string query = "INSERT INTO Log (UserName, UserID, LogIn, LogOut, AccessDenied) values('" + actualUser + "','" + actualUserID + "','" + login + "','" + logOut + "','" + accesLog + "');";
                    var cmd = new MySqlCommand(query, conn.Connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Log record connection problem!");
            }

        }
    }
}
