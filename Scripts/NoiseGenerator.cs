using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public int seed;

    public NoiseType noiseType;
    public DrawType drawType;
    public ColorType colorType;

    public NoiseData noiseData;
    public SineNoiseData sineNoiseData = new SineNoiseData() { 
        frequency=0.25f, 
        octaves=1,
        xOctaveOffset=0f,
        yOctaveOffset=1f,
        xPersistance=1, 
        yPersistance=1,
        trajectory=0f,
        maxTrajectory=0f
    };

    public TanNoiseData tanNoiseData;
    public CircleNoiseData circlesNoiseData;
    public BumpsNoiseData bumpsNoiseData;
    public WorleyNoiseData worleyNoiseData;
    public PerlinNoiseData perlinNoiseData;

    [Header("Renderers")]
    public Mesh defaultMesh;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [Header("Components")]
    public HeightMapColorsHelper heightMapColorsHelper;

    public void generateNoise()
    {
        UnityEngine.Random.InitState(seed);

        float[,] noise;

        if (noiseType == NoiseType.Sine)
            noise = Sine.generateSineNoise(noiseData, sineNoiseData);
        else if (noiseType == NoiseType.Tan)
            noise = Tan.generateTanNoise(noiseData, tanNoiseData);
        else if (noiseType == NoiseType.Circles)
            noise = Circles.generateCirclesNoise(noiseData, circlesNoiseData);
        else if(noiseType == NoiseType.Bumps)
            noise = Bumps.generateBumpsNoise(noiseData, bumpsNoiseData);
        else if (noiseType == NoiseType.Worley)
            noise = Worley.generateWorleyNoise(noiseData, worleyNoiseData);
        else if(noiseType == NoiseType.Perlin)
            noise = Perlin.generatePerlinNoise(noiseData, perlinNoiseData);
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
