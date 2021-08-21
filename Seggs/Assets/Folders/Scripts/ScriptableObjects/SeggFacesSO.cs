using UnityEngine;

[CreateAssetMenu(fileName = "SeggFaces", menuName = "ScriptableObjects/SeggFacesSO", order = 1)]
public class SeggFacesSO : ScriptableObject
{
    public string femaleName;
    public string maleName;

    public Sprite femaleImg;
    public Sprite maleImg;
}