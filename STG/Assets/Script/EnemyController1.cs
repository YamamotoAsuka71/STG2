using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController1 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        MoveX();//エネミー１の直進運動。
        MoveY();//エネミー１が上へはける挙動。
    }
    void MoveX()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-4.194f)//ある程度近づくまで。
        {
            pos.x -= 0.01f;//左へ直進。
        }
        
 
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
    void MoveY()
    {
        Transform myTransform=this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos=myTransform.position;//オブジェクトの座標を取得。
        if(pos.x<=-4.194f)//ある程度近づいたら。
        {
            pos.y+=0.01f;//上へはける。
        }
        if(pos.y>5.5f)//完全に見切れたら。
        {
            Destroy(this.gameObject);//エネミー１を破壊。
        }
        myTransform.position=pos;//オブジェクトの座標を更新。
    }
}
