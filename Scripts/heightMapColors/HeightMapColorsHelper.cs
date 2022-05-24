using UnityEngine;

public class HeightMapColorsHelper : MonoBehaviour
{
    public HeightMapColors sineNoise;
    public HeightMapColors rainbow;

    public HeightMapColor[] getHeightMapColor(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.SineNoise:
                return sineNoise.colors;
            case ColorType.Rainbow:
                return rainbow.colors;
        }

        return sineNoise.colors;
    }
}
