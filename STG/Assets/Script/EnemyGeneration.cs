using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    const float RangePointX=8.388f;//エネミーが見切れるギリギリのＸ座標の正の値。
    const float RangePointY=4.5f;//エネミーが見切れるギリギリのＹ座標の正の値。
    float Seconds1=0;//エネミー１の生成スピードを管理するための変数。
    float Seconds2=0;//エネミー２の生成スピードを管理するための変数。
    float Seconds3=0;//エネミー３の生成スピードを管理するための変数。
    float AllSeconds=0;
    public GameObject Enemy1;//エネミー１を指定するための格納ポイント。
    public GameObject Enemy2;//エネミー２を指定するための格納ポイント。
    public GameObject Enemy3;//エネミー３を指定するための格納ポイント。
    const float AppearanceMin=-RangePointY;//エネミー生成のＹ座標の最低値。
    const float AppearanceMax=RangePointY;//エネミー生成のＹ座標の最高値。
    void Start()
    {
        
    }

    void Update()
    {
        Seconds1+=Time.deltaTime;//時間を計測している。
        Seconds2+=Time.deltaTime;//時間を計測している。
        Seconds3+=Time.deltaTime;//時間を計測している。
        AllSeconds+=Time.deltaTime;
        if(Seconds1>=1.5)//１．５秒経ったら。
        {
            float Appearance1 = Random.Range(AppearanceMin,AppearanceMax);//エネミー出現ポイントをランダムで決める。
            Instantiate(Enemy1, new Vector3(RangePointX+1, Appearance1, 0), Quaternion.identity);//エネミー生成。
            Seconds1=0;//時間経過リセッ．ト。
        }
        if(Seconds2>=1.5&&AllSeconds>=30)//１．５秒経ったら。
        {
            float Appearance2 = Random.Range(AppearanceMin,AppearanceMax);//エネミー出現ポイントをランダムで決める。
            Instantiate(Enemy2, new Vector3(RangePointX+1, Appearance2, 0), Quaternion.identity);//エネミー生成。
            Seconds2=0;//時間経過リセット。
        }
        if(Seconds3>=1.5&&AllSeconds>=60)//１．５秒経ったら。
        {
            float Appearance3 = Random.Range(AppearanceMin,AppearanceMax);//エネミー出現ポイントをランダムで決める。。
            Instantiate(Enemy3, new Vector3(RangePointX+1, Appearance3, 0), Quaternion.identity);//エネミー生成。
            Seconds3=0;//時間経過リセット。
            AllSeconds=60;
        }
    }
}
