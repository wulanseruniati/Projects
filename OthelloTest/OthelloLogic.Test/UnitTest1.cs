namespace OthelloLogic.Test;
using OthelloLogic;
public class Tests
{
    private GameController _gameController;
    [SetUp]
    public void Setup()
    {
        _gameController = new();
    }
    //test if a position is valid
    [Test]
    public void IsInsideBoard_WhenValidPosition_ReturnTrue() {
        
        //Arrange
        int r = 6;
        int c = 3;
        bool expected = true;
        //Action
        var result = _gameController.IsInsideBoard(r,c);
        //Assert
        Assert.AreEqual(expected, result);
    }
    //test if the returned value is right
    [Test]
    public void OccupiedTilesByColor_WhenValidPosition_ReturnTrue() {
        
        //Arrange
        int r = 6;
        int c = 3;
        bool expected = true;
        //Action
        var result = _gameController.IsInsideBoard(r,c);
        //Assert
        Assert.AreEqual(expected, result);
    }
    //test if the disc is added
    [Test]
    public void UpdateDiscCount_DiscCountChanged_ReturnTrue() {
        
        //Arrange
        Color moveColor = Color.Black;
        int outflankedCount = 1;
        int expectedBlack = 4;
        int expectedWhite = 1;
        
        //Action
        _gameController.UpdateDiscCount(moveColor, outflankedCount);
        int discBlack = _gameController.GetDiscCountByKey(Color.Black);
        int discWhite = _gameController.GetDiscCountByKey(Color.White);
        //Assert
        Assert.IsTrue(discBlack == expectedBlack && discWhite == expectedWhite);
    }
    //test if the current player is changed
    [Test]
    public void ChangeCurrentPlayer_AfterMethodCalled_CurrentColorChanged() {
        
        //Arrange
        //default is black
        Color expected = Color.White; //expected current color after the method run
        //Action
        _gameController.ChangeCurrentPlayer();
        Color result = _gameController.CurrentColor; //check current color
        //Assert
        Assert.AreEqual(expected, result);
    }
    //test if the board is fully occupied
    [Test]
    public void IsFullyOccupied_BoardContainsDefaultPieces_ReturnFalse() {
        
        //Arrange
        //the board is populated by default starting position;
        //Action
        var result = _gameController.IsFullyOccupied();
        //Assert
        Assert.IsFalse(result);
    }
    //test if the game is over
    [Test]
    public void IsGameOver_WhenGameStateIsRunning_ReturnFalse() {
        
        //Arrange
        //the game is GameState.INIT;
        //Action
        var result = _gameController.IsGameOver();
        //Assert
        Assert.IsFalse(result);
    }
}