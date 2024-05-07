namespace mobil{
    public class Car {

        public string? carType {get; set;}
        public string? brand;
        public double speed;
        public string? tyreType;
        public bool isObsolete;

        //overloading 3 parameter
        public Car(string carType, string brand, bool isObsolete) {
            this.carType = carType;
            this.brand = brand;
            this.isObsolete = isObsolete;
        }

        public Car(string carType, string brand, bool isObsolete, double speed) {
            this.carType = carType;
            this.brand = brand;
            this.isObsolete = isObsolete;
            this.speed = speed;
        }

        public void startingEngine()
        {
            if(isObsolete == true)
            {
                Console.WriteLine("Failed to start engine of " + brand + ". Tee-hee");
            }
            else 
            {
                Console.WriteLine("Engine of " + brand + " started.");
            }
        }

        public double returnTimeNeeded(double distance)
        {
            return distance/speed;
        }

        public double returnTimeNeeded(double distance, bool isRaining)
        {
            if(isRaining)
            {
                return distance/(speed/2);
            }
            else 
            {
                return distance/speed;
            }
        }
    }
}