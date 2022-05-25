using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(NoiseData noiseData, SineNoiseData sineNoiseData)
    {
        Vector2Int mapSize = noiseData.mapSize;
        Vector2 offset = noiseData.offset;
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        float frequency = sineNoiseData.frequency;
        int octaves = sineNoiseData.octaves;
        Vector2 octaveRandomOffset = sineNoiseData.octaveRandomOffset;

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
