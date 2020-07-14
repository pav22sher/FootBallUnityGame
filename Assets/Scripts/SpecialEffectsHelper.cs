using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
	public static SpecialEffectsHelper Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;
	public ParticleSystem restartEffect;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(smokeEffect, position);
		instantiate(fireEffect, position);
	}

	public void Restart(Vector3 position)
	{
		instantiate(restartEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			1f
		);
		return newParticleSystem;
	}
}