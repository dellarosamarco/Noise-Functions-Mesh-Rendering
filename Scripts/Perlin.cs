using UnityEngine;

public class Perlin : MonoBehaviour
{
    public static float[,] generatePerlinNoise(NoiseData noiseData, PerlinNoiseData perlinNoiseData)
    {
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;
        float frequency = perlinNoiseData.frequency;
        float scale = perlinNoiseData.scale;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float[,] perlinNoise = new float[xSize, ySize];

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                float noiseHeight = Mathf.PerlinNoise(x * frequency / scale,y * frequency / scale) * amplitude;

                if (noiseCurve != null)
                    perlinNoise[x, y] = noiseCurve.Evaluate(noiseHeight);
                else
                    perlinNoise[x, y] = noiseHeight;
            }
        }

        return perlinNoise;
    }
}
