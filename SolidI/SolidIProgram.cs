using MenuUtil;
using SolidI.Vehicle;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 5.1 SOLID - Interface Segregation. Тема I - Техника (от карьерных самосвалов до стиральной машины);
 * 
 * Разработать технопарк миллиардера.
 * 
 */

namespace SolidI
{
    internal class SolidIProgram
    {
        static void PopulateMenu(ActionMenu menu, ISwimable swimable, IDriveable driveable, IDriveableFlyable driveableFlyable)
        {
            menu.AddAction("Воспользоваться машиной", () => UseDriveable(driveable));
            menu.AddAction("Воспользоваться лодкой", () => UseSwimable(swimable));
            menu.AddAction("Воспользоваться самолётом", () => UseDriveableFlyable(driveableFlyable));
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void UseDriveable(IDriveable driveable)
        {
            Console.WriteLine("\n" + driveable.Drive() + "\n");
        }

        static void UseDriveableFlyable(IDriveableFlyable driveableFlyable)
        {
            Random rng = new Random();

            if (rng.Next(2) == 0)
            {
                Console.WriteLine("\n" + driveableFlyable.Fly() + "\n");
            }
            else
            {
                Console.WriteLine("\n" + driveableFlyable.Drive() + "\n");
            }
        }

        static void UseSwimable(ISwimable swimable)
        {
            Console.WriteLine("\n" + swimable.Swim() + "\n");
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            ISwimable swimable = new Boat();
            IDriveable driveable = new Car();
            IDriveableFlyable driveableFlyable = new Vehicle.Plane();
            PopulateMenu(menu, swimable, driveable, driveableFlyable);

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
