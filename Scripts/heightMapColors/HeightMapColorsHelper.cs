using UnityEngine;

public class HeightMapColorsHelper : MonoBehaviour
{
    public HeightMapColors sineNoise;
    public HeightMapColors rainbow;
    public HeightMapColors _default;

    public HeightMapColor[] getHeightMapColor(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.SineNoise:
                return sineNoise.colors;
            case ColorType.Rainbow:
                return rainbow.colors;
            case ColorType.Default:
                return _default.colors;
        }

        return sineNoise.colors;
    }
}
