namespace SolidLPoor.Pills
{
    public class AntibioticPill : Pill
    {
        public bool RecipeGot { get; set; } = false;
        public override string Take()
        {
            if (RecipeGot)
            {
                return base.Take();
            }
            else
            {
                throw new PillConsumingDangerousException();
            }
        }
    }
}
