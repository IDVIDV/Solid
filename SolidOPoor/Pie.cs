namespace SolidOPoor
{
    public class Pie
    {
        private string filing;

        public Pie(string filing)
        {
            this.filing = filing;
        }

        public string GetPieDescription()
        {
            string description = "Начинка в пироге: " + filing + ". Вкус пирога: ";

            switch (filing)
            {
                case "клубника":
                    description += "Очень вкусно";
                    break;
                case "кирпич":
                    description += "Несъедобно";
                    break;
                default:
                    description += "Неизвестен";
                    break;
            }

            return description;
        }
    }
}
