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
    public partial class AllProductShowForAdmin : Form
    {
        public AllProductShowForAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminForm a = new adminForm();
            this.Hide();
            a.Show();
        }

        private void AllProductShow_Load(object sender, EventArgs e)
        {
            MyClassDataContext d = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            dataGridView1.DataSource = d.products;
        }
    }
}
