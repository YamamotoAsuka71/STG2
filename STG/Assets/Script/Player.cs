using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //プレイヤーが移動できるx軸の最大値
    public float maxwidth=8.388f;
    //プレイヤーが移動できるx軸の最小値
    public float minwidth=-8.388f;
    //プレイヤーが移動できるy軸の最大値
    public float maxhigh=4.5f;
    //プレイヤーが移動できるy軸の最小値
    public float minhigh=-4.5f;
    //動かすプレイヤーのオブジェクト
    public GameObject player;
    //マウスのクリックした座標の取得
    Vector3 touchWorldPosition;

    public bool moveflg;
    //移動のスピード？
    public int speed=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if(Input.GetMouseButtonDown(0))//左クリックされたら起動
        {
            //マウスでクリックした座標の取得しtouchScreenPositionに格納
            Vector3 touchScreenPosition=Input.mousePosition;
            //プレイヤーの奥行きを5.0に固定
            touchScreenPosition.z=5.0f;
            Camera camera=Camera.main;//カメラの取得
            //touchWorldPositionにスクリーンポジションをワールドポジションに変換して格納
            touchWorldPosition=camera.ScreenToWorldPoint(touchScreenPosition);
            moveflg=true;
       } 
       if(moveflg==true)
       {
            //プレイヤーの行動範囲の制限
            if(touchWorldPosition.x<maxwidth&&touchWorldPosition.x>minwidth&&
            touchWorldPosition.y<maxhigh&&touchWorldPosition.y>minhigh)
            //{
                //プレイヤーが指定座標に移動（詳しくはわからない）
                player.transform.position=Vector3.MoveTowards(player.transform.position,touchWorldPosition
                ,speed*Time.deltaTime*2);
                if(player.transform.position==touchWorldPosition)
                {
                    moveflg=false;
                }            
            //}            
       }      
        
    }
}
