using UnityEngine;

public class Tan : MonoBehaviour
{
    public static float[,] generateTanNoise(Vector2Int mapSize, float frequency, float amplitude, Vector2 offset, AnimationCurve noiseCurve = null)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] tanNoise = new float[xSize, ySize];

        float deg = 1 + (offset.y * xSize + offset.x);
        for (int x = 0; x < xSize; x++)
        {
            deg = 1 + (offset.y * xSize + offset.x);
            for (int y = 0; y < ySize; y++)
            {
                var rad = deg * Mathf.PI / 180;
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
