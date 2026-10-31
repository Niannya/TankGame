using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class BeginMenuController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button rankingButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
        rankingButton.onClick.AddListener(OpenRanking);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        settingsButton.onClick.RemoveListener(OpenSettings);
        quitButton.onClick.RemoveListener(QuitGame);
        rankingButton.onClick.RemoveListener(OpenRanking);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OpenSettings()
    {
        Debug.Log("打开设置界面");
    }

    private void OpenRanking()
    {
        Debug.Log("打开排行榜");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}