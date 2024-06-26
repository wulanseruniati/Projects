```mermaid---
title: Othello Class Diagram
---
classDiagram

%% Relationships
GameController "1" *-- "1" FileManager
GameController "1" *-- "1" IBoard
GameController "1" *-- "2" IPlayer 
GameController "1" *-- "4..64" IDisc
GameController "1" *-- "1..*" Position
GameController -- GameState
GameController -- GameOverOption
GameController -- Color
IPlayer <|.. Player
IDisc <|.. Disc
IBoard <|.. Board
Disc -- Color

class GameState {
    <<enumeration>>
    GAME_STARTED,
    GAME_END
}

class Color {
    <<enumeration>>
    Black
    White
}

class GameOverOption {
    <<enumeration>>
    Exit,
    Restart
}

class Position {
    <<struct>>
    +Row ~get, private set~
    +Column ~get, private set~
    +Position(int row, int column)
    +SetPosition(int row, int column)
    +Equals(object obj) : bool
    +GetHashCode() : int
    +operator==(Position left, Position right)
    +operator!=(Position left, Position right)
}

class GameController {
    +int maxPlayer readonly
    +int boardsize const
    +GameState CurrentGameState ~get; private set~
    +Color CurrentColor ~get; private set~
    +Color GameWinner ~get; private set~
    +Board Board ~get; private set~
    -Dictionary~Color, IPlayer~ _playerColors
    -Dictionary~IBoard, List< IPlayer >~ _playersOnBoard
    -Dictionary~Color, int~ _discCount
    -Dictionary~Position, List< Position >~ _legalMoves
    -Dictionary~IBoard,IDisc[,]~ _discOnBoard
    +Action~string, string~ WriteLogMessage
    +Action~string, string~ AppendLogMessage
    +Func~string, string~ ReadLogMessage
    +Action < Dictionary,~Color,IPlayer~ > AppendPlayerColor
    +Func < string, Dictionary, ~Color,Player~ > LoadPlayerColor
    +GameController(int maxPlayer=2)
    +GameController(Color currentColor, int maxPlayer = 2)
    %%Getter and Setter
    +GetAllPlayersColor() : Dictionary~Color,IPlayer~
    +GetPlayersColor(Color color) : IPlayer
    +SetPlayerColor(Dictionary~Color,IPlayer~) : bool
    +GetAllPlayersOnBoard() : Dictionary~Position, List< Position >~
    +GetPlayersOnBoard(IBoard board) : List~IPlayer~
    +SetPlayersOnBoard(Dictionary< IBoard, List~IPlayer~ > playersOnBoard)
    +GetAllDiscsOnBoard() : Dictionary~IBoard, IDisc[,]~
    +GetDiscsOnBoard(IBoard board) : IDisc[,]
    +SetDiscsOnBoard(Dictionary~IBoard, IDisc[,]~ value)
    +GetDiscCount() : Dictionary~Color, int~
    +GetDiscCountByKey(Color color) : int
    +SetDiscCount(Dictionary~Color, int~)
    +GetLegalMoves() : Dictionary~Position, List< Position >~
    +GetLegalMovesByKey(Position position) : List~Position~
    +SetLegalMoves(Dictionary~Position, List< Position >~)
    %%Other methods
    +AddPlayer(IPlayer newPlayer, Color color) : bool
    -CapturedInDirections(Position position, Color color, int rDelta, int cDelta) : List~Position~
    -Captured(Position position, Color color) : List~Position~
    -IsMoveLegal(Color color, Position position, out List~Position~ outflanked) : bool
    -FindLegalMoves(Color color) : Dictionary< Position,List~Position~ > 
    -IsInsideBoard(int r, int c) : bool
    +MakeMove(Position position)
    +OccupiedTiles() : IEnumerable~Position~
    -FlipDiscs(List~Position~ positions)
    -UpdateDiscCount(Color moveColor, int outflankedCount)
    -ChangeCurrentPlayer()
    -SetGameWinner() : Color
    -ChangeTurn()
    -IsFullyOccupied() : bool
    -IsGameOver() : bool
}

class IPlayer {
    <<interface>>
    +Guid PlayerId ~get;~
    +string PlayerName ~get;~
}

class Player {
    +Guid PlayerId ~get; private set;~
    +string PlayerName ~get; private set;~
    +Player(string playerName)
}

class IBoard { 
    +Guid BoardId ~get; ~
}

class Board { 
    +Guid BoardId ~get; private set;~
    +Board()
}

class IDisc {
    +Guid DiscId ~get; ~
    +Color DiscColor ~get; ~
    +SetColor(Color color)
}

class Disc {
    +Guid DiscId ~get; private set~
    +Color DiscColor ~get; private set~
    +Copy() : Disc
    +Disc(Color discColor)
    +SetColor(Color color)
}

class FileManager {
    +WriteLog(string path, string logMessage)
    +AppendLog(string path, string logMessage)
    +ReadLog(string path) : string
    +CreatePlayerData(Dictionary~Color, IPlayer~ playerColor)
    +LoadPlayerData(string path) : Dictionary~Color, Player~
    +CreateDiscData(Disc[,] discs)
    +LoadDiscData(string path) : Disc[,]
    +CreateCurrentColorData(Color currentColor)
    +LoadCurrentColorData(string path) : Color
    -WriteJsonToFile(string filePath, string json)
    -ReadJsonFromFile(string filePath) : string
    -DeserializeJsonTo2DArray(string serializedJson) : Disc[,]
}
```