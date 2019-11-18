using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string modelAirplane;
        public int maxSpeedAirplane, maxFlightDistanceAirplane, maxLoadCapacityAirplane;

        public Plane(string modelAirplane, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            this.modelAirplane = modelAirplane;
            this.maxSpeedAirplane = maxSpeed;
            this.maxFlightDistanceAirplane = maxFlightDistance;
            this.maxLoadCapacityAirplane = maxLoadCapacity;
        }

        public string GetModel()
        {
            return this.modelAirplane;
        }

        public int GetMaxSpeed()
        {
            return this.maxSpeedAirplane;
        }

        public int GetMaxFlightDistance()
        {
            return this.maxFlightDistanceAirplane;
        }

        public int GetMaxLoadCapacity()
        {
            return this.maxLoadCapacityAirplane;
        }

        public override string ToString()
        {
            return "Plane{" +
                "model='" + this.modelAirplane + '\'' +
                ", maxSpeedAirplane=" + this.maxSpeedAirplane +
                ", maxFlightDistanceAirplane=" + this.maxFlightDistanceAirplane +
                ", maxLoadCapacityAirplane=" + this.maxLoadCapacityAirplane +
                '}';
        }

        public override bool Equals(object objToCompare)
        {
            return (objToCompare as Plane) != null &&
                   modelAirplane == (objToCompare as Plane).modelAirplane &&
                   maxSpeedAirplane == (objToCompare as Plane).maxSpeedAirplane &&
                   maxFlightDistanceAirplane == (objToCompare as Plane).maxFlightDistanceAirplane &&
                   maxLoadCapacityAirplane == (objToCompare as Plane).maxLoadCapacityAirplane;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            return (((hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(modelAirplane))
                * -1521134295 + maxSpeedAirplane.GetHashCode()) * hashCode * -1521134295 + maxFlightDistanceAirplane.GetHashCode())
                * hashCode * -1521134295 + maxLoadCapacityAirplane.GetHashCode();
        }

    }
}