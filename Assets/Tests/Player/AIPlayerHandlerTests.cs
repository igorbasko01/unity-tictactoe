using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class AIPlayerHandlerTests {
    [Test]
    public void AIPlayerPerformsAMove() {
        GameManagerEvents gameManagerEvents = new GameManagerEvents();
        PlayerEvents playerEvents = new PlayerEvents();
        BoardHandlerEvents boardHandlerEvents = new BoardHandlerEvents();
        BoardUIEventsHandler boardUIEventsHandler = new BoardUIEventsHandler();
        BoardHandler boardHandler = new BoardHandler(boardHandlerEvents);
        HumanPlayerHandler humanPlayerHandler = new HumanPlayerHandler(boardUIEventsHandler, playerEvents);
        AIPlayerHandler aiPlayerHandler = new AIPlayerHandler(gameManagerEvents, boardHandler, playerEvents);
        GameManager gameManager = new GameManager(playerEvents, boardHandler, gameManagerEvents);
        PlayerMark actualPlayerMark = PlayerMark.X;
        
        gameManager.StartGame();
        
        // Register to the OnPerformMove event.
        playerEvents.OnPerformMove += (x, y, playerMark) => {
            // Check that at least once the AI player performed a move.
            if (playerMark != PlayerMark.O) {
                return;
            }
            actualPlayerMark = playerMark;
        };

        boardUIEventsHandler.CellClick(0);

        // Check that the player is the AI player.
        Assert.AreEqual(PlayerMark.O, actualPlayerMark);
    }
}