using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // 自身のインスタンスを static として定義（詳しくは「シングルトン」で検索）
    public static GameOverManager Instance;
    public GameObject gameOverWindow;
    public Text gameOverText;
    public Button retryButton;
    public Text resultScore;
    public bool isGameOver;
    
    private void Awake()
    {
        // この辺りの処理もシングルトンという手法に特有のもの
        // インスタンスの唯一性を担保している
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
        // GameOver ウィンドウを表示する
        gameOverWindow.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        resultScore.gameObject.SetActive(true);
        
        // GameOver ウィンドウのスコア表示を更新
        resultScore.text = "Score:\n" + ScoreManager.Instance.Score;
        isGameOver = true;
    }

    // Retry ボタンを押した際の処理
    public void OnRetry()
    {
        // 現在のシーン名（SceneManager.GetActiveScene().name）をロードし直す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
