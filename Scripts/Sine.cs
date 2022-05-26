using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(NoiseData noiseData, SineNoiseData sineNoiseData, Vector2 persistance, float lacunarity)
    {
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        float frequency = sineNoiseData.frequency;
        int octaves = sineNoiseData.octaves;
        Vector2 octaveRandomOffset = sineNoiseData.octaveRandomOffset;

        float lowestNoiseHeight = 0f;
        float highestNoiseHeight = 0f;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float sineIndex = 1 + (noiseData.offset.y * xSize + noiseData.offset.x);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float octaveAmplitude = amplitude;
                float octaveFrequency = frequency;

                for (int i = 0; i < octaves; i++)
                {
                    sineIndex += Random.Range(octaveRandomOffset.x, octaveRandomOffset.y);
                    octaveAmplitude *= Random.Range(persistance.x,persistance.y);
                    octaveFrequency *= lacunarity;
                }

                float noiseHeight = Mathf.Sin(sineIndex * octaveFrequency) * octaveAmplitude;

                if (noiseCurve != null)
                    sineNoise[x, y] = noiseCurve.Evaluate(noiseHeight);
                else
                    sineNoise[x, y] = noiseHeight;

                if (noiseHeight > highestNoiseHeight)
                {
                    highestNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < lowestNoiseHeight)
                {
                    lowestNoiseHeight = noiseHeight;
                }

                sineIndex += 1;
            }
        }

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                sineNoise[x, y] = Mathf.Sin(Mathf.InverseLerp(lowestNoiseHeight, highestNoiseHeight, sineNoise[x, y])) * amplitude;
            }
        }

        return sineNoise;
    }
}
