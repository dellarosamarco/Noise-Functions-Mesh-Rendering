using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D generateTexture(Vector2Int mapSize, float[,] noise, HeightMapColor[] heightMapColors, float amplitude)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        Texture2D texture = new Texture2D(xSize, ySize);

        float[,] normalizedNoise = normalizeNoise(noise);

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Color color = new Color(normalizedNoise[x, y], normalizedNoise[x, y], normalizedNoise[x, y]);

                for (int i = 0; i < heightMapColors.Length; i++)
                {
                    if(normalizedNoise[x, y] <= heightMapColors[i].height)
                    {
                        color = heightMapColors[i].color;
                        break;
                    }
                }

                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;

        return texture;
    }

    private static float[,] normalizeNoise(float[,] noise)
    {
        float highestValue = 0f;
        float lowestValue = 0f;

        int xLength = noise.GetLength(0);
        int yLength = noise.GetLength(1);

        float[,] normalizedNoise = new float[xLength, yLength];

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                if(noise[x,y] > highestValue)
                {
                    highestValue = noise[x, y];
                }
                else if(noise[x,y] < lowestValue)
                {
                    lowestValue = noise[x, y];
                }
            }
        }

        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                normalizedNoise[x, y] = noise[x, y] / highestValue;
            }
        }

        return normalizedNoise;
    } 
}
