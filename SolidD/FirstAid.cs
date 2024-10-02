using SolidD.HealItem;

namespace SolidD
{
    public class FirstAid
    {
        private IInspectable[] items;

        public FirstAid(IInspectable item1, IInspectable item2, IInspectable item3)
        {
            items = new IInspectable[3];
            items[0] = item1;
            items[1] = item2;
            items[2] = item3;
        }

        public string CheckContent()
        {
            string result = "";

            foreach (IInspectable item in items)
            {
                if (item != null)
                {
                    result += item.Inspect() + "\n";
                }
            }

            if (result.Length == 0)
            {
                result = "Аптечка пуста\n";
            }

            return result;
        }

        public bool PutItem(int i, IInspectable item)
        {
            if (i < 0 || i > items.Length - 1)
            {
                return false;
            }

            items[i] = item;

            return true;
        }
    }
}
