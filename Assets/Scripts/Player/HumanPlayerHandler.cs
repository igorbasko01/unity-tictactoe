using System;
public class HumanPlayerHandler {
    public event Action<int, int, PlayerMark> OnPerformMove;
    public HumanPlayerHandler(BoardUIEventsHandler boardUIEventsHandler) {

    }
}

public enum PlayerMark {
    X,
    O
}