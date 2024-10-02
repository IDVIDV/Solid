

using SolidDPoor.HealItem;

namespace SolidDPoor
{
    public class FirstAid
    {
        private Bundle[] bundles;
        private Adrenaline[] adrenalines;
        private Sanitizer[] sanitizers;

        public FirstAid(Bundle bundle, Adrenaline adrenaline, Sanitizer sanitizer)
        {
            this.bundles = new Bundle[3] { bundle, null, null };
            this.adrenalines = new Adrenaline[3] { null, adrenaline, null };
            this.sanitizers = new Sanitizer[3] { null, null, sanitizer};
        }

        public string CheckContent()
        {
            string result = "";

            for (int i = 0; i < bundles.Length; ++i)
            {
                if (bundles[i] != null)
                {
                    result += bundles[i].Inspect() + "\n";
                }

                if (adrenalines[i] != null)
                {
                    result += adrenalines[i].Inspect() + "\n";
                }

                if (sanitizers[i] != null)
                {
                    result += sanitizers[i].Inspect() + "\n";
                }
            }

            if (result.Length == 0)
            {
                result = "Аптечка пуста\n";
            }

            return result;
        }

        public bool PutItem(int i, Bundle item)
        {
            if (i < 0 || i > bundles.Length - 1)
            {
                return false;
            }

            bundles[i] = item;
            adrenalines[i] = null;
            sanitizers[i] = null;

            return true;
        }

        public bool PutItem(int i, Adrenaline item)
        {
            if (i < 0 || i > adrenalines.Length - 1)
            {
                return false;
            }

            bundles[i] = null;
            adrenalines[i] = item;
            sanitizers[i] = null;

            return true;
        }

        public bool PutItem(int i, Sanitizer item)
        {
            if (i < 0 || i > sanitizers.Length - 1)
            {
                return false;
            }

            bundles[i] = null;
            adrenalines[i] = null;
            sanitizers[i] = item;

            return true;
        }
    }
}
