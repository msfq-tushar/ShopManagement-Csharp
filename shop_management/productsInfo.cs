using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_management
{
    public class productsInfo
    {
        protected int Id;
        protected string Name;
        protected int Quantity;
        protected double Price;
        protected static double TotalPrice;

        public int ProductId
        {
            get { return this.Id; }
            set { this.Id = value; }
        }
        public string ProductName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public int ProductQuantity
        {
            get { return this.Quantity; }
            set { this.Quantity = value; }
        }

        public double ProductPrice
        {
            get { return this.Price; }
            set { this.Price = value; }

        }
       
        public double calculateTotalPrice()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            product p = md.products.SingleOrDefault(x => x.productName == ProductName);
            TotalPrice=TotalPrice+(double)(Quantity * p.price);
            return TotalPrice;

            }
       

    }
}
