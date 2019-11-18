using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType militaryType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType militaryType)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.militaryType = militaryType;
        }

        public override bool Equals(object objToCompare)
        {
            return (objToCompare as MilitaryPlane) != null &&
                   base.Equals(objToCompare) &&
                   militaryType == (objToCompare as MilitaryPlane).militaryType;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            return (hashCode * -1521134295 + base.GetHashCode())
                * hashCode * -1521134295 + militaryType.GetHashCode();
        }

        public MilitaryType GetPlaneTypeIs()
        {
            return militaryType;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}", ", type=" + militaryType + '}');
        }
    }
}
