using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : MonoBehaviour
{
    bool xyflg=false;//上下を切り替えるスイッチ（最初はオフ）。
    bool Destroyflg=false;//ジグザグ運動とはける挙動を切り替えるスイッチ（最初はオフ）。
    void Start()
    {
        
    }

    void Update()
    {
        if(xyflg==false&&Destroyflg==false)//スイッチが両方ともオフの時。
        {
            MoveFalse();//左下に直進。
        }
        if(xyflg==true&&Destroyflg==false)//上下がオンでジグザグがオフの時。
        {
            MoveTrue();//左上に直進。
        }
        MoveDestroy();//エネミー３を破壊するまでの流れ。
    }
    void MoveFalse()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-4.194f&&pos.y>=-4.5f)//一番下に到達するまで。
        {
            pos.x -= 0.01f;//左へ移動。
            pos.y -= 0.025f;//下へ移動。
        }
        if(pos.y<-4.5f)//一番下に到達したら。
        {
            xyflg=true;//上下のスイッチオン。
        }    
 
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
    void MoveTrue()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-4.194f&&pos.y<=4.5f)//一番上に到達するまで。
        {
            pos.x -= 0.01f;//左へ移動。
            pos.y += 0.025f;//上へ移動。
        }
        if(pos.y>4.5f)//一番下に到達したら。
        {
            xyflg=false;//上下のスイッチをオフ。
        }
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
    void MoveDestroy()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x<=-4.194f)//ある程度近づいたら。
        {
            Destroyflg=true;//ジグザクのスイッチオン。
            pos.y-=0.025f;//下にはける。
        }
        myTransform.position = pos;//オブジェクトの座標を更新。
        if(pos.y<-5.5f)//完全に見切れたら。
        {
            Destroy(this.gameObject);//エネミー３を破壊。
        }
    }
}
