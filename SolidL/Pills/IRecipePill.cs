namespace SolidL.Pills
{
    public interface IRecipePill
    {
        bool RecipeGot { get; set; }

        string Take();
    }
}
