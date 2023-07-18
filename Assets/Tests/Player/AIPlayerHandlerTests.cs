using NUnit.Framework;

[TestFixture]
public class AIPlayerHandlerTests {
    [Test]
    public void AIPlayerReceivesOnCurrentPlayerEvent() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        GameManager gameManager = new GameManager(new HumanPlayerHandler(boardUIEventsHandler), new BoardHandler(), gameManagerEvents);
        
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