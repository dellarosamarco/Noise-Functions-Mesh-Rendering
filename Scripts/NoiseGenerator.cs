using UnityEngine;

public class NoiseGenerator : MonoBehaviour
{
    public Vector2Int mapSize;

    [Header("Components")]
    public Material textureMaterial;
    public Mesh mesh;

    private void Start()
    {
        generateNoise();
    }

    public void generateNoise()
    {
        float[,] sineNoise = Sine.generateSineNoise(mapSize);
        Texture2D texture = TextureGenerator.generateTexture(mapSize, sineNoise);

        visualizeNoise(texture);
    }

    public void visualizeNoise(Texture2D texture)
    {
        GameObject renderObject = new GameObject("Texture renderer");
        MeshFilter meshFilter = renderObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        MeshRenderer meshRenderer = renderObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = textureMaterial;
        meshRenderer.sharedMaterial.mainTexture = texture;

        Instantiate(renderObject, Vector3.zero, Quaternion.identity);

    }
}
