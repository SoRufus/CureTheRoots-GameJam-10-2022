using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
	#region Singleton
	public static CardsManager Instance { get { return instance; } }
	private static CardsManager instance;

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

	[SerializeField] private GameObject Cards = null;

	public void ToggleCards(bool toggle)
    {
		if (Cards == null) return;

		 Cards.SetActive(toggle);
    }
}
