using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDatabase : MonoBehaviour
{

	public Sprite AttackIcon = null;
	public Sprite BlockIcon = null;
	public Sprite HealIcon = null;

	public List<CardSO> Cards = new List<CardSO>();

	#region Singleton
	public static CardsDatabase Instance { get { return instance; } }
	private static CardsDatabase instance;

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
