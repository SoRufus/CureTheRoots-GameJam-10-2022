using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySO : ScriptableObject
{
    public Sprite Sprite;
    public string Name;
    public int Health;
    public int MinDamage;
    public int MaxDamage;
}
