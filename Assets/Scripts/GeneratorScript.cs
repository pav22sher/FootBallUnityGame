using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

	public Transform poulpiPrefab;
	public float generateRate = 2f;
	public float destroyTime = 2f;

	private float generateCooldown;
	private float bossCooldown;

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Start () {
		var x = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0)).x;
		transform.position = new Vector3 (x, 0);
		generateCooldown = 0f;
	}

	void Update () {
		
		if (generateCooldown > 0) {
			generateCooldown -= Time.deltaTime;
		} else {
			generateCooldown = generateRate;

			var poulpiTransform = Instantiate(poulpiPrefab) as Transform;
			poulpiTransform.position = transform.position+new Vector3(0,Random.Range(-9f,9f));
			Destroy (poulpiTransform.gameObject, destroyTime);
		}

	}
}
