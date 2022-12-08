using TMPro;

using UnityEngine;

namespace ThirdPersonShooter.UI
{
	public class GameOverMenu : MenuBase
	{
		public override string ID => "Game Over";

		[SerializeField] private TextMeshProUGUI scoreText;
		
		public override void OnOpenMenu(UIManager _manager)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			scoreText.text = $"Score: {GameManager.Instance.Player.Score}";
			
			GameManager.Instance.TogglePaused();
		}

		public override void OnCloseMenu(UIManager _manager)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			scoreText.text = "Score: 0";

			GameManager.Instance.TogglePaused();
		}
		
		public void OnClickMainMenu() => GameManager.Instance.LevelManager.UnloadGame(() => UIManager.ShowMenu("Main", false));
	}
}