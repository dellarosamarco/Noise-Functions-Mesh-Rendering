using UnityEngine;

[CreateAssetMenu(fileName = "Height Map Colors", menuName = "ScriptableObjects/Noises", order = 1)]
public class HeightMapColors : ScriptableObject
{
    public string noiseTitle;
    public HeightMapColor[] colors;
}
