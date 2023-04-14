using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        if(Input.GetMouseButtonDown(0))//左クリックされたら起動
        {
            //マウスでクリックした座標の取得しtouchScreenPositionに格納
            Vector3 touchScreenPosition=Input.mousePosition;
            //プレイヤーの奥行きを5.0に固定
            touchScreenPosition.z=5.0f;
            Camera camera=Camera.main;//ここ理解できてない
            //touchWorldPositionに何かを格納？（ここも理解できてない）
            touchWorldPosition=camera.ScreenToWorldPoint(touchScreenPosition);
            moveflg=true;
       } 
       if(moveflg==true)
       {
            //プレイヤーが指定座標に移動（詳しくはわからない）
            player.transform.position=Vector3.MoveTowards(player.transform.position,touchWorldPosition
            ,speed*Time.deltaTime*2);
            if(player.transform.position==touchWorldPosition)
            {
                moveflg=false;
            }
            
       }      
    }
}
