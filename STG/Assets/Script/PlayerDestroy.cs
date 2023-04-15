using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public int LifeCount=3;
    GameObject[] Enemyes;
    GameObject[] Bullets;
    // Start is called before the first frame update
    void Start()
    {
	
        Enemyes=    GameObject.FindGameObjectsWithTag("Enemy");
        Bullets=    GameObject.FindGameObjectsWithTag("EnemyBullet");
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeCount==0)
        {
            LifeCount=0;
            Destroy(this.gameObject);
        }
    }
    // ゲームオブジェクト同士が接触したタイミングで実行
    void OnTriggerEnter2D(Collider2D other)
    {
        // もし衝突した相手オブジェクトのタグが"Enemy"ならば中の処理を実行
        if (other.gameObject.CompareTag("Enemy")) 
        {
            LifeCount--;
            Debug.Log(LifeCount);
        }
        if (other.gameObject.CompareTag("EnemyBullet")) 
        {
            LifeCount--;
            Debug.Log(LifeCount);
        }
    }
}
