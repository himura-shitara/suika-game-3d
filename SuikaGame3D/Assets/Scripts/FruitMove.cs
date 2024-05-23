using UnityEngine;

public class FruitMove : MonoBehaviour
{
    public GameObject fruit;
    private float _speed = 3f;
    private Rigidbody _fruitRigidbody;

    private void Start()
    {
        _fruitRigidbody = fruit.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Input.GetAxis("Horizontal") で左右方向の入力を取得する
        var inputX = Input.GetAxis("Horizontal");
        // Input.GetAxis("Vertical") で上下方向の入力を取得する
        var inputY = Input.GetAxis("Vertical");

        // フルーツが null でない（フルーツへのアクセスを持っている）なら
        if (fruit != null)
        {
            // フルーツの移動
            fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // フルーツの重力をオン
                _fruitRigidbody.useGravity = true;
                // フルーツを null にする（フルーツへのアクセスを手放す）
                fruit = null;
                _fruitRigidbody = null;
            }
        }
    }
}
