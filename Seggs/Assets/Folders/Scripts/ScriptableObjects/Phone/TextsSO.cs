using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextsSO", menuName = "ScriptableObjects/TextsSO", order = 1)]
public class TextsSO : ScriptableObject
{
    public string contactName;
    public List<string> txts;
    public Sprite lastImg;
}