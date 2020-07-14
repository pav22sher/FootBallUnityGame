using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
	private Button[] buttons;
	public Transform PlayerPrefab;

	void Awake()
	{
		buttons = GetComponentsInChildren<Button>();
		HideButtons();
	}

	public void HideButtons()
	{
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(false);
		}
	}

	public void ShowButtons()
	{
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(true);
		}
	}

	public void ExitToMenu()
	{
		SceneManager.LoadScene("menu");
	}

	public void RestartGame()
	{
		var player=Instantiate(PlayerPrefab) as Transform;
		var x = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x+10f;
		player.position = new Vector3 (x, 0);
		SpecialEffectsHelper.Instance.Restart(player.position);
		SoundEffectsHelper.Instance.MakeRestartSound();
		HideButtons ();
	}
}