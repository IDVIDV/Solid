using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 2.1 SOLID - Single Responsibility. Тема G - Кулинария и покупки
 */

namespace SolidS
{
    internal class Program
    {
        public static void Action2(int i)
        {
            Console.WriteLine(i);
        }

        public static void Action()
        {
            Console.WriteLine("Aфывфывфв");
        }

        static void Main(string[] args)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //MenuUtil.ActionMenu menu = new MenuUtil.ActionMenu();


            //menu.AddAction("фывфывфывфв 1", () => Action());
            //menu.AddAction("Action 2",() => Action2(1));

            //menu.PrintActionDescriptions(Console.OpenStandardOutput(), Encoding.GetEncoding(866));
            //menu.TryDoAction(0);
            //menu.TryDoAction(1);
        }
    }
}
