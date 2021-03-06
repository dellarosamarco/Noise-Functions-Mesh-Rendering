using System.Collections.Generic;
using UnityEngine;

public class Worley : MonoBehaviour
{
    public static float[,] generateWorleyNoise(NoiseData noiseData, WorleyNoiseData worleyNoiseData)
    {
        Vector2Int mapSize = noiseData.mapSize;
        AnimationCurve noiseCurve = noiseData.useNoiseCurve ? noiseData.noiseCurve : null;
        Vector2 randomHeightOffset = worleyNoiseData.randomHeightOffset;
        float amplitude = noiseData.amplitude;
        bool calculateSine = worleyNoiseData.calculateSine;

        // replace with onvalidate 
        if (worleyNoiseData.chunks.x == 0 || worleyNoiseData.chunks.y == 0) return new float[,] { };

        int xSize = mapSize.x;
        int ySize = mapSize.y;

        float[,] worleyNoise = new float[xSize, ySize];

        List<Vector2> points = generateWorleyChunksPoints(mapSize, worleyNoiseData.chunks, worleyNoiseData.pointsPerChunk, worleyNoiseData.spawnRate);
        Vector2 pixelPosition = Vector2.zero;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                pixelPosition.x = x;
                pixelPosition.y = y;

                float minDistance = mapSize.x * mapSize.y;

                for (int i = 0; i < points.Count; i++)
                {
                    float distance = Vector2.Distance(pixelPosition, points[i]);

                    if (distance < minDistance) minDistance = distance + Random.Range(randomHeightOffset.x, randomHeightOffset.y);
                }

                float worleyNoiseheight = (
                    calculateSine ? Mathf.Sin(minDistance) * amplitude :
                    minDistance * amplitude
                );

                if(noiseCurve != null)
                {
                    worleyNoise[x, y] = noiseCurve.Evaluate(worleyNoiseheight) * amplitude;
                }
                else
                {
                    worleyNoise[x, y] = worleyNoiseheight;
                }
            }
        }

        return worleyNoise;
    }

    private static List<Vector2> generateWorleyChunksPoints(Vector2Int mapSize, Vector2Int chunks, int pointsPerChunk, float spawnRate)
    {
        List<Vector2> points = new List<Vector2>();

        int xSize = mapSize.x;
        int ySize = mapSize.y;

        int xChunkSize = (int)(mapSize.x / chunks.x);
        int yChunkSize = (int)(mapSize.y / chunks.y);

        Vector2 pointPosition = Vector2.zero;

        for (int x = 0; x < xSize; x+=xChunkSize)
        {
            for (int y = 0; y < ySize; y+=yChunkSize)
            {
                for (int i = 0; i < pointsPerChunk; i++)
                {
                    if(Random.Range(0f,100f) < spawnRate)
                    {
                        pointPosition.x = Random.Range(x, x + xChunkSize);
                        pointPosition.y = Random.Range(y, y + yChunkSize);

                        points.Add(pointPosition);
                    }
                }
            }
        }

        return points;
    }
}
