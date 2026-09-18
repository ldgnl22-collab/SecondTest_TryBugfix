using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _hudRoot;

    private bool _isPaused;

    private void Start()
    {
        InitPanel();
    }

    private void Update()
    {
        ReadPauseKey();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _hudRoot.SetActive(true);
        _isPaused = false;
    }

    private void InitPanel()
    {
        _pausePanel.SetActive(false);
    }

    private void ReadPauseKey()
    {
        if (!Input.GetKeyDown(KeyCode.P))
        {
            return;
        }

        if (_isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        _hudRoot.SetActive(false);
        _isPaused = true;
    }
}
