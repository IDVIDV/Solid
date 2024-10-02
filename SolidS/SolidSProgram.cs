using MenuUtil;
using SolidS.Product;
using SolidS.ShopStuff;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 2.1 SOLID - Single Responsibility. Тема G - Кулинария и покупки
 * 
 * Разработать магазин, в котором содержатся продукты. 
 * Помимо хранения продуктов должна быть возможность провести инвентаризацию и узнать суммарную стоимость находящихся в магазине продуктов
 * 
 */

namespace SolidS
{
    internal class SolidSProgram
    {
        static void PopulateMenu(ActionMenu menu, IShop shop, ShopManager shopManager)
        {
            menu.AddAction("Добавить случайный продукт в магазин", () => AddRandomProduct(shop) );
            menu.AddAction("Убрать первый продукт из списка", () => RemoveFirstProduct(shop));
            menu.AddAction("Убрать последний продукт из списка", () => RemoveLastProduct(shop));
            menu.AddAction("Узнать суммарную стоимость продуктов в магазине", () => GetSummaryPrice(shopManager));
            menu.AddAction("Провести инвентаризацию", () => Inventorize(shopManager));
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void AddRandomProduct(IShop shop)
        {
            Random rnd = new Random();

            IProduct product = (rnd.Next(2) == 0) ? new DefaultProduct() : new ExpensiveProduct();

            shop.AddProduct(product);

            Console.WriteLine("\nДобавлен " + product.Name + "\n");
        }

        static void RemoveFirstProduct(IShop shop)
        {
            IProduct product = shop.RemoveProduct(0);

            if (product != null)
            {
                Console.WriteLine("\nУбран " + product.Name + "\n");
            }
            else
            {
                Console.WriteLine("\nМагазин пуст\n");
            }
        }

        static void RemoveLastProduct(IShop shop)
        {
            IProduct product = shop.RemoveProduct(shop.GetProducts().Count - 1);

            if (product != null)
            {
                Console.WriteLine("\nУбран " + product.Name + "\n");
            }
            else
            {
                Console.WriteLine("\nМагазин пуст\n");
            }
        }

        static void GetSummaryPrice(ShopManager shopManager)
        {
            Console.WriteLine("\nСуммарная стоимость продуктов: " + shopManager.GetSummaryPrice() + "\n");
        }

        static void Inventorize(ShopManager shopManager)
        {
            Console.WriteLine("\nСодержимое магазина:\n" + shopManager.Inventorize() + "\n");
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            IShop shop = new Shop();
            ShopManager shopManager = new ShopManager(shop);
            PopulateMenu(menu, shop, shopManager);

            int actionNumber = 0;

            while (true)
            {
                menu.PrintActionDescriptions(Console.OpenStandardOutput());

                Console.Write("Ваш выбор -> ");

                if (!Int32.TryParse(Console.ReadLine(), out actionNumber) || !menu.TryDoAction(actionNumber - 1))
                {
                    Console.WriteLine("\nВыбор не распознан, повторите попытку\n");
                }
            }
        }
    }
}
