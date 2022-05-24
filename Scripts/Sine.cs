using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(Vector2Int mapSize, float frequency, float amplitude, Vector2 offset, AnimationCurve noiseCurve=null)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float sineIndex = 1 + (offset.y * xSize + offset.x);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if(noiseCurve != null)
                    sineNoise[x, y] = noiseCurve.Evaluate(Mathf.Sin(sineIndex * frequency)) * amplitude;
                else
                    sineNoise[x, y] = Mathf.Sin(sineIndex * frequency) * amplitude;
                sineIndex += 1;
            }
        }

        return sineNoise;
    }
}
