using SolidO.Ingredient;

namespace SolidO
{
    public class Pie
    {
        private IPieFiling filing;

        public Pie(IPieFiling filing)
        {
            this.filing = filing;
        }

        public string GetPieDescription()
        {
            return "Начинка в пироге: " + filing.Name + ". Вкус пирога: " + filing.Scale;
        }
    }
}
