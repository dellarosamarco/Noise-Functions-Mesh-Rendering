using UnityEngine;

public class Tan : MonoBehaviour
{
    public static float[,] generateTanNoise(NoiseData noiseData, TanNoiseData tanNoiseData)
    {
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        int octaves = tanNoiseData.octaves;
        Vector2 randomOctavesOffset = tanNoiseData.octaveRandomOffset;

        int xSize = noiseData.mapSize.x;
        int ySize = noiseData.mapSize.y;

        float frequency = tanNoiseData.frequency;
        float amplitude = noiseData.amplitude;

        float[,] tanNoise = new float[xSize, ySize];

        float deg;
        for (int x = 0; x < xSize; x++)
        {
            deg = 1 + (noiseData.offset.y * xSize + noiseData.offset.x);
            for (int y = 0; y < ySize; y++)
            {

                for (int i = 0; i < octaves; i++)
                {
                    deg += Random.Range(randomOctavesOffset.x, randomOctavesOffset.y);
                }

                float rad = deg * Mathf.PI / 180;

                float noiseHeight = Mathf.Tan(rad * frequency);

                if (noiseCurve != null)
                    tanNoise[x, y] = noiseCurve.Evaluate(noiseHeight) * amplitude;
                else
                    tanNoise[x, y] = noiseHeight * amplitude;
                deg += 1f;
            }
        }

        return tanNoise;
    }
}
