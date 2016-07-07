using System;
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
    public partial class Form2 : Form
    {
        private string detailsOfDropBox = "";
       
        public Form2(string actualUser)
        {
            InitializeComponent();
            setDropBoxes();
            fillUserNameComboBox();
            fillCustomerComboBox();
            fillAllOtherLog();
            
        }

        //set drop boxes style
        private void setDropBoxes()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //fill name combobox
        private void fillUserNameComboBox()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Clear();
            comboBox1.BeginUpdate(); // <- Stop painting
            string[] temp = History.users();
            
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

        //fill customer combobox
        private void fillCustomerComboBox()
        {
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Items.Clear();
            comboBox4.BeginUpdate(); // <- Stop painting
           
            string[] temp = History.customerDropBox();
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox4.Items.Add(item);
                }
            }
            finally
            {
                comboBox4.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //fill customer bougth combobox
        private void fillCustomerBougthComboBox(string[]arr)
        {
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.Items.Clear();
            comboBox5.BeginUpdate(); // <- Stop painting
            string[] temp = arr;
           
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox5.Items.Add(item);
                }
            }
            finally
            {
                comboBox5.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //fill all Other log
        private void fillAllOtherLog()
        {
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.Items.Clear();
            comboBox6.BeginUpdate(); // <- Stop painting
            string[] temp = History.getAllOtherLog();
        
            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox6.Items.Add(item);
                }
            }
            finally
            {
                comboBox6.EndUpdate(); // <- Finally, repaint if required
            }
        }

        //fill user log
        private void fillUserLog(string user)
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.Clear();
            comboBox3.BeginUpdate(); // <- Stop painting
            string[] temp = History.getUserLog(user);
         
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

        //fill user action
        private void fillUserAction(string user)
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Clear();
            comboBox2.BeginUpdate(); // <- Stop painting
            string[] temp = History.getUserActions(user);

            try
            {
                // Adding new items into the cmbMovieListingBox 
                foreach (string item in temp)
                {
                    //  Console.WriteLine("Build dropbox " + item);
                    comboBox2.Items.Add(item);
                }
            }
            finally
            {
                comboBox2.EndUpdate(); // <- Finally, repaint if required
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        //Close button 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //User drop down
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            fillUserLog(selected);
            fillUserAction(selected);
        }

        //Select action drop down
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string details = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            detailsOfDropBox = detailsOfDropBox + "\n" + details;
            richTextBox1.Text = detailsOfDropBox;
        }

        //Customer drop down
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
            Console.WriteLine("Selected " + selected);
            fillCustomerBougthComboBox(History.customerBougthDropBox(selected));
        }

        //Bougth products drop down
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string details = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            detailsOfDropBox = detailsOfDropBox + "\n" + details;
            richTextBox1.Text = detailsOfDropBox;
        }

        //Log records connected to user drop down
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            detailsOfDropBox = detailsOfDropBox + "\n" + selected;
            richTextBox1.Text = detailsOfDropBox;
           
        }

        //All other log drop down
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string details = this.comboBox6.GetItemText(this.comboBox6.SelectedItem);
            detailsOfDropBox = detailsOfDropBox + "\n" + details;
            richTextBox1.Text = detailsOfDropBox;
        }

        //Clear button clear richTextBox1 text area
        private void button10_Click(object sender, EventArgs e)
        {
            detailsOfDropBox = "";
            richTextBox1.Text = detailsOfDropBox;
        }
    }
}

