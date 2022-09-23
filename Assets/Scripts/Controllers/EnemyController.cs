using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DmgText = null;
    [SerializeField] private TextMeshProUGUI HpText = null;

    private int dmg = 0;
    private int health = 0;

    private GameplayManager gameplayManager = null;
    private EnemyDatabase enemyDatabase = null;

    private void Start()
    {
        gameplayManager = GameplayManager.Instance;
        enemyDatabase = EnemyDatabase.Instance;

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
}
