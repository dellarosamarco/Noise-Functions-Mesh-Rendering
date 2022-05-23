using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoiseGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NoiseGenerator noiseGenerator = (NoiseGenerator)target;

        if (DrawDefaultInspector())
        {
            noiseGenerator.generateNoise();
        }

        if (GUILayout.Button("Generate"))
        {
            noiseGenerator.generateNoise();
        }
    }
}