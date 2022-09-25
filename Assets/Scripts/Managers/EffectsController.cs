using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
	#region Singleton
	public static EffectsController Instance { get { return instance; } }
	private static EffectsController instance;

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

	[SerializeField] private Animator DamageAnimator = null;

	public void PlayDamageEffect()
    {
		DamageAnimator.SetTrigger("Play");
    }
}
