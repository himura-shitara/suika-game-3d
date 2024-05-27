using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    // フルーツが GameOverChecker に接触しているかどうかを判定する変数
    private bool _isFruitColliding;
    // フルーツが GameOverChecker に接触し続けている時間
    private float _timer = 0f;
    // GameOverChecker に接触し始めてから GameOver になるまでの時間
    private float _gameOverTime = 4f;

    private void Update()
    {
        // GameOver 状態でないなら
        if (!GameOverManager.Instance.isGameOver)
        {
            // フルーツと GameOverChecker が接触している間
            if (_isFruitColliding)
            {
                // _timer を加算し続ける
                _timer += Time.deltaTime;
                // _timer が既定の秒数を超えたら
                if (_timer >= _gameOverTime)
                {
                    // OnGameOver() を呼び出して、GameOver 状態に遷移する
                    GameOverManager.Instance.OnGameOver();
                }
            }
            // フルーツと GameOverChecker との接触が途切れたら
            else
            {
                // _timer をリセットする
                _timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameOverManager.Instance.isGameOver)
        {
            if (other.CompareTag("Fruit"))
            {
                _isFruitColliding = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // GameOver 状態でないなら
        if (!GameOverManager.Instance.isGameOver)
        {
            // GameOverChecker とフルーツとの接触が終わったら
            if (other.CompareTag("Fruit"))
            {
                _isFruitColliding = false;
            }
        }
    }
}
