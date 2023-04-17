using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //プレイヤーが移動できるx軸の最大値
    private float maxwidth=8.388f;
    //プレイヤーが移動できるx軸の最小値
    private float minwidth=-8.388f;
    //プレイヤーが移動できるy軸の最大値
    private float maxhigh=4.5f;
    //プレイヤーが移動できるy軸の最小値
    private float minhigh=-4.5f;
    //発射する弾のオブジェクト
    [SerializeField]
    private GameObject bulletPrefab;
    //マウスのクリックした座標の取得
    Vector3 touchWorldPosition;
    //弾の発射間隔
    private float bullettime=0f;

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
        //自機の動き
        move();
        //弾の発射
        bullet();
    }

    void move()
    {
        //クリックした地点までいかないと次のクリック反応しない時用
        //if(moveflg==false)
        //{
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

        //}
       if(moveflg==true)
       {
            //プレイヤーの行動範囲の制限
            if(touchWorldPosition.x<maxwidth&&touchWorldPosition.x>minwidth&&
            touchWorldPosition.y<maxhigh&&touchWorldPosition.y>minhigh)
            {
                touchWorldPosition.z=0;
                //プレイヤーが指定座標に移動（詳しくはわからない）
                this.transform.position=Vector3.MoveTowards(this.transform.position,touchWorldPosition
                ,speed*Time.deltaTime*2);
                if(this.transform.position==touchWorldPosition)
                {
                    this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y,0);
                    moveflg=false;
                }            
            }            
       }      
        
    }
    void bullet()
    {
        //弾の発射間隔の計算
        bullettime+=Time.deltaTime;
        //スペースキーで弾の発射
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //弾を発射してから0.5秒以上たったら次の弾を発射
            if(bullettime>=0.5f)
            {
                //bulletPrefabをプレイヤーの位置に生成
                Instantiate(bulletPrefab,
                        this.transform.position,
                        transform.rotation);
                //弾の発射間隔の時間リセット
                bullettime=0.0f;
            }
        }
    }
}
