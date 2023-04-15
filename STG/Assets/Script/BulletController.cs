using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();//エネミー２の直進運動。
    }
    void Move()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-8.888f)//完全に見切れるまで。
        {
            pos.x -= 0.02f;//左へ直進。
        }
        if(pos.x<-8.888f)//完全に見切れたら。
        {
            Destroy(this.gameObject);//エネミー２を破壊。
        }
        
 
        myTransform.position = pos;//座標を再設定。
    }
}
