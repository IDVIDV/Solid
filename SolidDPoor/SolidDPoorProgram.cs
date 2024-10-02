using MenuUtil;
using SolidDPoor.HealItem;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 6.2 SOLID - Dependency Inversion. Тема B - Биология и медицина
 * 
 * Создать класс аптечки, который представляет собой контейнер для медицинских предметов.
 * В аптечке должно содержаться до 3-x предметов, предметы могут повторяться.
 * Также должна быть возможность просмотреть и поменять содержимое аптечки.
 */

namespace SolidDPoor
{
    internal class SolidDPoorProgram
    {
        static void PopulateMenu(ActionMenu menu, FirstAid firstAid)
        {
            menu.AddAction("Просмотреть содержимое аптечки", () => CheckFirstAid(firstAid));
            menu.AddAction("Сгенерировать новое содержимое аптечки", () => ShuffleFirstAid(firstAid));
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void CheckFirstAid(FirstAid firstAid)
        {
            Console.WriteLine();
            Console.WriteLine(firstAid.CheckContent());
        }

        static void ShuffleFirstAid(FirstAid firstAid)
        {
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                int rndVal = rnd.Next(4);

                switch (rndVal)
                {
                    case 0:
                        firstAid.PutItem(i, new Adrenaline());
                        break;
                    case 1:
                        firstAid.PutItem(i, new Bundle());
                        break;
                    case 2:
                        firstAid.PutItem(i, new Sanitizer());
                        break;
                    case 3:
                        firstAid.PutItem(i, (Bundle) null);
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            FirstAid firstAid = new FirstAid(null, null, null);
            PopulateMenu(menu, firstAid);

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
