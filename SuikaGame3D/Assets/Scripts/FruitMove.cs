using System.Collections;
using UnityEngine;

public class FruitMove : MonoBehaviour
{
    public GameObject[] fruits;
    public Transform initialPoint;
    private GameObject _fruit;
    private float _speed = 3f;
    private Rigidbody _fruitRigidbody;

    private void Start()
    {
        // 「名前付き引数」という記法を用いている
        // メソッドの limitIndex という引数に fruits.Length を渡す、ということを明示的に書いている
        InstantiateRandomFruit(limitIndex: fruits.Length - 3);  // スイカゲームは初めからでかいフルーツ落ちてこないよな、という思いから最大値を減らしている
    }

    private void Update()
    {
        // Input.GetAxis("Horizontal") で左右方向の入力を取得する
        var inputX = Input.GetAxis("Horizontal");
        // Input.GetAxis("Vertical") で上下方向の入力を取得する
        var inputY = Input.GetAxis("Vertical");

        // フルーツが null でない（フルーツへのアクセスを持っている）なら
        // GameOver 状態でないなら
        if (_fruit != null && !GameOverManager.Instance.isGameOver)
        {
            // フルーツの移動
            _fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // フルーツの重力をオン
                _fruitRigidbody.useGravity = true;
                // フルーツを null にする（フルーツへのアクセスを手放す）
                _fruit = null;
                _fruitRigidbody = null;
                // DelayMethod というコルーチンを呼び出す
                StartCoroutine(DelayMethod(delay: 1f));
            }
        }
    }
    
    private IEnumerator DelayMethod(float delay) {
        // delay 秒待機
        yield return new WaitForSeconds(delay);
        // スイカゲームは生成時からでかいフルーツ落ちてこないよな、という思いから最大値を減らしている
        InstantiateRandomFruit(limitIndex: fruits.Length - 2);
    }

    private void InstantiateRandomFruit(int limitIndex)
    {
        // 0 以上 limitIndex 未満の整数を取得
        int index = Random.Range(0, limitIndex);
        // initialPoint の位置に index に対応したフルーツを生成
        _fruit = Instantiate(fruits[index], initialPoint.position, Quaternion.identity);
        // 生成したフルーツの Rigidbody コンポーネントを取得
        _fruitRigidbody = _fruit.GetComponent<Rigidbody>();
        _fruitRigidbody.useGravity = false;
        // ScoreManager の AddScore メソッドを呼ぶ
        ScoreManager.Instance.AddScore(index * 10);
    }
}
