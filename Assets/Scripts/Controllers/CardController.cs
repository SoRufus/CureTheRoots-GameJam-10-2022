using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Image iconCardType = null;
    [SerializeField] private Image icon = null;
    [SerializeField] private TextMeshProUGUI cardName = null;
    [SerializeField] private TextMeshProUGUI cardValue = null;

    private CardsDatabase cardsDatabase = null;
    private GameplayManager gameplayManager = null;
    private EnemyManager enemyManager = null;
    private CardSO currentCard = null;

    private void Start()
    {
        cardsDatabase = CardsDatabase.Instance;
        enemyManager = EnemyManager.Instance;
        gameplayManager = GameplayManager.Instance;

        Initialize();
    }

    private void Initialize()
    {
        currentCard = GetRandomCard();

        icon.sprite = currentCard.Sprite;
        cardName.text = currentCard.Name;
        cardValue.text = currentCard.Value.ToString();
        iconCardType.sprite = currentCard.Type == CardType.Attack ? cardsDatabase.AttackIcon : currentCard.Type == CardType.Block ? cardsDatabase.BlockIcon : cardsDatabase.HealIcon;
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

    public void UseCard()
    {
        if (currentCard.Type == CardType.Heal) gameplayManager.TreeHealth += currentCard.Value;
        else if (currentCard.Type == CardType.Attack) enemyManager.AttackEnemy(currentCard.Value);
        else if (currentCard.Type == CardType.Block) gameplayManager.Shield += currentCard.Value;

        Initialize();
    }
}
