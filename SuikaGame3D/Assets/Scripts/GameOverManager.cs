using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Text resultScore;
    public bool IsGameOver { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void OnGameOver()
    {
        gameOverWindow.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        resultScore.gameObject.SetActive(true);
        
        resultScore.text = $"Score:\n{ScoreManager.Instance.Score}";
        IsGameOver = true;
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
