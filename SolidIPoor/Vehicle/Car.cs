using System;

namespace SolidIPoor.Vehicle
{
    internal class Car : IVehicle
    {
        public string Drive()
        {
            return "Машина едет под трек Nightcall, за рулем Райан Гослинг";
        }

        public string Fly()
        {
            throw new NotImplementedException();
        }

        public string Swim()
        {
            throw new NotImplementedException();
        }
    }
}
