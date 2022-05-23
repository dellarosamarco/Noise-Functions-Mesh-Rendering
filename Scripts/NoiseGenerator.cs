using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public Vector2Int mapSize;
    public float frequency;
    public float amplitude;
    public Vector2 offset;

    [Header("Texture Components")]
    public MeshRenderer textureMeshRenderer;

    [Header("Mesh Components")]
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    public void generateNoise()
    {
        float[,] sineNoise = Sine.generateSineNoise(mapSize, frequency, amplitude, offset);
        Texture2D texture = TextureGenerator.generateTexture(mapSize, sineNoise);
        Mesh mesh = MeshGenerator.generateMesh(mapSize, sineNoise);

        //visualizeNoiseTexture(texture);
        visualizeNoiseMesh(texture, mesh);
    }

    public void visualizeNoiseTexture(Texture2D texture)
    {
        textureMeshRenderer.sharedMaterial.mainTexture = texture;
        textureMeshRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void visualizeNoiseMesh(Texture2D texture, Mesh mesh)
    {
        meshRenderer.sharedMaterial.mainTexture = texture;
        meshRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
        meshFilter.sharedMesh = mesh;
    }
}
