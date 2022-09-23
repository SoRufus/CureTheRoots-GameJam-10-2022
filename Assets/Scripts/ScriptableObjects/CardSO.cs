using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class CardSO : MonoBehaviour
{
    public Sprite Sprite;
    public CardType Type;
    public string Name;
    public string Description;
}
