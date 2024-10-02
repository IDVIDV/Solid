namespace SolidI.Vehicle
{
    public class Plane : IDriveableFlyable
    {
        public string Drive()
        {
            return "Самолет едет по аэродрому";
        }

        public string Fly()
        {
            return "Самолет летит на высоте 10км";
        }
    }
}
