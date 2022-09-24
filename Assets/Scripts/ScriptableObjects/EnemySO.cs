using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySO : ScriptableObject
{
    public Sprite Sprite;
    public int MinHealth;
    public int MaxHealth;
    public int MinDamage;
    public int MaxDamage;
}