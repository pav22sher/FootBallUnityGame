using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	private WeaponScript weapon;
	private SpriteRenderer rendererComponent;

	void Awake()
	{
		weapon = GetComponentInChildren<WeaponScript>();
		rendererComponent = GetComponent<SpriteRenderer> ();
	}

	void Update()
	{
		if (weapon != null && weapon.CanAttack)
		{
			weapon.Attack(true);
			SoundEffectsHelper.Instance.MakeEnemyShotSound();
		}
		if (rendererComponent.IsVisibleFrom(Camera.main) == false)
		{
			Destroy(gameObject);
		}
	}
}