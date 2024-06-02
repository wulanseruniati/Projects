public static class MethodExtensions {
    public static string ToUpper(this string input) {
        if(string.IsNullOrEmpty(input)) {
            return input;
        }
        else {
            return input.ToUpper();
        }
    }
}