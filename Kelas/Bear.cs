namespace Hewan {
    class Bear()
    {
        public bool isWid;
        string? name {get; set;}
        string? color {get; set;}
        public double weight;
        public double height;

        //writing a line
        public void Walking()
        {
            Console.WriteLine("Bear walking");
        }
        
        //return BMI of the bear
        public double CalculateBMI()
        {
            return this.height/this.weight;
        }

        //greetings to the name of user
        public string Greetings(string nama)
        {
            return "Greetings to " + nama;
        }

        //writing a line
        public void Swimming()
        {
            Console.WriteLine("Bear swimming");
        }

        //return if the bear accepts food or not
        public bool AcceptingFood()
        {
            if(this.isWid == true)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}