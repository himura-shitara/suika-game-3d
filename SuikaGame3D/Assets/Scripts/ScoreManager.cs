using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private Text scoreText;
    private int _score = 0;
    
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

    private void Start()
    {
        Score(score: 0);
    }

    public void Score(int score)
    {
        _score += score;
        scoreText.text = $"Score:\n{_score}";
    }
}
