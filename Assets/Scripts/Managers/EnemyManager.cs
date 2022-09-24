using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public EnemyController EnemyController { get; set; }

	#region Singleton
	public static EnemyManager Instance { get { return instance; } }
	private static EnemyManager instance;

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

	public void AttackEnemy(int value)
    {
		EnemyController.EnemyAttacked(value);
	}
}
