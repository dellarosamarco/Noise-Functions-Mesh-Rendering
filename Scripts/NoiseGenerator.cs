using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public NoiseType noiseType;
    public DrawType drawType;
    public ColorType colorType;

    [Header("Settings")]
    public int seed;
    public Vector2Int mapSize;
    public float frequency;
    public float amplitude;
    public Vector2 offset;
    public bool useNoiseCurve;
    public AnimationCurve noiseCurve;
    public int octaves;
    public Vector2 octaveRandomOffset;

    [Header("Worley Noise temp")]
    public Vector2Int chunks;
    public int pointsPerChunk;

    [Header("Renderers")]
    public Mesh defaultMesh;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [Header("Components")]
    public HeightMapColorsHelper heightMapColorsHelper;

    public void generateNoise()
    {
        UnityEngine.Random.InitState(seed);

        AnimationCurve curve = useNoiseCurve ? noiseCurve : null;
        float[,] noise;

        if (noiseType == NoiseType.Sine)
            noise = Sine.generateSineNoise(mapSize, frequency, amplitude, offset, octaves, octaveRandomOffset, curve);
        else if (noiseType == NoiseType.Tan)
            noise = Tan.generateTanNoise(mapSize, frequency, amplitude, offset, curve);
        else if (noiseType == NoiseType.Circles)
            noise = Circles.generateCirclesNoise(mapSize, frequency, amplitude, offset, octaves, octaveRandomOffset, curve);
        else if (noiseType == NoiseType.Worley)
            noise = Worley.generateWorleyNoise(mapSize, frequency, amplitude, chunks, pointsPerChunk);
        else
            noise = new float[0, 0];

        HeightMapColor[] heightMapColors = heightMapColorsHelper.getHeightMapColor(colorType);
        Texture2D texture = TextureGenerator.generateTexture(mapSize, noise, heightMapColors, amplitude);

        if(drawType == DrawType.NoiseMap)
        {
            visualizeNoiseTexture(texture);
        }
        else if(drawType == DrawType.HeightMap)
        {
            Mesh mesh = MeshGenerator.generateMesh(mapSize, noise);
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
