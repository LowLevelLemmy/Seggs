using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SeggGraphicSO", order = 1)]
public class SeggGraphicSO : ScriptableObject
{
    public string title;

    public Sprite preThrust;
    public Sprite thrust;
    public Sprite fail;
    public Sprite thankYou;
}