using UnityEngine;

public static class Circles
{
    public static float[,] generateCirclesNoise(NoiseData noiseData, CircleNoiseData circlesNoiseData)
    {
        Vector2 offset = noiseData.offset;
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        int octaves = circlesNoiseData.octaves;
        float frequency = circlesNoiseData.frequency;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float[,] circlesNoise = new float[xSize, ySize];

        offset.x -= noiseData.mapSize.x / 2f;
        offset.y -= noiseData.mapSize.y / 2f;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float xOctave = x;
                float yOctave = y;
                for (int i = 0; i < octaves; i++)
                {
                    xOctave += Random.Range(circlesNoiseData.octaveRandomOffset.x, circlesNoiseData.octaveRandomOffset.y);
                    yOctave += Random.Range(circlesNoiseData.octaveRandomOffset.x, circlesNoiseData.octaveRandomOffset.y);
                }

                if (noiseCurve != null)
                    circlesNoise[x, y] = noiseCurve.Evaluate(Mathf.Sin(Mathf.Sqrt(Mathf.Pow(xOctave + offset.x, 2f) + Mathf.Pow(yOctave + offset.y, 2f)) * frequency)) * amplitude;
                else
                    circlesNoise[x, y] = Mathf.Sin(Mathf.Sqrt(Mathf.Pow(xOctave + offset.x, 2f) + Mathf.Pow(yOctave + offset.y, 2f)) * frequency) * amplitude;
            }
        }

        return circlesNoise;
    }
}
