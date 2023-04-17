using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public int LifeCount=3;//初期残機。
    GameObject[] Enemyes;//Enemyタグを格納する配列。
    GameObject[] Bullets;//EnemyBulletタグを格納する配列。
    void Start()
    {
	
        Enemyes=    GameObject.FindGameObjectsWithTag("Enemy");//Enemyタグのついているオブジェクト情報を記録。
        Bullets=    GameObject.FindGameObjectsWithTag("EnemyBullet");//EnemyBulletタグのついているオブジェクト情報を記録。
    }

    void Update()
    {
        if(LifeCount==0)//ライフカウントが０なったら。
        {
            LifeCount=0;//ライフカウントを０に固定。
            Destroy(this.gameObject);//プレイヤーを破壊。
        }
    }
    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter2D(Collider2D other)
    {
        // もし衝突した相手オブジェクトのタグが"Enemy"ならば中の処理を実行
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Destroy(other.gameObject);
            LifeCount--;//ライフカウントを１減らす。
            Debug.Log(LifeCount);//残り残機を報告。
        }
        if (other.gameObject.CompareTag("EnemyBullet")) 
        {
            Destroy(other.gameObject);
            LifeCount--;
            Debug.Log(LifeCount);
        }
    }
}
