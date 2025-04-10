using UnityEngine;

public class GameController{
    private static int collectableCount;

    public static bool gameOver{
        get { return collectableCount <= 0; }
    }

    public static void Init()
    {
        collectableCount = 3;
    }

    public static void Collect()
    {
        collectableCount--;
    }
}
