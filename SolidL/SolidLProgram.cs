using MenuUtil;
using SolidL.Pills;
using System;
using System.Text;

/*
 * Ивакин Д. В. 4к 9г
 * 
 * Лабораторная 4.1 SOLID - Liskov Substitution. Тема B - Биология и медицина
 */

namespace SolidL
{
    internal class SolidLProgram
    {
        static void PopulateMenu(ActionMenu menu, IPill pill, IRecipePill antibioticPill)
        {
            menu.AddAction("Выпить таблетку ", () => TakePill(pill));
            menu.AddAction("Выпить таблетку с антибиотиком", () => TakePill(antibioticPill));
            menu.AddAction("Получить рецепт на таблетку с антибиотиком", () => GetRecipe(antibioticPill));
            menu.AddAction("\"Отозвать\" рецепт на таблетку с антибиотиком", () => CancelRecipe(antibioticPill));
            menu.AddAction("Завершить работу", () =>
            {
                Console.WriteLine("\nЗавершение работы\n");
                Environment.Exit(0);
            });
        }

        static void TakePill(IPill pill)
        {
            Console.WriteLine("\n" + pill.Take() + "\n");
        }

        static void TakePill(IRecipePill pill)
        {
            try
            {
                Console.WriteLine("\n" + pill.Take() + "\n");
            }
            catch (PillConsumingDangerousException e)
            {
                Console.WriteLine("\nУпотребление антибиотика опасно без предписания врача\n");
            }
        }

        static void GetRecipe(IRecipePill pill)
        {
            pill.RecipeGot = true;
            Console.WriteLine("\nВрач выписал вам рецепт на антибиотики\n");
        }

        static void CancelRecipe(IRecipePill pill)
        {
            pill.RecipeGot = false;
            Console.WriteLine("\nВы потеряли бумажку, которую выписал вам врач\n");
        }

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ActionMenu menu = new ActionMenu(Encoding.GetEncoding(866));
            Pill regularPill = new Pill();
            AntibioticPill antibioticPill = new AntibioticPill();
            PopulateMenu(menu, regularPill, antibioticPill);

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
