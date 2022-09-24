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
    [SerializeField] private int startingIndex = 0;

    private CardsDatabase cardsDatabase = null;
    private CombatDatabase combatDatabase = null;
    private GameplayManager gameplayManager = null;
    private EnemyManager enemyManager = null;
    private CardSO currentCard = null;
    private Button cardButton = null;

    private void Start()
    {
        cardsDatabase = CardsDatabase.Instance;
        enemyManager = EnemyManager.Instance;
        gameplayManager = GameplayManager.Instance;
        combatDatabase = CombatDatabase.Instance;
        cardButton = GetComponentInChildren<Button>();

        currentCard = combatDatabase.Combat[gameplayManager.CurrentLevel].StartingCards[startingIndex];
        Refresh();
    }

    private void Refresh()
    {
        icon.sprite = currentCard.Sprite;
        cardName.text = currentCard.Name;
        cardValue.text = currentCard.Value.ToString();
        iconCardType.sprite = currentCard.Type == CardType.Attack ? cardsDatabase.AttackIcon : currentCard.Type == CardType.Block ? cardsDatabase.BlockIcon : cardsDatabase.HealIcon;
    }

    private CardSO GetNextCard()
    {
        if (gameplayManager.Turn != 0) if (gameplayManager.Turn % 2 != 0) return null;

        gameplayManager.NextTurn();
        return combatDatabase.Combat[gameplayManager.CurrentLevel].Cards[gameplayManager.Turn / 2];
    }

    public void UseCard()
    {
        if (gameplayManager.Turn != 0) if (gameplayManager.Turn % 2 != 0) return;

        if (currentCard.Type == CardType.Heal) gameplayManager.TreeHealth += currentCard.Value;
        else if (currentCard.Type == CardType.Attack) enemyManager.AttackEnemy(currentCard.Value);
        else if (currentCard.Type == CardType.Block) gameplayManager.Block += currentCard.Value;

        currentCard = GetNextCard();
        Refresh();
    }
}
