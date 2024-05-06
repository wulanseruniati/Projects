namespace Hewan {
    class Bear()
    {
        public bool isWid;
        string? name {get; set;}
        string? color {get; set;}
        public double weight;
        public double height;

        public void Walking()
        {
            Console.WriteLine("Bear walking");
        }
        
        public double CalculateBMI()
        {
            return this.height/this.weight;
        }

        public string Greetings(string nama)
        {
            return "Greetings to " + nama;
        }

        public void Swimming()
        {
            Console.WriteLine("Bear swimming");
        }

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