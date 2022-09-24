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

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
        enemyDatabase = EnemyDatabase.Instance;
        enemyManager = EnemyManager.Instance;

        enemyManager.EnemyController = this;
        Initialize();
    }

    private void Initialize()
    {
        EnemySO enemy = enemyDatabase.Enemies[gameplayManager.CurrentLevel];

        dmg = Random.Range(enemy.MinDamage, enemy.MaxDamage);
        health = Random.Range(enemy.MinHealth, enemy.MaxHealth);

        DmgText.text = dmg.ToString();
        HpText.text = health.ToString();
    }

    private void RefreshHealth()
    {
        HpText.text = health.ToString();
    }
    
    public void EnemyAttacked(int value)
    {
        health -= value;
        RefreshHealth();

        if (health <= 0) return;
        EnemyAttack();
    }

    public void EnemyAttack()
    {
        gameplayManager.TreeHealth -= dmg;
    }
}
