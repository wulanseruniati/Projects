public static class Swapper {
    public static void Swap<T>(ref T x,ref T y) {
        //swapping values 
        T swap = x;
        x = y;
        y = swap;
    }
}