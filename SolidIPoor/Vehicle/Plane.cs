using System;

namespace SolidIPoor.Vehicle
{
    public class Plane : IVehicle
    {
        public string Drive()
        {
            return "Самолет едет по аэродрому";
        }

        public string Fly()
        {
            return "Самолет летит на высоте 10км";
        }

        public string Swim()
        {
            throw new NotImplementedException();
        }
    }
}
