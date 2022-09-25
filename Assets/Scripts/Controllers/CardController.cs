using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{
    [SerializeField] private Image icon = null;
    [SerializeField] private TextMeshProUGUI cardValue = null;
    [SerializeField] private int startingIndex = 0;
    [SerializeField] private Animator animator = null;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    private CardsDatabase cardsDatabase = null;
    private CombatDatabase combatDatabase = null;
    private GameplayManager gameplayManager = null;
    private EnemyManager enemyManager = null;
    private CardSO currentCard = null;
    private Button cardButton = null;
    private AudioSource audioSource = null;

    private void Start()
    {
        cardsDatabase = CardsDatabase.Instance;
        enemyManager = EnemyManager.Instance;
        gameplayManager = GameplayManager.Instance;
        combatDatabase = CombatDatabase.Instance;
        cardButton = GetComponentInChildren<Button>();
        audioSource = GetComponent<AudioSource>();

        currentCard = combatDatabase.Combat[gameplayManager.CurrentLevel].StartingCards[startingIndex];
        Refresh();
    }

    private void Refresh()
    {
        icon.sprite = currentCard.Sprite;
        cardValue.text = currentCard.Value.ToString();
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

        if (currentCard.Type == CardType.Heal)
        {
            audioSource.clip = audioClips[0];
            gameplayManager.TreeHealth -= currentCard.Value;
        }
        else if (currentCard.Type == CardType.Attack)
        {
            audioSource.clip = audioClips[1];
            enemyManager.AttackEnemy(currentCard.Value);
        }
        else if (currentCard.Type == CardType.Block)
        {
            audioSource.clip = audioClips[2];
            gameplayManager.Block += currentCard.Value;
        }

        audioSource.Play();
        animator.SetTrigger("UseCard");
        Invoke(nameof(UseCardAfterAnimation), 0.5f);
    }

    public void UseCardAfterAnimation()
    {
        currentCard = GetNextCard();
        Refresh();
    }

    public void HideCard()
    {
        animator.SetBool("Show", false);
    }

    public void ShowCard()
    {
        animator.SetBool("Show", true);
    }
}
