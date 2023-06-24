using NUnit.Framework;

[TestFixture]
public class GameManagerTests {
    [Test]
    public void GameManagerListensForOnPerformMoveEventFromHumanPlayer() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        gameManager.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void GameManagerPublishesOnValidMoveIfACellIsFree() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        gameManager.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void GameManagerWontPublishOnValidMoveIfCellIsOccupied() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        var numberOfInvocations = 0;
        gameManager.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
            numberOfInvocations++;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
    }

    [Test]
    public void SendCurrentPlayerEventOnGameStart() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var playerMark = default(PlayerMark);
        gameManager.OnCurrentPlayer += (nplayerMark) => {
            playerMark = nplayerMark;
        };
        gameManager.StartGame();
        Assert.AreEqual(PlayerMark.X, playerMark);
    }

    [Test]
    public void SwitchCurrentPlayerOnValidMove() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var playerMark = default(PlayerMark);
        gameManager.OnCurrentPlayer += (nplayerMark) => {
            playerMark = nplayerMark;
        };
        gameManager.StartGame();
        Assert.AreEqual(PlayerMark.X, playerMark);
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(PlayerMark.O, playerMark);
    }

    [Test]
    public void GameManagerWontPublishOnValidMoveIfPlayingPlayerNotCurrent() {
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler);
        BoardHandler boardHandler = new BoardHandler();
        GameManager gameManager = new GameManager(humanPlayerHandler, boardHandler);
        var x = -1;
        var y = -1;
        var playerMark = default(PlayerMark);
        var numberOfInvocations = 0;
        gameManager.OnValidMove += (nx, ny, nplayerMark) => {
            x = nx;
            y = ny;
            playerMark = nplayerMark;
            numberOfInvocations++;
        };
        boardUIEventsHandler.CellClick(0);
        Assert.AreEqual(0, x);
        Assert.AreEqual(0, y);
        Assert.AreEqual(PlayerMark.X, playerMark);
        Assert.AreEqual(1, numberOfInvocations);
        boardUIEventsHandler.CellClick(1);
        Assert.AreEqual(1, numberOfInvocations);  // still the same, means the event was not invoked
    }
}