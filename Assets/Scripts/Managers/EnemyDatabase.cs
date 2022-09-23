using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
	public List<EnemySO> Enemies = new List<EnemySO>();
	#region Singleton
	public static EnemyDatabase Instance { get { return instance; } }
	private static EnemyDatabase instance;

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
