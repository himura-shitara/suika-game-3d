using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    private bool _isFruitColliding;
    private float _timer = 0f;
    private const float GameOverTime = 4f;

    private void Update()
    {
        if (!GameOverManager.Instance.IsGameOver)
        {
            if (_isFruitColliding)
            {
                _timer += Time.deltaTime;
                if (_timer >= GameOverTime)
                {
                    GameOverManager.Instance.OnGameOver();
                }
            }
            else
            {
                _timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameOverManager.Instance.IsGameOver)
        {
            if (other.CompareTag("Fruit"))
            {
                _isFruitColliding = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!GameOverManager.Instance.IsGameOver)
        {
            if (other.CompareTag("Fruit"))
            {
                _isFruitColliding = false;
            }
        }
    }
}
