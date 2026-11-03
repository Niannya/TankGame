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

    [Header("Panels")]
    [SerializeField] private SettingsPanelController settingsPanel;
    [SerializeField] private RankingPanelController rankingPanel;

    private void Start()
    {
        settingsPanel.Hide();
        rankingPanel.Hide();
    }

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
        settingsPanel.Show();
    }

    private void OpenRanking()
    {
        rankingPanel.Show();
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