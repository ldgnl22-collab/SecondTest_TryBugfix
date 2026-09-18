using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private const string SCENE_GAME = "Game";

    public void StartGame()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}
