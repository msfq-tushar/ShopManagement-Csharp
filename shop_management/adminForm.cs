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
    public partial class adminForm : Form
    {
        public adminForm()
        {
            InitializeComponent();
            timer2.Start();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            MyClassDataContext m = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            int a=m.products.Count();

            int id = 1;
            while (id <= a)
            {

                MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
                product t = md.products.SingleOrDefault(x => x.Id == id);

                col.Add(t.productName);
                id++;
            }
            textBox1.AutoCompleteCustomSource = col;            
                                                         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text != "" && textBoxQuantity.Text != "" && textBoxPrice.Text != "" && textBoxName.Text != "")
            {
                DatabaseAccess.Id = Convert.ToInt32(textBoxID.Text);
                DatabaseAccess.Name = textBoxName.Text;
                DatabaseAccess.Price = Convert.ToDouble(textBoxPrice.Text);
                DatabaseAccess.Quantity = Convert.ToInt16(textBoxQuantity.Text);
                DatabaseAccess.AddItem();
                textBoxID.Text = null;
                textBoxQuantity.Text = null;
                textBoxPrice.Text = null;
                textBoxName.Text = null;
            }
            else
                MessageBox.Show("please ID,price,quantity,product name Insert correctly");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            AllProductShowForAdmin a = new AllProductShowForAdmin();
            a.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                DatabaseAccess.Id = Convert.ToInt32(textBox5.Text);
                DatabaseAccess.DeleteItem();
                textBox5.Text = null;
            }
            else
                MessageBox.Show("Insert id firts for which item want to delete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxIDforUp.Text != "")
            {
                DatabaseAccess.Id = Convert.ToInt16(textBoxIDforUp.Text);
                DatabaseAccess.serachItem();
                textBoxNameforUp.Text = DatabaseAccess.Name;
                textBoxPriceforUp.Text = Convert.ToString(DatabaseAccess.Price);
                textBoxQunforUp.Text = Convert.ToString(DatabaseAccess.Quantity);
            }
            else
                MessageBox.Show("Please Insert id 1st :p");
           
          }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBoxIDforUp.Text != "" && textBoxNameforUp.Text != "" && textBoxPriceforUp.Text != "" && textBoxQunforUp.Text != "")
            {
                DatabaseAccess.Id = Convert.ToInt16(textBoxIDforUp.Text);
                DatabaseAccess.Quantity = Convert.ToInt16(textBoxQunforUp.Text);
                DatabaseAccess.Name = textBoxNameforUp.Text;
                DatabaseAccess.Price = Convert.ToDouble(textBoxPriceforUp.Text);
                DatabaseAccess.UpdateItem();
                textBoxIDforUp.Text = null;
                textBoxNameforUp.Text = null;
                textBoxPriceforUp.Text = null;
                textBoxQunforUp.Text = null;
            }
            else
                MessageBox.Show("please search Item before Update :)");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm();
            this.Hide();
            l.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
           
            

            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            signUpForm a = new signUpForm();
            a.Show();
            this.Hide();

        }

        private void adminForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            search s = new search();
            s.ProductName = textBox1.Text;
            s.caclSearch();

            DataTable ss = new DataTable();
            ss.Columns.Add("Id");
            ss.Columns.Add("Name");
            ss.Columns.Add("Quantiy");
            ss.Columns.Add("Price");

            DataRow row = ss.NewRow();
            row["Id"] = Convert.ToString(s.ProductId);
            row["Name"] = Convert.ToString(s.ProductName);
            row["Quantiy"] = Convert.ToString(s.ProductQuantity);
            row["Price"] = Convert.ToString(s.ProductPrice);
            ss.Rows.Add(row);

            foreach (DataRow Drow in ss.Rows)           //Drow is datarow
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = Drow["Id"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = Drow["Name"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = Drow["Quantiy"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = Drow["Price"].ToString();

            }
           
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.time_lbl.Text = dateTime.ToString();
 }
    }
}
