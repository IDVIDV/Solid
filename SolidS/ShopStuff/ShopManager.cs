using SolidS.Product;
using System.Collections.Generic;

namespace SolidS.ShopStuff
{
    public class ShopManager
    {
        private IShop _shop;

        public ShopManager(IShop shop)
        {
            this._shop = shop;
        }

        public int GetSummaryPrice()
        {
            int sum = 0;
            IList<IProduct> products = _shop.GetProducts();

            foreach (IProduct product in products)
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
            IList<IProduct> products = _shop.GetProducts();

            for (int i = 0; i < products.Count; ++i)
            {
                if (products[i] != null)
                {
                    result += (i + 1).ToString() + ". " + products[i].Name + ", стоимость " + products[i].Price + "\n";
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
