using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_management
{
    class search:productsInfo
    {

       
        public void caclSearch()
        {
            MyClassDataContext md = new MyClassDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\C# project\shop_management\shop_management\shop.mdf;Integrated Security=True;Connect Timeout=30");

            product t = md.products.SingleOrDefault(x => x.productName == ProductName);
            this.ProductId = t.Id;
            this.ProductName = t.productName;
            this.ProductPrice = t.price;
            this.ProductQuantity = (int)t.quantity;

        }
    }
}
