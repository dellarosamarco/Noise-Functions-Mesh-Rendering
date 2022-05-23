using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(Vector2Int mapSize, float frequency, float amplitude, Vector2 offset)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float sineIndex = 1 + (offset.y * xSize + offset.x);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                sineNoise[x, y] = Mathf.Sin(sineIndex * frequency) * amplitude;
                sineIndex += 1;
            }
        }

        return sineNoise;
    }
}
