using SolidS.Product;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SolidS.ShopStuff
{
    public class Shop : IShop
    {
        private IList<IProduct> _products;

        public Shop()
        {
            _products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public IProduct RemoveProduct(int productNumber)
        {
            if (productNumber < 0 || productNumber > _products.Count - 1)
            {
                return null;
            }

            IProduct product = _products[productNumber];
            _products.RemoveAt(productNumber);

            return product;
        }

        public IList<IProduct> GetProducts()
        {
            return _products.ToImmutableList();
        }
    }
}
