using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private TextMeshPro DmgText = null;
    [SerializeField] private TextMeshPro HpText = null;

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

    private void Update()
    {
        NextTurn();
    }

    private void Initialize()
    {
        EnemySO enemy = enemyDatabase.Enemies[gameplayManager.CurrentLevel];

        dmg = combatDatabase.Combat[gameplayManager.CurrentLevel].EnemyAttacks[0];
        health = enemyDatabase.Enemies[gameplayManager.CurrentLevel].Health;

        RefreshStats();
    }

    private void NextTurn()
    {
        if (gameplayManager.Turn == 0) return;
        if (gameplayManager.Turn % 2 == 0) return;

        dmg = combatDatabase.Combat[gameplayManager.CurrentLevel].EnemyAttacks[gameplayManager.Turn / 2 + 1];
        RefreshStats();
        gameplayManager.Turn++;
    }

    private void RefreshStats()
    {
        HpText.text = health.ToString();
        DmgText.text = dmg.ToString();
    }
    
    public void EnemyAttacked(int value)
    {
        health -= value;
        RefreshStats();

        if (health <= 0) return;
    }

    public void EnemyAttack()
    {
        gameplayManager.TreeHealth -= dmg;
    }
}
