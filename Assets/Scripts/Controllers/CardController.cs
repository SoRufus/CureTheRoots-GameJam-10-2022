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

    private CardsDatabase cardsDatabase = null;

    private void Start()
    {
        cardsDatabase = CardsDatabase.Instance;

        Initialize();
    }

    public void Initialize()
    {
        CardSO card = GetRandomCard();

        icon.sprite = card.Sprite;
        cardName.text = card.Name;
        cardDescription.text = card.Description;
    }

    private CardSO GetRandomCard()
    {
        float random = Random.value;
        CardType type = random <= 0.2f ? CardType.Heal : random <= 0.55 ? CardType.Attack : CardType.Block;

        List<CardSO> cards = new List<CardSO>();

        foreach (CardSO card in cardsDatabase.Cards)
        {
            if(card.Type == type) cards.Add(card);
        }

        return cards[Random.Range(0, cards.Count)];
    }
}
