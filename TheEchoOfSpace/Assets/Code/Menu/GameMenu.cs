using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0.0f;
        MusicController.instance.BackgroundSource.Play();
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        MusicController.instance.BackgroundSource.Stop();
    }

    public void ExitGameButton()
    {
        //Application.Quit();
        LevelManager.SelectScene(Scene.MainMenu);
    }
}
