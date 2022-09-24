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
	public int CurrentLevel { get; set; } = 0;
	public int TreeHealth { get; set; } = 500;
	public int Shield { get; set; } = 0;
	public int Turn { get; set; } = 0;

	public int MaxTreeHealth = 1000;
}
