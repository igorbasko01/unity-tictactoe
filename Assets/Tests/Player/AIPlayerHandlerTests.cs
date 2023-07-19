using NUnit.Framework;

[TestFixture]
public class AIPlayerHandlerTests {
    [Test]
    public void AIPlayerReceivesOnCurrentPlayerEvent() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        
        boardUIEventsHandler.CellClick(0);
        PlayerMark actualPlayerMark = PlayerMark.X;
        
        // Register to the OnCurrentPlayer event.
        gameManagerEvents.OnCurrentPlayer += (player) => {
            actualPlayerMark = player;
        };

        // Check that the player is the AI player.
        Assert.AreEqual(PlayerMark.O, actualPlayerMark);
    }
}