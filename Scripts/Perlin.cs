using UnityEngine;

public class Perlin : MonoBehaviour
{
    public static float[,] generatePerlinNoise(NoiseData noiseData, PerlinNoiseData perlinNoiseData)
    {
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        float frequency = perlinNoiseData.frequency;
        float scale = perlinNoiseData.scale;
        int octaves = perlinNoiseData.octaves;
        float persistance = perlinNoiseData.persistance;
        float lacunarity = perlinNoiseData.lacunarity;
        Vector2 offset = noiseData.offset;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float lowestNoiseHeight = 0f;
        float highestNoiseHeight = 0f;

        float[,] perlinNoise = new float[xSize, ySize];

        Vector2[] octavesOffsets = new Vector2[octaves];
        System.Random rd = new System.Random();
        for (int i = 0; i < octavesOffsets.Length; i++)
        {
            float xOffset = Random.Range(-100000,100000) + offset.x;
            float yOffset = Random.Range(-100000, 100000) + offset.y;
            octavesOffsets[i] = new Vector2(xOffset, yOffset);
        }

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float octaveFrequency = frequency;
                float octaveAmplitude = amplitude;
                float noiseHeight = 0f;

                for (int i = 0; i < octaves; i++)
                {
                    float xOctave = x / scale * octaveFrequency + octavesOffsets[i].x;
                    float yOctave = y / scale * octaveFrequency + octavesOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(xOctave, yOctave) * 2 - 1;
                    noiseHeight += perlinValue * octaveAmplitude;

                    octaveAmplitude *= persistance;
                    octaveFrequency *= lacunarity;
                }

                if (noiseCurve != null)
                    perlinNoise[x, y] = noiseCurve.Evaluate(noiseHeight);
                else
                    perlinNoise[x, y] = noiseHeight;

                if (noiseHeight > highestNoiseHeight)
                {
                    highestNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < lowestNoiseHeight)
                {
                    lowestNoiseHeight = noiseHeight;
                }
            }
        }

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                perlinNoise[x, y] = Mathf.InverseLerp(lowestNoiseHeight, highestNoiseHeight, perlinNoise[x, y]) * amplitude;
            }
        }

        return perlinNoise;
    }
}
