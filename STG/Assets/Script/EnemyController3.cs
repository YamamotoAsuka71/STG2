using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : MonoBehaviour
{
    bool xyflg=false;//上下を切り替えるスイッチ（最初はオフ）。
    bool Destroyflg=false;
    void Start()
    {
        
    }

    void Update()
    {
        if(xyflg==false&&Destroyflg==false)//スイッチがオフの時。
        {
            MoveFalse();//左下に直進。
        }
        if(xyflg==true&&Destroyflg==false)//スイッチががオンの時。
        {
            MoveTrue();//左上に直進。
        }
        MoveDestroy();//エネミー３を破壊するまでの流れ。
    }
    void MoveFalse()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-8.888f&&pos.y>=-4.5f)//一番下に到達するまで。
        {
            pos.x -= 0.01f;//左へ移動。
            pos.y -= 0.025f;//下へ移動。
        }
        if(pos.y<-4.5f)//一番下に到達したら。
        {
            xyflg=true;//スイッチオン。
        }    
 
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
    void MoveTrue()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x>=-8.888f&&pos.y<=4.5f)//一番上に到達するまで。
        {
            pos.x -= 0.01f;//左へ移動。
            pos.y += 0.025f;//上へ移動。
        }
        if(pos.y>4.5f)//一番下に到達したら。
        {
            xyflg=false;//スイッチをオフ。
        }
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
    void MoveDestroy()
    {
        Transform myTransform = this.transform;//オブジェクトの位置情報を取得。

        Vector3 pos = myTransform.position;//オブジェクトの座標を取得。
        if(pos.x<=-4.194&&xyflg==false)
        {
            Destroyflg=true;
        }
        if(Destroyflg==true)
        {
            pos.x -= 0.01f;
            pos.y -= 0.025f;
        }
        if(pos.x<-8.888f)//見切れたら。
        {
            Destroy(this.gameObject);//エネミー３を破壊。
        }
        myTransform.position = pos;//オブジェクトの座標を更新。
    }
}
