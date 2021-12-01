using UnityEngine;

public class destroyBall : MonoBehaviour
{
    /// <summary>
    /// 衝突した時
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手にPlayerタグが付いているとき
        if (collision.gameObject.tag == "Ball")
        {
            // 当たった相手を1秒後に削除
            Destroy(collision.gameObject, 1.0f);
        }
    }
}