using MenuUtil;
using SolidSPoor.Product;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 2.2 SOLID - Single Responsibility. Тема G - Кулинария и покупки
 * 
 * Разработать магазин, в котором содержатся продукты. 
 * Помимо хранения продуктов должна быть возможность провести инвентаризацию и узнать суммарную стоимость находящихся в магазине продуктов
 * 
 */

namespace SolidSPoor
{
    internal class SolidSPoorProgram
    {
        static void PopulateMenu(ActionMenu menu, Shop shop)
        {
            menu.AddAction("Добавить случайный продукт в магазин", () => AddRandomProduct(shop));
            menu.AddAction("Убрать первый продукт из списка", () => RemoveFirstProduct(shop));
            menu.AddAction("Убрать последний продукт из списка", () => RemoveLastProduct(shop));
            menu.AddAction("Узнать суммарную стоимость продуктов в магазине", () => GetSummaryPrice(shop));
            menu.AddAction("Провести инвентаризацию", () => Inventorize(shop));
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void AddRandomProduct(Shop shop)
        {
            Random rnd = new Random();

            IProduct product = (rnd.Next(2) == 0) ? new DefaultProduct() : new ExpensiveProduct();

            shop.AddProduct(product);

            Console.WriteLine("\nДобавлен " + product.Name + "\n");
        }

        static void RemoveFirstProduct(Shop shop)
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

        static void RemoveLastProduct(Shop shop)
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

        static void GetSummaryPrice(Shop shop)
        {
            Console.WriteLine("\nСуммарная стоимость продуктов: " + shop.GetSummaryPrice() + "\n");
        }

        static void Inventorize(Shop shop)
        {
            Console.WriteLine("\nСодержимое магазина:\n" + shop.Inventorize() + "\n");
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            Shop shop = new Shop();
            PopulateMenu(menu, shop);

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
