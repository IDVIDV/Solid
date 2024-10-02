using SolidSPoor.Product;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SolidSPoor
{
    public class Shop
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

        public IProduct? RemoveProduct(int productNumber)
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


        public int GetSummaryPrice()
        {
            int sum = 0;

            foreach (IProduct product in _products)
            {
                if (product != null)
                {
                    sum += product.Price;
                }
            }

            return sum;
        }

        public string Inventorize()
        {
            string result = "";

            for (int i = 0; i < _products.Count; ++i)
            {
                if (_products[i] != null)
                {
                    result += (i + 1).ToString() + ". " + _products[i].Name + ", стоимость " + _products[i].Price + "\n";
                }
            }

            if (result.Length == 0)
            {
                result = "Магазин пуст";
            }

            return result;
        }
    }
}
