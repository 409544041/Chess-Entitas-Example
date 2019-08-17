using UnityEngine;

public static class BoardExtension
{
    public static bool IsBound(this Contexts context, Vector2Int value)
    {
        IGameConfig config = context.config.gameConfig.value;
        Vector2Int boardSize = config.BoardSize;
        return value.x >= 0 && value.x < boardSize.x && value.y >= 0 && value.y < boardSize.y;
    }
}
