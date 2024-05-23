using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 自身のインスタンスを static として定義（詳しくは「シングルトン」で検索）
    public static ScoreManager Instance;
    public Text scoreText;
    private int _score = 0;
    
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

    private void Start()
    {
        AddScore(score: 0);
    }

    public void AddScore(int score)
    {
        _score += score;
        /*
         * Score:
         * 300
         *
         * のように表示される
         */
        scoreText.text = "Score:\n" + _score;
    }
}
