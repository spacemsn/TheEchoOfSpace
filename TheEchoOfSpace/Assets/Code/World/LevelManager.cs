using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Load,
    MainMenu,
    Game
}
public class LevelManager : MonoBehaviour
{
    public LevelManager Instance;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        SelectScene(Scene.MainMenu);
    }

    public static void SelectScene(Scene sceneEnum)
    {
        SceneManager.LoadScene(sceneEnum.ToString());
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != ((int)Scene.MainMenu))
        {
            MusicController.instance.BackgroundSource.Stop();
        }
    }
}
