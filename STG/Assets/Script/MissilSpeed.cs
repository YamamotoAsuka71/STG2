using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilSpeed : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    public float Seconds3=0;
    bool flg=false;
    bool flg1=false;
    bool flg2=false;
    bool flg3=false;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
 
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Seconds3+=Time.deltaTime;
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

        Vector3 diff=(PlayerPosition-EnemyPosition).normalized;
        //float diffX=PlayerPosition.x-EnemyPosition.x;
        //float diffY=PlayerPosition.y-EnemyPosition.y;

        if(Seconds3<=5)
        {
            this.transform.rotation=Quaternion.FromToRotation(Vector3.up,diff);

            //// 対象物へのベクトルを算出
            //Vector3 toDirection = playerObject.transform.position - transform.position;
            //// 対象物へ回転する
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

            if (PlayerPosition.x > EnemyPosition.x&&PlayerPosition.y > EnemyPosition.y)
            {   
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
            }
            else if (PlayerPosition.x < EnemyPosition.x&&PlayerPosition.y > EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
            }

            else if (PlayerPosition.x > EnemyPosition.x&&PlayerPosition.y < EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
            }
            else if (PlayerPosition.x < EnemyPosition.x&&PlayerPosition.y < EnemyPosition.y)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
            }
 
            transform.position = EnemyPosition;
        }
        if(Seconds3>5)
        {
            if (PlayerPosition.x > EnemyPosition.x&&PlayerPosition.y > EnemyPosition.y&&flg1==false&&flg2==false&&flg3==false)
            {
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
                flg=true;
            }
            if (PlayerPosition.x < EnemyPosition.x&&PlayerPosition.y > EnemyPosition.y&&flg==false&&flg2==false&&flg3==false)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
                flg1=true;
            }

            if (PlayerPosition.x > EnemyPosition.x&&PlayerPosition.y < EnemyPosition.y&&flg==false&&flg1==false&&flg3==false)
            {
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
                flg2=true;
            }
            if (PlayerPosition.x < EnemyPosition.x&&PlayerPosition.y < EnemyPosition.y&&flg==false&&flg1==false&&flg2==false)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
                flg3=true;
            }
            if(flg==true)
            {
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
            }
            if(flg1==true)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y + 1f*Time.deltaTime;
            }
            if(flg2==true)
            {
                EnemyPosition.x = EnemyPosition.x + 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
            }
            if(flg3==true)
            {
                EnemyPosition.x = EnemyPosition.x - 1f*Time.deltaTime;
                EnemyPosition.y = EnemyPosition.y - 1f*Time.deltaTime;
            }
            transform.position = EnemyPosition;
        }
        if(Seconds3>=10)
        {
            Destroy(this.gameObject);
        }
    }
}
