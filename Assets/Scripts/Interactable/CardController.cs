using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Image icon = null;
    [SerializeField] private TextMeshProUGUI cardName = null;
    [SerializeField] private TextMeshProUGUI cardDescription = null;

    public void Initialize(CardSO card)
    {
        icon.sprite = card.Sprite;
        cardName.text = card.name;
        cardDescription.text = card.Description;
    }

    private CardSO GetRandomCard()
    {
        float random = Random.value;
        CardType type = random <= 0.2f ? CardType.Heal : random <= 0.55 ? CardType.Attack : CardType.Block;

        return null;
    }
}
