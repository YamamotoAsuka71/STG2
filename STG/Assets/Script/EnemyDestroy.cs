using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    GameObject[] Enemyes;//Enemyタグを格納する配列。
    void Start()
    {
            Enemyes=    GameObject.FindGameObjectsWithTag("Enemy");//Enemyタグのついているオブジェクト情報を記録。
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)//ほかのオブジェクトと衝突したとき。
    {
        // もし衝突した相手オブジェクトのタグが"Enemy"ならば中の処理を実行
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Destroy(other.gameObject);//弾が当たった敵を破壊。
            Destroy(this.gameObject);//敵に当たった弾を破壊。
        }
    }
}
