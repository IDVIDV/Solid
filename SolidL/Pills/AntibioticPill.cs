namespace SolidL.Pills
{
    public class AntibioticPill : IRecipePill
    {
        public bool RecipeGot { get; set; } = false;

        public string Take()
        {
            if (RecipeGot)
            {
                return "Вы выпиваете таблетку с водой";
            }
            else
            {
                throw new PillConsumingDangerousException();
            }
        }
    }
}
