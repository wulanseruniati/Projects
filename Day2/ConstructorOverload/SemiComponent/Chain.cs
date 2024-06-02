namespace SemiComponent {
    public class Chain
    {
        public string? chainType;
        public float chainWeight;
        
        public Chain(string tipe)
        {
            chainType = tipe;
        }

        //overload
        public Chain(string tipe, float chainWeight)
        {
            chainType = tipe;
            this.chainWeight = chainWeight;
        }

        public float calculateWeight(int quantity)
        {
            return quantity * chainWeight;
        }
    }
}