using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combat
{
    public List<CardSO> StartingCards = new();
    public List<CardSO> Cards = new();
    public List<int> EnemyAttacks = new();
}

public class CombatDatabase : MonoBehaviour
{
    public List<Combat> Combat = new();

    #region
    public static CombatDatabase Instance { get { return instance; } }
	private static CombatDatabase instance;

	private void Awake()

	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}
#endregion
}
