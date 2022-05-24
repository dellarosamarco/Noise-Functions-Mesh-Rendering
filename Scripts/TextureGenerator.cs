using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D generateTexture(Vector2Int mapSize, float[,] noise, HeightMapColor[] heightMapColors, float amplitude)
    {
        int xSize = mapSize.x;
        int ySize = mapSize.y;

        Texture2D texture = new Texture2D(xSize, ySize);

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Color color = Color.Lerp(Color.black, Color.white, noise[x, y]);
                for (int i = 0; i < heightMapColors.Length; i++)
                {
                    if(noise[x, y] < heightMapColors[i].height * amplitude)
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
}
