using UnityEngine;

public class GameplayManager : MonoBehaviour
{
	#region Singleton
	public static GameplayManager Instance { get { return instance; } }
	private static GameplayManager instance;

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
	public int CurrentLevel = 0;
	public int TreeHealth = 500;
	public int Block { get; set; } = 0;
	public int Turn { get; set; } = 0;

	public int MaxTreeHealth = 1000;

	private EnemyManager enemyManager = null;

	private void Start()
	{
		enemyManager = EnemyManager.Instance;

		if (CurrentLevel == 0) PlayerPrefs.SetInt("Health", TreeHealth);
		else TreeHealth = PlayerPrefs.GetInt("Health");
	}

	public void NextTurn()
	{
		Turn++;
		enemyManager.EnemyController.EnemyTurn();
	}
}
