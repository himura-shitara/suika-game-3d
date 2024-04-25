using UnityEngine;

public class FruitMove : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    private readonly float _speed = 3f;

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);
    }
}
