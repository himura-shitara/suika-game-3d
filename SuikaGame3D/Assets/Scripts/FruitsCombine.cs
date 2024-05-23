using UnityEngine;

public class FruitsCombine : MonoBehaviour
{
    public GameObject nextFruit;
    public int combinationScore;
    // 合体の処理が済んだフルーツかどうかを表す
    public bool isCombined;
    
    private void OnCollisionEnter(Collision other)
    {
        // 衝突したオブジェクトと名前が一緒なら
        if (name == other.gameObject.name)
        {
            // このフルーツがすでに合体の処理が済んでいなければ
            if (!isCombined)
            {
                // このフルーツを合体処理済みとする
                isCombined = true;
                // 合体相手の Combine メソッドを呼び出す
                other.gameObject.GetComponent<FruitsCombine>().Combine();
                // ScoreManager の AddScore メソッドを呼ぶ
                ScoreManager.Instance.AddScore(combinationScore);
                if (nextFruit != null)
                {
                    // 引数は改行して渡すことも可能
                    Instantiate(
                        nextFruit,
                        // Vector3.Lerp を用いて、上位のフルーツの生成場所として自身と合体相手の中間地点を指定している
                        Vector3.Lerp(transform.position, other.transform.position, 0.5f),
                        Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }

    public void Combine()
    {
        // このフルーツを合体処理済みとする
        isCombined = true;
        Destroy(gameObject);
    }
}
