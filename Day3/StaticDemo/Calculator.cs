public static class Calculator {
    private static double pi = 3.14;

    public static double CalculateCircleArea(double diameter) {
        return pi*diameter/2;
    }

    public static double Add(double num1, double num2) {
        return num1 + num2;
    }

    public static double Substract(double num1, double num2) {
        return num1 - num2;
    }

    public static double Multiplication(double num1, double num2) {
        return num1 * num2;
    }
    public static double DividedBy(double num1, double num2) {
        return num1 / num2;
    }
}