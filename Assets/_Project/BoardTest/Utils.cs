using UnityEngine;

public static class Utils
{
    public static Color PlayerColorToRGB(PlayerColors color)
    {
        switch (color)
        {
            case PlayerColors.Blue:
                return Color.blue;
            case PlayerColors.Red:
                return Color.red;
            case PlayerColors.Green:
                return Color.green;
            case PlayerColors.Yellow:
                return Color.yellow;
            default:
                throw new System.ArgumentException("Invalid player color");
            
        }
    }
}
