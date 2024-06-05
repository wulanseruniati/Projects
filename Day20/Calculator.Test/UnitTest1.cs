namespace Calculator.Test;
using CalculatorLib;
public class Tests
{
    //private CalculatorSimple calculator;
    private Person person;
    private GameController gameController;
    [SetUp]
    public void Setup()
    {
        //calculator = new CalculatorSimple();
        person = new Person();
    }
    

    [Test]
    public void AddPlayer_WhenValidColor_ReturnPlayerDictionary() {
        
        //Arrange
        var color = Color.Black;
        var player = new Player("Wulan");
        Dictionary<Color, IPlayer> expectation = new Dictionary<Color, IPlayer>();
        expectation.Add(color, player);
        //Action
        gameController.AddPlayer(player,color);
        var result = gameController._playerColors;
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [Test]
    public void GetFullName_WhenValidPerson_ReturnFullName() {
        /*
        var juned = new Person() { FirstName = "Junaidi", LastName = "Rico"}; 
        */
        //Arrange
        string expectation = "Junaidi Rico";
        //Action
        string result = person.GetFullName(new Person() { FirstName = "Junaidi", LastName = "Rico"});
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [Test]
    public void GetFullName_WhenCalledNull_ReturnFullName() {
        /*
        var juned = new Person() { FirstName = "Junaidi", LastName = "Rico"}; 
        */
        //Arrange
        //string expectation = null;
        //Action
        string result = person.GetFullName(null);
        //Assert
        Assert.IsNull(result);
    }

    /*[Test]
    public void Add_ReturnCorrectValue() {
        //Arrange
        int a = 2;
        int b = 4;
        int expectation = 6;
        //Action
        int result = calculator.Add(a,b);
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [TestCase(1,3,4)]
    [TestCase(7,8,15)]
    [TestCase(5,6,11)]  
    public void Add_ReturnCorrectValue_UsingTestCase(int a, int b, int expected)
    {
        int result = calculator.Add(a,b);

        Assert.AreEqual(expected, result);
    }
    [Test]
    public void SubstractNumber_ReturnCorrectValue() {
        //Arrange
        int a = 2;
        int b = 4;
        int expectation = -2;
        //Action
        int result = calculator.SubstractNumber(a,b);
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [TestCase(1,3,-2)]
    [TestCase(7,8,-1)]
    [TestCase(5,6,-1)]  
    public void SubstractNumber_ReturnCorrectValue_UsingTestCase(int a, int b, int expected)
    {
        int result = calculator.SubstractNumber(a,b);

        Assert.AreEqual(expected, result);
    }

    [TestCase(1,"1")]
    [TestCase(-1,"-1")]
    [TestCase(5,"5")]  
    public void ReverseMethod_ReturnCorrectValue_UsingTestCase(int a, string expected)
    {
        string result = calculator.ReverseMethod(a);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void ReverseWords_ReturnReverseWords() {
        //Arrange
        string a = "Wulan";
        string expectation = "naluW";
        //Action
        string result = calculator.ReverseWords(a);
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [Test]
    public void ReverseWords_WhenCalledEmptyStringReturnReverseWords() {
        //Arrange
        string a = "";
        string expectation = "";
        //Action
        string result = calculator.ReverseWords(a);
        //Assert
        Assert.AreEqual(expectation, result);
    }

    [Test]
    public void ReverseWords_WhenCalledNullReturnReverseWords() {
        //Arrange
        string a = null;
        string expectation = null;
        //Action
        string result = calculator.ReverseWords(a);
        //Assert
        Assert.AreEqual(expectation, result);
    }
    
    [TestCase("Selamat Pagi", "igaP tamaleS")]
    [TestCase("Budi","iduB")]
    public void ReverseWords_ReturnReverseWords_UsingTestCase(string a, string expected)
    {
        string result = calculator.ReverseWords(a);

        Assert.AreEqual(expected, result);
    }*/
}