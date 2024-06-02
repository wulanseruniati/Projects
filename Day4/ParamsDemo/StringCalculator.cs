public class StringCalculator {
    public int Add(params string[] numberstrings) {
        int sum = 0;
        foreach(string i in numberstrings) {
            sum += int.Parse(i);
        }
        return sum;
    }
}