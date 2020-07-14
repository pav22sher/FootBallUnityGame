using UnityEngine;
public class ShotScript : MonoBehaviour
{
	public int damage = 1;
	public bool isEnemyShot = false;
	public float destroyTime = 2f;

	void Start()
	{
		Destroy(gameObject, destroyTime);
	}
}