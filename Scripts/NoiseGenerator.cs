using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public DrawType drawType;
    public ColorType colorType;

    [Header("Settings")]
    public Vector2Int mapSize;
    public float frequency;
    public float amplitude;
    public Vector2 offset;
    public bool useNoiseCurve;
    public AnimationCurve noiseCurve;

    [Header("Renderes")]
    public Mesh defaultMesh;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [Header("Components")]
    public HeightMapColorsHelper heightMapColorsHelper;

    public void generateNoise()
    {
        AnimationCurve curve = useNoiseCurve ? noiseCurve : null;
        float[,] sineNoise = Sine.generateSineNoise(mapSize, frequency, amplitude, offset, curve);
        HeightMapColor[] heightMapColors = heightMapColorsHelper.getHeightMapColor(colorType);
        Texture2D texture = TextureGenerator.generateTexture(mapSize, sineNoise, heightMapColors, amplitude);

        if(drawType == DrawType.NoiseMap)
        {
            visualizeNoiseTexture(texture);
        }
        else if(drawType == DrawType.HeightMap)
        {
            Mesh mesh = MeshGenerator.generateMesh(mapSize, sineNoise);
            visualizeNoiseMesh(texture, mesh);
        }
    }

    public void visualizeNoiseTexture(Texture2D texture)
    {
        meshRenderer.sharedMaterial.mainTexture = texture;
        meshRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        meshFilter.sharedMesh = defaultMesh;
    }

    public void visualizeNoiseMesh(Texture2D texture, Mesh mesh)
    {
        meshRenderer.sharedMaterial.mainTexture = texture;
        meshRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        meshFilter.sharedMesh = mesh;
    }
}
