using UnityEngine;

public static class MeshGenerator
{
    public static Mesh generateMesh(Vector2Int mapSize, float[,] noise)
    {
        Mesh mesh = new Mesh();

        int xSize = mapSize.x;
        int ySize = mapSize.y;

        Vector3[] vertices = new Vector3[xSize * ySize];
        int[] triangles = new int[vertices.Length * 6];
        Vector2[] uvs = new Vector2[vertices.Length];

        int vertex = 0;
        int triangle = 0;
        Vector3 tempVector = Vector3.zero;
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                tempVector.x = x;
                tempVector.y = noise[x, y];
                tempVector.z = y;
                vertices[vertex] = tempVector;
                uvs[vertex] = new Vector2(x / (float)xSize, y / (float)ySize);

                if(x < xSize-1 && y < ySize - 1)
                {
                    int[] square = generateSquare(vertex, mapSize);

                    for (int i = 0; i < square.Length; i++)
                    {
                        triangles[triangle] = square[i];
                        triangle++;
                    }
                }

                vertex++;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }

    public static int[] generateSquare(int vertexIndex, Vector2Int mapSize)
    {
        return new int[]
        {
            vertexIndex,
            vertexIndex + mapSize.x + 1,
            vertexIndex + mapSize.x,
            vertexIndex + mapSize.x + 1,
            vertexIndex,
            vertexIndex + 1
        };
    }
}
