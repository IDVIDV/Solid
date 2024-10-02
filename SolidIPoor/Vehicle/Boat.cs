using System;

namespace SolidIPoor.Vehicle
{
    public class Boat : IVehicle
    {
        public string Drive()
        {
            throw new NotImplementedException();
        }

        public string Fly()
        {
            throw new NotImplementedException();
        }

        public string Swim()
        {
            return "Лодка рассекает волны по Волге";
        }
    }
}
