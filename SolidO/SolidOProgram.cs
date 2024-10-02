using MenuUtil;
using SolidO.Ingredient;
using SolidO.PieFilling;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 3.1 SOLID - Open Closed. Тема G - Кулинария и покупки
 * 
 * Разработать класс пирога, в который можно класть разную начинку,
 * в зависимости от которой вкус может быть от "несъедобно" до "божественно" 
 *
 */

namespace SolidO
{

    internal class SolidOProgram
    {
        static void PopulateMenu(ActionMenu menu)
        {
            menu.AddAction("Испечь пирог с клубникой", BakeStrawberrykPie);
            menu.AddAction("Испечь пирог с кирпичём", BakeBrickPie);
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void BakeStrawberrykPie()
        {
            IPieFiling filing = new StrawberryFiling();
            Pie pie = new Pie(filing);
            Console.WriteLine("\n" + pie.GetPieDescription() + "\n");
        }

        static void BakeBrickPie()
        {
            IPieFiling filing = new BrickFiling();
            Pie pie = new Pie(filing);
            Console.WriteLine("\n" + pie.GetPieDescription() + "\n");
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            PopulateMenu(menu);

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
