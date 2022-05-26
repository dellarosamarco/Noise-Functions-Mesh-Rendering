using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public NoiseType noiseType;
    public DrawType drawType;
    public ColorType colorType;

    public NoiseData noiseData;
    public SineNoiseData sineNoiseData;
    public TanNoiseData tanNoiseData;
    public CircleNoiseData circlesNoiseData;
    public WorleyNoiseData worleyNoiseData;

    [Header("Settings")]
    public int seed;

    [Header("Renderers")]
    public Mesh defaultMesh;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [Range(0f, 1.5f)]
    public float xPersistance;
    [Range(0f, 1.5f)]
    public float yPersistance;
    public float lacunarity;

    [Header("Components")]
    public HeightMapColorsHelper heightMapColorsHelper;

    public void generateNoise()
    {
        UnityEngine.Random.InitState(seed);

        float[,] noise;

        if (noiseType == NoiseType.Sine)
            noise = Sine.generateSineNoise(noiseData, sineNoiseData, new Vector2(xPersistance, yPersistance), lacunarity);
        else if (noiseType == NoiseType.Tan)
            noise = Tan.generateTanNoise(noiseData, tanNoiseData);
        else if (noiseType == NoiseType.Circles)
            noise = Circles.generateCirclesNoise(noiseData, circlesNoiseData);
        else if (noiseType == NoiseType.Worley)
            noise = Worley.generateWorleyNoise(noiseData, worleyNoiseData);
        else
            noise = new float[0, 0];

        HeightMapColor[] heightMapColors = heightMapColorsHelper.getHeightMapColor(colorType);
        Texture2D texture = TextureGenerator.generateTexture(noiseData.mapSize, noise, heightMapColors, noiseData.amplitude);

        if(drawType == DrawType.NoiseMap)
        {
            visualizeNoiseTexture(texture);
        }
        else if(drawType == DrawType.HeightMap)
        {
            Mesh mesh = MeshGenerator.generateMesh(noiseData.mapSize, noise);
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
