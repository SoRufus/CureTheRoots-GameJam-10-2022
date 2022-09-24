using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class Slide
{
    public string Text;
    public Sprite Image;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogueSO : ScriptableObject
{
    public List<Slide> Slides = new();
}