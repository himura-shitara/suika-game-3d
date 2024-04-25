using UnityEngine;

public class FruitMove : MonoBehaviour
{
    [SerializeField] private GameObject fruit;
    private readonly float _speed = 3f;
    private Rigidbody _fruitRb;

    private void Start()
    {
        _fruitRb = fruit.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        if (fruit is not null)
        {
            fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _fruitRb.useGravity = true;
                fruit = null;
                _fruitRb = null;
            }
        }
    }
}
