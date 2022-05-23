using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(Vector2Int mapSize)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                sineNoise[x, y] = Random.Range(0f, 1f);
            }
        }

        return sineNoise;
    }
}
