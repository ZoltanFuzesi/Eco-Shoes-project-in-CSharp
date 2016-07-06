using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace FirstGUI
{
    public partial class Form1 : Form
    {
        private Form2 secondForm;// 
        private string[] product;
        private string[] names;
        private string[] id;
        private int stateControll = 0;
        private string imagePathToUpload = "";
        private string imageNameToSave = "";

        public Form1()
        {
            InitializeComponent();
            setAllComponentsUnvisible();
            loadDefaultPicture();
            // this.FormClosing += OnFormClosing;
        }

        //Statecontroll 
        private void setStatecontroll(int i)
        {
            stateControll = i;
        }
        //Statecontroll 
        private int getStatecontroll()
        {
            return stateControll;
        }



        //Close application
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to close application", "Exit application", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.Exit();
                }
            }
        }

        //Exit button
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setAllComponentsUnvisible()
        {
            label18.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label12.Visible = false;
            label11.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            textBox9.Visible = false;
            textBox8.Visible = false;
            textBox7.Visible = false;
            textBox6.Visible = false;
            textBox5.Visible = false;
            textBox4.Visible = false;
            textBox3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            button2.Visible = false;
            button15.Visible = false;
            button16.Visible = false;


        }

        private void searchTextBoxesVisibleAndUnEditable()
        {
            textBox9.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;
            textBox6.Visible = true;
            textBox5.Visible = true;
            textBox4.Visible = true;
            textBox3.Visible = true;
            textBox2.Visible = true;
            textBox1.Visible = true;
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox1.ReadOnly = true;
            loadDefaultPicture();
        }

        private void searchTextBoxesVisibleAndEditable()
        {
            textBox9.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;
            textBox6.Visible = true;
            textBox5.Visible = true;
            textBox4.Visible = true;
            textBox3.Visible = true;
            textBox2.Visible = true;
            textBox1.Visible = true;

            textBox9.ReadOnly = true;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox1.ReadOnly = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        //designe for Search option components visibility
        private void searchVisibility()
        {
            label16.Visible = true;
            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label12.Visible = true;
            label11.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            

            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;

            button2.Visible = true;
        }

        //designe for change option components visibility
        private void changeVisibility()
        {
            button2.Text = "Save Changes";
            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox1.ReadOnly = false;

            
            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label12.Visible = true;
            label11.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = false;
            comboBox1.Visible = false;

            //show products drop down
            if (getStatecontroll() == 3)
                comboBox1.Visible = true;
            //hide serch label and drop boxes
            label16.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            button2.Visible = true;
        }
        //Search supplier button
        private void button12_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(1);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Search Supplier";
            label14.Text = "SupplierID";
            label13.Text = "Supplier Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";
            label5.Text = "Products";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();

            button2.Text = "Change Supplier Details";

            supplierDropBox();
        }

     

        //get details for supplier drop box
        private void supplierDropBox()
        {
            var conn = connect();

            if (conn.IsConnect())
            {
                //MessageBox.Show("Connected to supplier");
                ArrayList names = new ArrayList();
                ArrayList ids = new ArrayList();
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT SupplierName,SupplierID FROM Supplier";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string supplierName = reader.GetString(0);
                        string supplierID = reader.GetString(1);
                        Console.WriteLine(supplierID + "," + supplierName);
                        ids.Add(supplierID);
                        names.Add(supplierName);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                setNameArray(names);
                setIDArray(ids);
            }
            else
            {
                MessageBox.Show("Not connected to supplier");
            }
        }


        //Set name array
        private void setNameArray(ArrayList al)
        {
            names = (string[])al.ToArray(typeof(string));
            /*     foreach(string value in names)
                 {
                     Console.WriteLine(value);
                 }*/
            fillNameComboBox();
        }

        //Get name array
        private string[] getNameArray()
        {
            return names;
        }

        //fill name combobox
        private void fillNameComboBox()
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.Clear();
            comboBox3.BeginUpdate(); // <- Stop painting
            string[] temp = getNameArray();
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox3.Items.Add(item);
                }
            }
            finally
            {
                comboBox3.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //fill ID combobox
        private void fillIDComboBox()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.BeginUpdate(); // <- Stop painting
            string[] tempT = getIdArray();
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in tempT)
                {
                    // Console.WriteLine("Build dropbox " + item);
                    comboBox2.Items.Add(item);
                }
            }
            finally
            {
                comboBox2.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //Set ID array
        private void setIDArray(ArrayList alid)
        {

            id = (string[])alid.ToArray(typeof(string));
            fillIDComboBox();
        }

        //Get id array
        private string[] getIdArray()
        {
            return id;
        }


        //Ad Supplier button
        private void button13_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(1);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Add Supplier";
            label14.Text = "SupplierID";
            label13.Text = "Supplier Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";

            searchTextBoxesVisibleAndEditable();

            searchVisibility();
            label16.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            button2.Text = "Add Supplier";
            nextID();
        }

        //get next auto_increment id
        private void nextID()
        {
            string table = "";
            if(getStatecontroll() == 1)
            {
                table = "Supplier";
            }
            else if (getStatecontroll() == 2)
            {
                table = "Customer";
            }
            else if (getStatecontroll() == 3 || getStatecontroll() == 4)
            {
                table = "Product";
            }
            textBox9.ReadOnly = true;
            string nextID = "";
            var conn = connect();
            string auto = "SHOW TABLE STATUS LIKE '" + table + "'";
            var aut = new MySqlCommand(auto, conn.Connection);
            try
            {

                var reader = aut.ExecuteReader();
                while (reader.Read())
                {
                    nextID = reader.GetString("Auto_increment");
                }
                reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection problem with " + table +   " auto increment ID!!");
            }

            textBox9.Text = nextID;
        }

        //Delete Supplier button
        private void button10_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(1);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Delete Supplier";
            label14.Text = "SupplierID";
            label13.Text = "Supplier Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";
            // label5.Text = "Products";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();
            label5.Visible = false;
            comboBox1.Visible = false;

            button2.Text = "Delete Supplier";

            supplierDropBox();
        }

        //History button
        private void button11_Click(object sender, EventArgs e)
        {
            secondForm = new Form2();
            secondForm.Show();

        }




        //Search Customer button
        private void button6_Click(object sender, EventArgs e)
        {
            clearTextDetails();
            setStatecontroll(2);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Search Customer";
            label14.Text = "CustomerID";
            label13.Text = "Customer Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";
            label5.Text = "Bougth Products";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();

            button2.Text = "Change Customer Details";

            customerDropBox();

        }

        //get details for customer drop boxes
        private void customerDropBox()
        {
            var conn = connect();

            if (conn.IsConnect())
            {
                //MessageBox.Show("Connected to supplier");
                ArrayList names = new ArrayList();
                ArrayList ids = new ArrayList();
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT CustomerName,CustomerID FROM Customer";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string customerName = reader.GetString(0);
                        string customerID = reader.GetString(1);
                        Console.WriteLine(customerID + "," + customerName);
                        ids.Add(customerID);
                        names.Add(customerName);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                setNameArray(names);
                setIDArray(ids);
            }
            else
            {
                MessageBox.Show("Not connected to customer");
            }
        }

        //get database connection and passing back 
        private dynamic connect()
        {
            var dbCon = DBConnection.Instance();

            return dbCon;
        }

        //Add Customer button
        private void button14_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(2);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Add Customer";
            label14.Text = "CustomerID";
            label13.Text = "Customer Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";
            label5.Text = "Bougth Products";

            searchTextBoxesVisibleAndEditable();

            searchVisibility();
            label16.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

            button2.Text = "Add Customer";
            nextID();
        }

        //Delete customer button
        private void button5_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(2);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Delete Customer";
            label14.Text = "CustomerID";
            label13.Text = "Customer Name";
            label12.Text = "Street";
            label11.Text = "Town";
            label10.Text = "County";
            label9.Text = "Country";
            label8.Text = "Post Code";
            label7.Text = "Email";
            label6.Text = "Contact";
            label5.Text = "Bougth Products";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();
            label5.Visible = false;
            comboBox1.Visible = false;

            button2.Text = "Delete Customer";

            customerDropBox();
        }
        //Search product button
        private void button8_Click(object sender, EventArgs e)
        {
            clearTextDetails();
            setStatecontroll(3);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Search Product";
            label14.Text = "ProductID";
            label13.Text = "Product Name";
            label12.Text = "Supplier";
            label11.Text = "Type";
            label10.Text = "Size";
            label9.Text = "Price";
            label8.Text = "Colour";
            label7.Text = "Contact";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();
            textBox1.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            button2.Text = "Change Product Details";

            productDropBox();
        }

        //get details for procudt drop boxes
        private void productDropBox()
        {
            var conn = connect();

            if (conn.IsConnect())
            {
                //MessageBox.Show("Connected to supplier");
                ArrayList names = new ArrayList();
                ArrayList ids = new ArrayList();
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT ProductDesc,ProductID FROM Product";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string ProductName = reader.GetString(0);
                        string ProductID = reader.GetString(1);
                        Console.WriteLine(ProductID + "," + ProductName);
                        ids.Add(ProductID);
                        names.Add(ProductName);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                setNameArray(names);
                setIDArray(ids);
            }
            else
            {
                MessageBox.Show("Not connected to customer");
            }
        }
        //Add Product button
        private void button4_Click(object sender, EventArgs e)
        {
           // fillNameComboBox();
           // fillIDComboBox();
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(4);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Add Product";
            label14.Text = "ProductID";
            label13.Text = "Product Name";
            label12.Text = "Supplier";
            label11.Text = "Type";
            label10.Text = "Size";
            label9.Text = "Price";
            label8.Text = "Colour";
            label7.Text = "Contact";
            
            searchTextBoxesVisibleAndEditable();

            searchVisibility();
            label18.Text = "Select image";
            //label18.Visible = true;
            label16.Visible = true;
            textBox1.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            button15.Visible = true;
            button2.Text = "Add Product";
            textBox7.ReadOnly = true;
            nextID();
            supplierDropBox();
        }

     

        //Delete Product button
        private void button3_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            clearTextDetails();
            setStatecontroll(3);
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Delete Product";
            label14.Text = "ProductID";
            label13.Text = "Product Name";
            label12.Text = "Supplier";
            label11.Text = "Type";
            label10.Text = "Size";
            label9.Text = "Price";
            label8.Text = "Colour";
            label7.Text = "Contact";

            searchTextBoxesVisibleAndUnEditable();

            searchVisibility();
            textBox1.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            comboBox1.Visible = false;
            button2.Text = "Delete Product";

            productDropBox();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        //save changes customer check for empty fields
        private void amendcustomer()
        {
            string[] arr = getTextDetails();
            //Console.WriteLine(checkFields(getTextDetails()));
            if (IsValidEmail(arr[7]) && ckeckNumber(arr[8]))
            {
                if (checkFields(getTextDetails()))
                {
                    Console.WriteLine("Execute sql querry");

                    //Update supplier details in database
                    var conn = connect();
                    if (conn.IsConnect())
                    {
                        //string query = "SELECT SupplierID FROM Supplier WHERE SupplierName ='" + name + "' ";
                        string query = "UPDATE Customer set Street='" + arr[2] + "',Town='" + arr[3] + "',County='" + arr[4] + "',Country='" + arr[5] + "',PostCode='" + arr[6] + "',Email='" + arr[7] + "',ContactNumber='" + arr[8] + "' where CustomerID='" + arr[0] + "';";
                        var cmd = new MySqlCommand(query, conn.Connection);
                        try
                        {
                            var reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Can't update Supplier!!");
                        }
                    }

                    setAllComponentsUnvisible();
                    label15.Text = "Supplier " + arr[1] + " has updated";
                    label15.Visible = true;

                }
            }
        

        }
        //save changes supplier check for empty fields
        private void amendSupplier()
        {
             string[] arr = getTextDetails();
            //Console.WriteLine(checkFields(getTextDetails()));
            if (IsValidEmail(arr[7]) && ckeckNumber(arr[8]))
            { 
                if (checkFields(getTextDetails()))
                {
                    Console.WriteLine("Execute sql querry");

                    //Update supplier details in database
                    var conn = connect();
                    if (conn.IsConnect())
                    {
                        //string query = "SELECT SupplierID FROM Supplier WHERE SupplierName ='" + name + "' ";
                        string query = "UPDATE Supplier set Street='" + arr[2] + "',Town='" + arr[3] + "',County='" + arr[4]+ "',Country='" + arr[5]+ "',PostCode='" + arr[6] + "',Email='" + arr[7] + "',ContactNumber='" + arr[8] + "' where SupplierID='" + arr[0] + "';";
                        var cmd = new MySqlCommand(query, conn.Connection);
                        try
                        {
                            var reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Can't update Supplier!!");
                        }
                    }

                    setAllComponentsUnvisible();
                    label15.Text = "Supplier " + arr[1] + " has updated";
                    label15.Visible = true;

                }
            }
        /*    else
            {
                if (IsValidEmail(arr[7])==false)
                    errorMessageBox("The Email address not valid");
                if(ckeckNumber(arr[8])==false)
                    errorMessageBox("The contact number not valid");
            }*/
            
        }
        //Check number input
        private Boolean ckeckNumber(String str)
        {
            Boolean ch = true;
            try
            {
                long l1 = Convert.ToInt64(str);
            }
            catch (Exception)
            {
                
                ch = false;
            }
            //use for supplier and customer only
            if(ch == false && getStatecontroll()<3)
                errorMessageBox("The contact number not valid");

            return ch;
        }


        //Email validation 
        private bool IsValidEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if(!isEmail)
                    errorMessageBox("The Email address not valid");

            return isEmail;
        }

        //helper method for checking empty fileds
        private Boolean checkState()
        {
            //if Product true ELSE false
            if (getStatecontroll() == 3|| getStatecontroll() == 4)
                return true;
            else
                return false;
        }
        //Check fields for empty value Return TRUE if no empty value
        private Boolean checkFields(string[]arr)
        {
            string message = "";
            Boolean ans = true;
            
            for (int i = 0; i < arr.Length; i++)
            {               
                if (String.IsNullOrEmpty(arr[i].Trim()))
                {
                    
                    //check don't use switch for product hidden textbox1
                    if (getStatecontroll() == 3 || getStatecontroll() == 4 && i == 8)
                    {
                        //do nothing 
                    }
                    else
                    {
                        ans = false;
                        switch (i)
                        {
                            case 0: message = checkState()? "ID filed empty"       : "ID filed empty"; errorMessageBox(message); break;
                            case 1: message = checkState() ? "Name filed empty"     : "Name filed empty"; errorMessageBox(message); break;
                            case 2: message = checkState() ? "Supplier filed empty" : "Street filed empty"; errorMessageBox(message); break;
                            case 3: message = checkState() ? "Type filed empty"     : "Town filed empty"; errorMessageBox(message); break;
                            case 4: message = checkState() ? "Size filed empty"     : "County filed empty"; errorMessageBox(message); break;
                            case 5: message = checkState() ? "Price filed empty"    : "country filed empty"; errorMessageBox(message); break;
                            case 6: message = checkState() ? "Colour filed empty"   : "Post Code filed empty"; errorMessageBox(message); break;
                            case 7: message = checkState() ? "Contact filed empty"  : "Email filed empty"; errorMessageBox(message); break;
                            case 8: message = checkState() ? "No imput required"    : "Contact filed empty"; errorMessageBox(message); break;
                            default: break;
                        }
                    }
                }
            }
            return ans;
        }

        //Message box
        private void errorMessageBox(string str)
        {
            MessageBox.Show(str);
        }

        //Action button
        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox9.Text;
            string buttonValue = (sender as Button).Text;
            amendDatabase(id, buttonValue);
        }

        private void amendDatabase(string id, string buttonValue)
        {
            string strID = textBox9.Text;
            var conn = connect();
            if (conn.IsConnect())
            {
                if (stateControll == 1)//Supplier
                {
                    if (buttonValue.Equals("Change Supplier Details"))
                    {
                        Console.WriteLine(buttonValue + " & " + id);
                        if(strID.Equals(" "))
                            MessageBox.Show("Please select a supplier!");
                        else
                            changeVisibility();

                    }
                    else if (buttonValue.Equals("Add Supplier"))
                    {

                        string newSupplier = textBox8.Text;
                        Console.WriteLine(buttonValue + " & " + id);
                        if (checkFields(getTextDetails()))
                        {
                            if (IsValidEmail(this.textBox2.Text) && ckeckNumber(this.textBox1.Text))
                            {
                                try
                                {

                                    string query = "INSERT INTO Supplier(SupplierName,Street,Town,County,Country,PostCode,Email,ContactNumber) values('" + this.textBox8.Text + "','" + this.textBox7.Text + "','" + this.textBox6.Text + "','" + this.textBox5.Text + "','" + this.textBox4.Text + "','" + this.textBox3.Text + "','" + this.textBox2.Text + "','" + this.textBox1.Text + "');";

                                    var cmd = new MySqlCommand(query, conn.Connection);
                                    cmd.ExecuteNonQuery();
                                    setAllComponentsUnvisible();
                                   // clearTextDetails();
                                    label15.Text = "The Supplier " + newSupplier + " added to database! ";
                                    label15.Visible = true;
                                    supplierDropBox();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }

                    }
                    else if (buttonValue.Equals("Delete Supplier"))
                    {
                        Console.WriteLine(buttonValue + " & " + id);

                        string query = "DELETE FROM Supplier WHERE SupplierID ='" + id + "' ";
                        var cmd = new MySqlCommand(query, conn.Connection);
                        string Sname = textBox8.Text;
                        DialogResult dialogResult = MessageBox.Show("Delete Supplier " + Sname + " ?", "Exit application", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {

                        }
                        else if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Connection problem!!");
                            }
                            clearTextDetails();
                            setAllComponentsUnvisible();
                            label15.Text = "The Supplier " + Sname + " was deleted ! ";
                            label15.Visible = true;
                            supplierDropBox();
                        }
                    }
                    else if (buttonValue.Equals("Save Changes"))
                    {
                        Console.WriteLine("Save Changes method");
                        amendSupplier();
                    }
                }
                else if (stateControll == 2)//Customer
                {
                    if (buttonValue.Equals("Change Customer Details"))
                    {
                        Console.WriteLine(buttonValue);
                        if (strID.Equals(" "))
                            MessageBox.Show("Please select a customer!");
                        else
                            changeVisibility();
                    }
                    else if (buttonValue.Equals("Add Customer"))
                    {
                        string newCustomer = textBox8.Text;
                        Console.WriteLine(buttonValue + " & " + id);
                        if (checkFields(getTextDetails()))
                        {
                            if (IsValidEmail(this.textBox2.Text) && ckeckNumber(this.textBox1.Text))
                            {
                                try
                                {

                                    string query = "INSERT INTO Customer(CustomerName,Street,Town,County,Country,PostCode,Email,ContactNumber) values('" + this.textBox8.Text + "','" + this.textBox7.Text + "','" + this.textBox6.Text + "','" + this.textBox5.Text + "','" + this.textBox4.Text + "','" + this.textBox3.Text + "','" + this.textBox2.Text + "','" + this.textBox1.Text + "');";

                                    var cmd = new MySqlCommand(query, conn.Connection);
                                    cmd.ExecuteNonQuery();
                                    setAllComponentsUnvisible();
                                    clearTextDetails();
                                    label15.Text = "The Customer " + newCustomer + " added to database! ";
                                    label15.Visible = true;
                                    customerDropBox();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                    else if (buttonValue.Equals("Delete Customer"))
                    {
                        Console.WriteLine(buttonValue + " & " + id);

                        string query = "DELETE FROM Customer WHERE CustomerID ='" + id + "' ";
                        var cmd = new MySqlCommand(query, conn.Connection);
                        string Sname = textBox8.Text;
                        DialogResult dialogResult = MessageBox.Show("Delete Customer " + Sname + " ?", "Exit application", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {

                        }
                        else if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Connection problem!!");
                            }
                            clearTextDetails();
                            setAllComponentsUnvisible();
                            label15.Text = "The Customer " + Sname + " was deleted ! ";
                            label15.Visible = true;
                            customerDropBox();
                        }
                    }
                    else if (buttonValue.Equals("Save Changes"))
                    {
                        Console.WriteLine("Save Changes method");
                        amendcustomer();
                    }
                    
                }
            
            else if (stateControll == 3)//Product
            {
                if (buttonValue.Equals("Change Product Details"))
                {
                    Console.WriteLine(buttonValue);
                }
                else if (buttonValue.Equals("Delete Product"))
                {
                        string imagePath = getImagePathToDelete(id);
                        string query = "DELETE FROM Product WHERE ProductID ='" + id + "' ";
                        var cmd = new MySqlCommand(query, conn.Connection);
                        string Sname = textBox8.Text;
                        DialogResult dialogResult = MessageBox.Show("Delete Product " + Sname + " ?", "Exit application", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {

                        }
                        else if (dialogResult == DialogResult.Yes)
                        {
                            deleteImageFromServer(imagePath);
                            try
                            {
                                cmd.ExecuteNonQuery();
                                
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Connection problem!!");
                            }
                            clearTextDetails();
                            setAllComponentsUnvisible();
                            loadDefaultPicture();
                            label15.Text = "The Customer " + Sname + " was deleted ! ";
                            label15.Visible = true;
                            customerDropBox();
                        }
                      
                    Console.WriteLine(buttonValue + " " + id);
                }
            }
            else if (stateControll == 4)//Add Product special condition
            {
                    if (buttonValue.Equals("Add Product"))
                    {
                       // Console.WriteLine(buttonValue);
                        string supID = getSupplierID(this.textBox7.Text);
                        string newProduct = textBox8.Text;
                        Console.WriteLine(buttonValue + " & " + id);
                        if (checkFields(getTextDetails()))
                        {
                            Console.WriteLine("Over check field");
                            if (!String.IsNullOrEmpty(getImagePath())&& ckeckNumber(this.textBox2.Text) && ckeckNumber(this.textBox4.Text) && ckeckNumber(this.textBox5.Text))
                            {
                                setImageName(this.textBox8.Text + ".jpg");
                                string imgLocation = "picture_library/" + getImageName();
                                Console.WriteLine("Over check number fields");
                                try
                                {

                                    string query = "INSERT INTO Product(ProductDesc,SupplierID,Gender,Size,Price,Colour,StockLevel,ImgLocation) values('" + this.textBox8.Text + "','" + supID + "','" + this.textBox6.Text + "','" + this.textBox5.Text + "','" + this.textBox4.Text + "','" + this.textBox3.Text + "','" + this.textBox2.Text + "','" + imgLocation +"');";

                                    var cmd = new MySqlCommand(query, conn.Connection);
                                    cmd.ExecuteNonQuery();
                                    UpLoadFile(getImagePath());
                                    setAllComponentsUnvisible();
                                    clearTextDetails();
                                    label15.Text = "The Product " + newProduct + " added to database! ";
                                    setImagePath("");
                                    label15.Visible = true;
                                    customerDropBox();
                                    loadDefaultPicture();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(getImagePath()))
                                    errorMessageBox("Please select image");
                                if (!ckeckNumber(this.textBox2.Text))
                                    errorMessageBox("Invalid Contact information");
                                if (!ckeckNumber(this.textBox4.Text))
                                    errorMessageBox("Invalid Price information");
                                if (!ckeckNumber(this.textBox5.Text))
                                    errorMessageBox("Invalid Size information");
                            }
                        }
                        else
                        {
                            errorMessageBox("Something went wrong Add Product");
                        }
                        Console.WriteLine(buttonValue);
                    }
                }
        }
        else//connection
        {
             MessageBox.Show("Not connected to supplier");
        }
    }
        //Delete image from server
        private void deleteImageFromServer(string path)
        {
            try
            {
                FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create("???" + path);
                requestFileDelete.Credentials = new NetworkCredential("???", "???");
                requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();

            
            }
            catch (Exception) { errorMessageBox("File deleting problem"); }
        }

        //Get image file path to delete
        private string getImagePathToDelete(string id)
        {
            string pathDelete = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                string query = "SELECT ImgLocation FROM Product WHERE ProductID ='" + id + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pathDelete = reader.GetString(0);

                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
            }
            return pathDelete;
        }






        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Delete User button
        private void button7_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            setAllComponentsUnvisible();
            label16.Text = "Search by Id,Name";
            label15.Text = "Delete User";
            label14.Text = "User Name";
            label13.Text = "Password";

            label16.Visible = true; label16.Text = "Search by Id,Name";
            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;

            textBox9.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.Visible = true;
            textBox8.Visible = true;

            comboBox2.Visible = true;
            comboBox3.Visible = true;

            button2.Text = "Delete User";
            button2.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            setAllComponentsUnvisible();
        }

        //Add user button
        private void button9_Click(object sender, EventArgs e)
        {
            loadDefaultPicture();
            setAllComponentsUnvisible();
            label15.Text = "Add User";
            label14.Text = "User Name";
            label13.Text = "Create Password";
            label12.Text = "Repeat Password";
            label11.Text = "Email";

            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label12.Visible = true;
            label11.Visible = true;

            textBox9.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox9.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;
            textBox6.Visible = true;

            button2.Text = "Create User";
            button2.Visible = true;
            button16.Visible = true;
        }

      

      

     
       

      

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        //File chooser to upload picture to server
        private void button15_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                 path = file.FileName;
            }

            //copy file to server

          //  PictureBox1.SizeMode = SizeMode.Stretch
            pictureBox1.ImageLocation = path;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label18.Text = path;
            label18.Visible = true;
            Console.WriteLine("{0}",path);
            setImagePath(path);
        }
        //Set the image path to upload
        private void setImagePath(string path)
        {
          //  errorMessageBox(path);
          //  errorMessageBox(Path.GetFileName(path));
           
            imagePathToUpload = path;
        }

        //Set the image name to Product name
        private void setImageName(string name)
        {
            imageNameToSave = name;
        }

        //Get image name for upload
        private string getImageName()
        {
            return imageNameToSave;
        }
        //Get the image path to upload
        private string getImagePath()
        {
            return imagePathToUpload;
        }
        private void loadDefaultPicture()
        {
            pictureBox1.Image = Properties.Resources.Default;
        }

   
        //Change user password
        private void button16_Click(object sender, EventArgs e)
        {
            setAllComponentsUnvisible();
            label15.Text = "Change Password";
            label14.Text = "User Name";
            label13.Text = "New Password";
            label12.Text = "Repeat Password";

            label15.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label12.Visible = true;

            textBox9.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox9.Visible = true;
            textBox8.Visible = true;
            textBox7.Visible = true;

            button2.Text = "change";
            button2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Fill text from droopdown
        private void fillTextDetails(string[]al)
        {
            
            textBox9.Text = al[0];
            textBox8.Text = al[1];
            textBox7.Text = al[2];
            textBox6.Text = al[3];
            textBox5.Text = al[4];
            textBox4.Text = al[5];
            textBox3.Text = al[6];
            textBox2.Text = al[7];
            textBox1.Text = al[8];
        }

        //Clear all text boxes
        private void clearTextDetails()
        {
            textBox9.Text = " ";
            textBox8.Text = " ";
            textBox7.Text = " ";
            textBox6.Text = " ";
            textBox5.Text = " ";
            textBox4.Text = " ";
            textBox3.Text = " ";
            textBox2.Text = " ";
            textBox1.Text = " ";
        }

        //get all text box values
        private string[] getTextDetails()
        {
            string[] arr = new string[9];
            arr[0] = textBox9.Text;
            arr[1] = textBox8.Text;
            arr[2] = textBox7.Text;
            arr[3] = textBox6.Text;
            arr[4] = textBox5.Text;
            arr[5] = textBox4.Text;
            arr[6] = textBox3.Text;
            arr[7] = textBox2.Text;
            arr[8] = textBox1.Text;

            return arr;
        }
        //Use ID
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            //MessageBox.Show(selected);
            if(getStatecontroll() == 1)
            {
                fillSupplierDetails(selected, "id");
            }
            else if(getStatecontroll() == 2 )
            {
                fillcustomerDetails(selected, "id");
            }
            else if(getStatecontroll() == 3)
            {
                fillProductDetails(selected, "id");
            }
            else if(getStatecontroll() == 4 )
            {
                fillSupplierName(selected, "id");
            }
        }

        //fill supplier name for adding product
        private void fillSupplierName(string selected,string value)
        {
            if (value.Equals("id"))
                textBox7.Text = getSuppplierName(selected);
            else if (value.Equals("name"))
                textBox7.Text = selected;
        }
        //Use Name
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            // MessageBox.Show(selected);
            if (getStatecontroll() == 1)
            {
                fillSupplierDetails(selected, "name");
            }
            else if (getStatecontroll() == 2)
            {
                fillcustomerDetails(selected, "name");
            }
            else if (getStatecontroll() == 3)
            {
                fillProductDetails(selected, "name");
            }
            else if (getStatecontroll() == 4)
            {
                fillSupplierName(selected, "name");
            }
        }

        //Fill the selected Supplier details 
        private void fillSupplierDetails(string str, string value)
        {
            fillProductDropdown(str,value);
            var conn = connect();
            string[] list = new string[9];
            if (conn.IsConnect())
            {
                string query = "";
                if (value.Equals("name"))
                    query = "SELECT * FROM Supplier WHERE SupplierName ='" + str +"' ";
                else if(value.Equals("id"))
                    query = "SELECT * FROM Supplier WHERE SupplierID ='" + str + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string supplierID = reader.GetString(0);
                        string supplierName = reader.GetString(1);
                        string street = reader.GetString(2);
                        string town = reader.GetString(3);
                        string county = reader.GetString(4);
                        string country = reader.GetString(5);
                        string postcode = reader.GetString(6);
                        string email = reader.GetString(7);
                        string contact = reader.GetString(8);
                        // Console.WriteLine(supplierID + "," + supplierName);
                        list[0] = supplierID;
                        list[1] = supplierName;
                        list[2] = street;
                        list[3] = town;
                        list[4] = county;
                        list[5] = country;
                        list[6] = postcode;
                        list[7] = email;
                        list[8] = contact;
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                fillTextDetails(list);
            }
            else
            {
                MessageBox.Show("Not connected to supplier");
            }
        }

        //Get supplier name
        private string getSuppplierName(string name)
        {
            string id = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                string query = "SELECT SupplierName FROM Supplier WHERE SupplierID ='" + name + "' ";
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

        //Get supplier ID
        private string getSupplierID(string name)
        {
            string id = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                string query = "SELECT SupplierID FROM Supplier WHERE SupplierName ='" + name + "' ";
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

        //Fill products to supplier dropdown
        private void fillProductDropdown(string str,string value)
        {
           // string id = "";
            string query = "";
            var conn = connect();
            if (conn.IsConnect())
            {
                ArrayList names = new ArrayList();
                if (value.Equals("name"))
                    str = getSupplierID(str);


                    query = "SELECT ProductDesc FROM Product WHERE SupplierID ='" + str + "' ";


                var cmd = new MySqlCommand(query, conn.Connection);
            try
            {
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string supplierID = reader.GetString(0);
                    names.Add(supplierID);
                }
                reader.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Connection problem!!");
            }
            fillProductsDrop(names);
        }
            else
            {
                MessageBox.Show("Not connected to product");
            }
}

        //fill products connected to supplier dropbox
        //Set name array
        private void fillProductsDrop(ArrayList al)
        {
            product = (string[])al.ToArray(typeof(string));
            /*     foreach(string value in names)
                 {
                     Console.WriteLine(value);
                 }*/
            fillProductComboBox();
        }

        private string[] getProductArray()
        {
            return product;
        }

        //fill product combobox
        private void fillProductComboBox()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.BeginUpdate(); // <- Stop painting
            string[] temp = getProductArray();
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox1.Items.Add(item);
                }
            }
            finally
            {
                comboBox1.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //fill customer connected dropdown box
        private void fillCustomerBougthProducts(ArrayList al)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.BeginUpdate(); // <- Stop painting
            string[] temp = (string[])al.ToArray(typeof(string));
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox1.Items.Add(item);
                }
            }
            finally
            {
                comboBox1.EndUpdate(); // <- Finally, repaint if required
            }

        }

        //Get customer ID
        private string getCustomerID(string name)
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
        //get customer connected bougth products 
        private void fillBougthProducts(string str,string value)
        {
            var conn = connect();
            ArrayList al = new ArrayList();
            
                if(value.Equals("name"))
                    str = getCustomerID(str);
            if (conn.IsConnect())
            {
                
           
                   string query = "SELECT ProductDesc FROM Buying WHERE CustomerID ='" + str + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string productDesc = reader.GetString(0);

                        // Console.WriteLine(supplierID + "," + supplierName);
                        al.Add(productDesc);
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                fillCustomerBougthProducts(al);
            }
            else
            {
                MessageBox.Show("Not connected to supplier");
            }
        }

        //Fill the selected Customer details 
        private void fillcustomerDetails(string str, string value)
        {
            fillBougthProducts(str, value);
            var conn = connect();
            string[] list = new string[9];
            if (conn.IsConnect())
            {
                string query = "";
                if (value.Equals("name"))
                    query = "SELECT * FROM Customer WHERE CustomerName ='" + str + "' ";
                else if (value.Equals("id"))
                    query = "SELECT * FROM Customer WHERE CustomerID ='" + str + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string customerID = reader.GetString(0);
                        string customerName = reader.GetString(1);
                        string street = reader.GetString(2);
                        string town = reader.GetString(3);
                        string county = reader.GetString(4);
                        string country = reader.GetString(5);
                        string postcode = reader.GetString(6);
                        string email = reader.GetString(7);
                        string contact = reader.GetString(8);
                        // Console.WriteLine(supplierID + "," + supplierName);
                        list[0] = customerID;
                        list[1] = customerName;
                        list[2] = street;
                        list[3] = town;
                        list[4] = county;
                        list[5] = country;
                        list[6] = postcode;
                        list[7] = email;
                        list[8] = contact;
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                fillTextDetails(list);
            }
            else
            {
                MessageBox.Show("Not connected to supplier");
            }
        }

        //Fill the selected Product details 
        private void fillProductDetails(string str, string value)
        {
            var conn = connect();
            string[] list = new string[9];
            if (conn.IsConnect())
            {
                string query = "";
                if (value.Equals("name"))
                    query = "SELECT * FROM Product WHERE ProductDesc ='" + str + "' ";
                else if (value.Equals("id"))
                    query = "SELECT * FROM Product WHERE ProductID ='" + str + "' ";
                var cmd = new MySqlCommand(query, conn.Connection);
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string productID = reader.GetString(0);
                        string productName = reader.GetString(1);
                        string supplierID = reader.GetString(2);
                        string gender = reader.GetString(3);
                        string size = reader.GetString(4);
                        string price = reader.GetString(5);
                        string colour = reader.GetString(6);
                        string stocklevel = reader.GetString(7);
                        string imgLocation = reader.GetString(8);
                        // Console.WriteLine(supplierID + "," + supplierName);
                        list[0] = productID;
                        list[1] = productName;
                        list[2] = supplierID;
                        list[3] = gender;
                        list[4] = size;
                        list[5] = price;
                        list[6] = colour;
                        list[7] = stocklevel;
                        list[8] = imgLocation;
                    }
                    reader.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Connection problem!!");
                }
                fillTextDetails(list);
                getPictureFromServer(list[8]);
            }
            else
            {
                MessageBox.Show("Not connected to supplier");
            }
        }

        public void getPictureFromServer(String imgLocation)
        {
            pictureBox1.ImageLocation = "http://www.project.serversite.info/" + imgLocation;
          
        }

       

        public void UpLoadFile(string localFilePath)
        {
            try
            {
                //var fileName = Path.GetFileName(localFilePath);
                var fileName = getImageName();
                var request = (FtpWebRequest)WebRequest.Create("???" + fileName);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential("???", "???");
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                using (var fileStream = File.OpenRead(localFilePath))
                {
                    using (var requestStream = request.GetRequestStream())
                    {
                        fileStream.CopyTo(requestStream);
                        requestStream.Close();
                    }
                }

                var response = (FtpWebResponse)request.GetResponse();
  
                Console.WriteLine("Upload done: {0}", response.StatusDescription);
                response.Close();
              }
            catch (Exception) { errorMessageBox("Can't connect to server"); }
        }

        /*   private Boolean checkFileSize()
           {
               Boolean check = false;
               double bytes = file.length();
               double kilobytes = (bytes / 1024);
               double megabytes = (kilobytes / 1024);
               if (megabytes <= 0.5)
               {
                   check = true;
               }
               return check;
           }*/
    }
}
