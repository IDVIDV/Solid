using SolidO.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidO.PieFilling
{
    public class BrickFiling : IPieFiling
    {
        public string Scale => "Несъедобно";

        public string Name => "Кирпич";
    }
}
