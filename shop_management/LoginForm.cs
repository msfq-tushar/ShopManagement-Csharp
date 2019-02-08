using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    

        private void button1_Click(object sender, EventArgs e)
        {
            loginInfo lo = new loginInfo();

            lo.Username = textbox1.Text;
            lo.Password = textbox2.Text;
            if (lo.ValidateUser() == true)
            {
                if (lo.checkTypeOfUser() == 2)
                {
                    salesmanForm s = new salesmanForm();
                    this.Hide();
                    s.Show();
                }
                if (lo.checkTypeOfUser() == 1)
                {
                    adminForm s = new adminForm();
                    this.Hide();
                    s.Show();
                }
           }

            else if (textbox1.Text == "" || textbox2.Text == "")
            {
                MessageBox.Show("please fill up user name and password");
            }
            else
            {
                MessageBox.Show("invalid Username or Password");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
