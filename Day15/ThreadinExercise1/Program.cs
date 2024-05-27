class Program
{
    static void Main()
    {
        int returnValue = 0; //output variable with initialization
        Thread thread = new Thread(
            () =>
            {
                returnValue = PrintRandom(); //calling the method PrintRandom
            }
        );
        Thread thread2 = new(() => LambdaAction());
        Thread thread3 = new(() => PrintId());
        thread.Name = "RandomNumber";
        thread2.Name = "RandomAction";
        thread.IsBackground = true;
        thread.Start();
        thread2.Start();
        thread3.Start();
        //thread and thread2 are joined
        thread.Join();
        Console.WriteLine("Return value of a method : " + returnValue);
        thread2.Join();
        thread3.Join();
        object? value = null; // Used to store the return value
        var threadWithReturn = new Thread(
          () =>
          {
              value = "Anonymous method with return value"; // anonymous method with return value
          });
        threadWithReturn.Start();
        threadWithReturn.Join();
        Console.WriteLine(value); // Use the return value here

        System.Console.WriteLine("Main thread " + Thread.CurrentThread.ManagedThreadId + " ended");

        int PrintRandom()
        {
            Func<int> getRandomNumber = () => new Random().Next(1, 100);
            return getRandomNumber();
            //normal: Func<int> getRandomNumber = new Func<int>(RandomNumber);
            //System.Console.WriteLine("Thread with name " + Thread.CurrentThread.Name + " is generating random number : " + getRandomNumber.Invoke());
        }

        /*normal: static int RandomNumber() {
            return new Random().Next(1,100);
        }*/
        void LambdaAction()
        {
            Action<string> printAction = (i) => System.Console.WriteLine(i);
            printAction.Invoke("Thread with name " + Thread.CurrentThread.Name + " is action with lambda");
        }
        void PrintId()
        {
            System.Console.WriteLine("Thread with id: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
        }
    }
}