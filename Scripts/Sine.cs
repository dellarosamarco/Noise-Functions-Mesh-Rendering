using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(Vector2Int mapSize)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float sineIndex = 0;
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                sineNoise[x, y] = Mathf.Sin(sineIndex);
                sineIndex++;
            }
        }

        return sineNoise;
    }
}
