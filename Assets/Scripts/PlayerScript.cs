using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(20, 20);
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Update()
	{
		
		bool shoot = Input.GetButtonDown("Jump");
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		}
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		movement = new Vector2(speed.x * inputX,speed.y * inputY);

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0)).x+1f;
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0)).x-1.5f;
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0)).y+1f;
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1)).y-1f;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder)
		);
	}

	void FixedUpdate()
	{
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();
		rigidbodyComponent.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			damagePlayer = true;
		}

		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}

	void OnDestroy()
	{
		var gameOver = FindObjectOfType<GameOverScript>();
		if(gameOver!=null) gameOver.ShowButtons();
	}
}