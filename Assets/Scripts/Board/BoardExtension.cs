using UnityEngine;

public static class BoardExtension
{
    public static bool IsInside(this Contexts context, Vector2Int value)
    {
        return context.IsInside(value.x, value.y);
    }
    
    public static bool IsInside(this Contexts context, int x, int y)
    {
        IGameConfig config = context.config.gameConfig.value;
        Vector2Int boardSize = config.BoardSize;
        return x >= 0 && x < boardSize.x && y >= 0 && y < boardSize.y;
    }
}
