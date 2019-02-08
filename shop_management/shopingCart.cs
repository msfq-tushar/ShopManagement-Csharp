using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_management
{
    class shopingCart:productsInfo
    {
        public static string cartProductName;
        public static int Quantity;


        public void InsertShoppingCart()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            product p = md.products.SingleOrDefault(x => x.productName ==ProductName);
            
            this.ProductName = p.productName;
            double calcCartSingleProductPrice = p.price*this.ProductQuantity;
            this.ProductPrice = calcCartSingleProductPrice;
            
            
       }
        public static double calculateTotalPriceC()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            product p = md.products.SingleOrDefault(x => x.productName == cartProductName);
            TotalPrice = TotalPrice - (double)(Quantity * p.price);
            return TotalPrice;

        }
      


    }
}
