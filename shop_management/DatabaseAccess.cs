using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_management
{
    class DatabaseAccess
    {
        public static int Id;
        public static int Quantity;
        public static string Name;
        public static double Price;
        




        public static void UpdateforCart()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
         
            product p = md.products.SingleOrDefault(x => x.productName == Name);
            p.quantity -= Quantity;
            md.SubmitChanges();
           
        }

        public static void UpdateforCartQuantity()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");

            product p = md.products.SingleOrDefault(x => x.productName == Name);
            p.quantity += Quantity;
            md.SubmitChanges();

        }


        public static void AddItem()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            product t = new product();
            t.Id=Id;
            t.price=Price;
            t.quantity=Quantity;
            t.productName=Name;
            md.products.InsertOnSubmit(t);
            md.SubmitChanges();

           
        }


        public static void DeleteItem()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");

            int id = Id;
            product t = md.products.SingleOrDefault(x => x.Id == Id);
            md.products.DeleteOnSubmit(t);
            md.SubmitChanges();

        }

        public static void serachItem()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            int id = Id;
            product t = md.products.SingleOrDefault(x => x.Id == Id);
            Name = t.productName;
            Price = t.price;
            Quantity =Convert.ToInt16( t.quantity);
        }

        public static void UpdateItem()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");
            int id = Id;
            product t = md.products.SingleOrDefault(x => x.Id == Id);
            t.productName =Name ;
            t.Id = Id;
            t.price = Price;
            t.quantity = Quantity;
            md.SubmitChanges();
        }

        
    
    }
}
