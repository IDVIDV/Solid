using SolidS.Product;
using System.Collections.Generic;

namespace SolidS.ShopStuff
{
    public interface IShop
    {
        void AddProduct(IProduct product);

        IProduct RemoveProduct(int productNumber);

        IList<IProduct> GetProducts();
    }
}
