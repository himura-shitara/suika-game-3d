using UnityEngine;

public class FruitMove : MonoBehaviour
{
    public GameObject fruit;
    private float _speed = 3f;

    private void Update()
    {
        // Input.GetAxis("Horizontal") で左右方向の入力を取得する
        var inputX = Input.GetAxis("Horizontal");
        // Input.GetAxis("Vertical") で上下方向の入力を取得する
        var inputY = Input.GetAxis("Vertical");

        // フルーツの移動
        fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);
    }
}
