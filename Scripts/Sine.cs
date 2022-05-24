using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(
        Vector2Int mapSize, 
        float frequency, 
        float amplitude, 
        Vector2 offset, 
        int octaves, 
        Vector2 octaveRandomOffset,
        AnimationCurve noiseCurve=null
    )
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float sineIndex = 1 + (offset.y * xSize + offset.x);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int i = 0; i < octaves; i++)
                {
                    sineIndex += Random.Range(octaveRandomOffset.x, octaveRandomOffset.y);
                }

                if (noiseCurve != null)
                    sineNoise[x, y] = noiseCurve.Evaluate(Mathf.Sin(sineIndex * frequency)) * amplitude;
                else
                    sineNoise[x, y] = Mathf.Sin(sineIndex * frequency) * amplitude;
                sineIndex += 1;
            }
        }

        return sineNoise;
    }
}
