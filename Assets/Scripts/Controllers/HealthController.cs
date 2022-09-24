using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image healthBar = null;
    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private TextMeshProUGUI shieldText = null;

    private RectTransform healthBarRect = null;
    private GameplayManager gameplayManager = null;

    private int health = 0;
    private int shield = 0;
    private float startingWidth = 0;

    private void Start()
    {
        healthBarRect = healthBar.GetComponent<RectTransform>();
        startingWidth = healthBarRect.sizeDelta.x;

        gameplayManager = GameplayManager.Instance;

        RefreshHealthBar();
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
        if (shield == gameplayManager.Shield) return;

        shieldText.text = gameplayManager.Shield.ToString();
        shield = gameplayManager.Shield;
    }
}
