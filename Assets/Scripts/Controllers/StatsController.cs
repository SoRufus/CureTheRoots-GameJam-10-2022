using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsController : MonoBehaviour
{
    [SerializeField] private Image healthBar = null;
    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private TextMeshProUGUI shieldText = null;

    private RectTransform healthBarRect = null;
    private GameplayManager gameplayManager = null;

    private int health = 0;
    private int block = 0;
    private float startingWidth = 0;

    private void Start()
    {
        healthBarRect = healthBar.GetComponent<RectTransform>();
        startingWidth = healthBarRect.sizeDelta.x;

        gameplayManager = GameplayManager.Instance;

        shieldText.text = gameplayManager.Block.ToString();
        healthText.text = gameplayManager.TreeHealth.ToString() + "/" + gameplayManager.MaxTreeHealth.ToString();
    }

    private void Update()
    {
        RefreshHealthBar();
        RefreshShieldBar();
    }

    private void RefreshHealthBar()
    {
        if (health == gameplayManager.TreeHealth) return;

        healthBarRect.sizeDelta = new Vector2(startingWidth * gameplayManager.TreeHealth / gameplayManager.MaxTreeHealth, healthBarRect.sizeDelta.y);
        healthText.text = gameplayManager.TreeHealth.ToString() + "/" + gameplayManager.MaxTreeHealth.ToString();

        health = gameplayManager.TreeHealth;
    }

    private void RefreshShieldBar()
    {
        if (block == gameplayManager.Block) return;

        shieldText.text = gameplayManager.Block.ToString();
        block = gameplayManager.Block;
    }
}
