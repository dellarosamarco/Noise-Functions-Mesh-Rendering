using UnityEngine;

public static class Sine
{
    public static float[,] generateSineNoise(NoiseData noiseData, SineNoiseData sineNoiseData)
    {
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        float frequency = sineNoiseData.frequency;
        int octaves = sineNoiseData.octaves;
        Vector2 octaveRandomOffset = new Vector2(sineNoiseData.xOctaveOffset, sineNoiseData.yOctaveOffset);
        float xPersistance = sineNoiseData.xPersistance;
        float yPersistance = sineNoiseData.yPersistance;
        Vector2 trajectoryRange = new Vector2(sineNoiseData.trajectory, sineNoiseData.trajectory * -1);
        float maxTrajectoryValue = sineNoiseData.maxTrajectory;

        float lowestNoiseHeight = 0f;
        float highestNoiseHeight = 0f;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float[,] sineNoise = new float[xSize, ySize];

        float trajectory = 0f;

        float sineIndex = 1 + (noiseData.offset.y * xSize + noiseData.offset.x);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float octaveAmplitude = amplitude;
                float octaveFrequency = frequency;

                for (int i = 0; i < octaves; i++)
                {
                    if(trajectory < maxTrajectoryValue)
                        trajectory += Random.Range(trajectoryRange.x, trajectoryRange.y);

                    sineIndex += Random.Range(octaveRandomOffset.x, octaveRandomOffset.y) + trajectory;
                    octaveAmplitude *= Random.Range(xPersistance,yPersistance);
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
