using UnityEngine;

public class FruitsCombine : MonoBehaviour
{
    [SerializeField] private GameObject nextFruit;
    [SerializeField] private int combinationScore;
    public bool IsCombined { get; private set; }
    
    private void OnCollisionEnter(Collision other)
    {
        if (name == other.gameObject.name)
        {
            if (!IsCombined)
            {
                IsCombined = true;
                other.gameObject.GetComponent<FruitsCombine>().Combine();
                ScoreManager.Instance.Score(combinationScore);
                if (nextFruit is not null)
                {
                    Instantiate(
                        nextFruit,
                        Vector3.Lerp(
                            transform.position,
                            other.transform.position,
                            0.5f),
                        Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }

    public void Combine()
    {
        IsCombined = true;
        Destroy(gameObject);
    }
}
