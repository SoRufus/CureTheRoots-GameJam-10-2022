using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SliderController sliderController = null;
    [SerializeField] private TextMeshPro dmgText = null;
    [SerializeField] private TextMeshPro hpText = null;
    [SerializeField] private List<Animator> animators = new();

    private int dmg = 0;
    private int health = 0;

    private GameplayManager gameplayManager = null;
    private EnemyDatabase enemyDatabase = null;
    private EnemyManager enemyManager = null;
    private CombatDatabase combatDatabase = null;

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
        enemyDatabase = EnemyDatabase.Instance;
        enemyManager = EnemyManager.Instance;
        combatDatabase = CombatDatabase.Instance;

        enemyManager.EnemyController = this;
        Initialize();
    }

    private void Initialize()
    {
        EnemySO enemy = enemyDatabase.Enemies[gameplayManager.CurrentLevel];

        dmg = combatDatabase.Combat[gameplayManager.CurrentLevel].EnemyAttacks[0];
        health = enemyDatabase.Enemies[gameplayManager.CurrentLevel].Health;

        RefreshStats();
    }

    public void EnemyTurn()
    {
        if (gameplayManager.Turn == 0) return;
        if (gameplayManager.Turn % 2 == 0) return;
        
        AttackPlayer();
        gameplayManager.Turn++;
        dmg = combatDatabase.Combat[gameplayManager.CurrentLevel].EnemyAttacks[gameplayManager.Turn / 2];

        RefreshStats();
    }

    private void RefreshStats()
    {
        hpText.text = health.ToString();
        dmgText.text = dmg.ToString();
    }
    
    public void EnemyAttacked(int value)
    {
        health -= value;

        foreach (Animator animator in animators)
        {
            animator.SetTrigger("Damage");
        }

        RefreshStats();

        if (health <= 0) Death();
    }

    public void AttackPlayer()
    {
        if (health <= 0) return;

        foreach(Animator animator in animators)
        {
            animator.SetTrigger("Attack");
        }

        int damageToDealLeft = dmg;
        if (gameplayManager.Block >= dmg)
        {
            gameplayManager.Block -= dmg;
        }
        else
        {
            damageToDealLeft -= gameplayManager.Block;
            gameplayManager.Block = 0;
            gameplayManager.TreeHealth += damageToDealLeft;
        }
    }

    private void Death()
    {
        if (sliderController == null) return;

        sliderController.gameObject.SetActive(true);
        PlayerPrefs.SetInt("Health", gameplayManager.TreeHealth);
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("Death");
        }
    }
}
