using UnityEngine;

public class HeightMapColorsHelper : MonoBehaviour
{
    public HeightMapColors sineNoise;

    public HeightMapColor[] getHeightMapColor(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.SineNoise:
                return sineNoise.colors;
        }

        return sineNoise.colors;
    }
}
