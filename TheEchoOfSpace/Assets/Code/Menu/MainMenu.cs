using UnityEngine;

public class MainMenu : MonoBehaviour
{
    LevelManager levelManager;

    public Transform panel;

    // По части гласного меню
    public void StartGameButton()
    {
        LevelManager.SelectScene(Scene.Game);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

}
