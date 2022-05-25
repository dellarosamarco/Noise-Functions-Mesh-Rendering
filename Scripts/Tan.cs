using UnityEngine;

public class Tan : MonoBehaviour
{
    public static float[,] generateTanNoise(NoiseData noiseData, float frequency)
    {
        Vector2Int mapSize = noiseData.mapSize;
        Vector2 offset = noiseData.offset;
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        float amplitude = noiseData.amplitude;

        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] tanNoise = new float[xSize, ySize];

        float deg;
        for (int x = 0; x < xSize; x++)
        {
            deg = 1 + (offset.y * xSize + offset.x);
            for (int y = 0; y < ySize; y++)
            {
                float rad = deg * Mathf.PI / 180;
                if (noiseCurve != null)
                    tanNoise[x, y] = noiseCurve.Evaluate(Mathf.Tan(rad * frequency)) * amplitude;
                else
                    tanNoise[x, y] = Mathf.Tan(rad * frequency) * amplitude;
                deg += 1f;
            }
        }

        return tanNoise;
    }
}
