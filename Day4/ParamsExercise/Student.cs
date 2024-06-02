public class Student {
    string[] studentNames = {"Ana","Budi","Caca"};
    public void FilterStudentNames(params int[] numbers) {
        for(int i = 0; i < studentNames.Length; i++) {
            foreach(int j in numbers)
            {
                if(i==j) {
                    System.Console.WriteLine(studentNames[i]);
                }
            }
        }
    }
}