using System.Collections;
using UnityEngine;

public class FruitMove : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits;
    [SerializeField] private Transform initialPoint;
    private readonly float _speed = 3f;
    private GameObject _fruit;
    private SphereCollider _fruitCol;
    private Rigidbody _fruitRb;

    private void Start()
    {
        InstantiateRandomFruit(limitIndex: fruits.Length - 3);
    }

    private void Update()
    {
        var inputX = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");

        if (_fruit is not null && !GameOverManager.Instance.IsGameOver)
        {
            _fruit.transform.position += new Vector3(inputX, 0, inputY) * (_speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _fruitCol.enabled = true;
                _fruitRb.useGravity = true;
                _fruit = null;
                _fruitCol = null;
                _fruitRb = null;
                StartCoroutine(DelayMethod(delay: 1f));
            }
        }
    }
    
    private IEnumerator DelayMethod(float delay) {
        yield return new WaitForSeconds(delay);
        InstantiateRandomFruit(limitIndex: fruits.Length - 2);
    }

    private void InstantiateRandomFruit(int limitIndex)
    {
        var index = Random.Range(0, limitIndex);
        _fruit = Instantiate(fruits[index], initialPoint.position, Quaternion.identity);
        _fruitCol = _fruit.GetComponent<SphereCollider>();
        _fruitRb = _fruit.GetComponent<Rigidbody>();
        _fruitCol.enabled = false;
        _fruitRb.useGravity = false;
    }
}
