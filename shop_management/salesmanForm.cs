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
    public partial class salesmanForm : Form
    {
        public salesmanForm()
        {
            InitializeComponent();
            timer1.Start();

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            MyClassDataContext m = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            int a = m.products.Count();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllProductShowForSalesman a= new AllProductShowForSalesman();
            a.Show();
            this.Hide();
         }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    productsInfo pi = new productsInfo();
                    pi.ProductName = textBox1.Text;
                    pi.ProductQuantity = Convert.ToInt32(textBox2.Text);
                    textBox3.Text = Convert.ToString(pi.calculateTotalPrice());
                    DatabaseAccess.Name = textBox1.Text;
                    DatabaseAccess.Quantity = Convert.ToInt32(textBox2.Text);
                    DatabaseAccess.UpdateforCart();
                    shopingCart sc = new shopingCart();
                    sc.ProductName= textBox1.Text;
                    sc.ProductQuantity = Convert.ToInt32(textBox2.Text);
                    sc.InsertShoppingCart();
                    DataTable ss = new DataTable();
                    ss.Columns.Add("Name");
                    ss.Columns.Add("Quantiy");
                    ss.Columns.Add("Price");

                    DataRow row = ss.NewRow();
                    row["Name"] = Convert.ToString(sc.ProductName);
                    row["Quantiy"] = Convert.ToString(sc.ProductQuantity);
                    row["Price"] = Convert.ToString(sc.ProductPrice);
                    ss.Rows.Add(row);

                    foreach (DataRow Drow in ss.Rows)           //Drow is datarow
                    {
                        int num = dataGridView2.Rows.Add();

                        dataGridView2.Rows[num].Cells[0].Value = Drow["Name"].ToString();
                        dataGridView2.Rows[num].Cells[1].Value = Drow["Quantiy"].ToString();
                        dataGridView2.Rows[num].Cells[2].Value = Drow["Price"].ToString();

                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                }
               

          
        }

   
      
        private void salesmanForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        { 
            DatabaseAccess a = new DatabaseAccess();
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                string q= row.Cells[1].Value.ToString();
                string n = row.Cells[0].Value.ToString();
                DatabaseAccess.Name = n;
                DatabaseAccess.Quantity = Convert.ToInt32(q);
                DatabaseAccess.UpdateforCartQuantity();
                shopingCart.cartProductName = n;
                shopingCart.Quantity = Convert.ToInt32(q);
                textBox3.Text = Convert.ToString(shopingCart.calculateTotalPriceC());


           }
         foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.receiptIm;
            Image newImage = bmp;
            e.Graphics.DrawImage(newImage,250,10);
            Bitmap bm = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bm,new Rectangle(0,0,this.dataGridView2.Width,this.dataGridView2.Height));
            e.Graphics.DrawImage(bm,250,250);
            e.Graphics.DrawString("Total Price=", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(this.dataGridView2.Width+110, dataGridView2.Height+300));
            e.Graphics.DrawString(textBox3.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(this.dataGridView2.Width +210, dataGridView2.Height + 300));
            e.Graphics.DrawString("=============================================================================================", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, 200));
            e.Graphics.DrawString("Customer Signature", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(650, 1000));
            e.Graphics.DrawString("Salesman Signature", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(50, 1000));
             DateTime dateTime = DateTime.Now;
             e.Graphics.DrawString(dateTime.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(10, 220));
             if (checkedListBox1.SelectedItem != null)
             {
                 e.Graphics.DrawString("Paid by:" + checkedListBox1.SelectedItem.ToString(), new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(this.dataGridView2.Width, dataGridView2.Height + 400));
             }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

       }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.time_lbl.Text = dateTime.ToString();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginForm log = new LoginForm();
            this.Hide();
            log.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

    }
}
