using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour
{

    float Seconds1=0;
    float Seconds2=0;
    float Seconds3=0;

    //float speed=2;

    public GameObject Missile;
    public GameObject Target;
    
    void Start()
    {
        
    }

    void Update()
    {

        Seconds1+=Time.deltaTime;
        Seconds2+=Time.deltaTime;
        if(Seconds1>=5)
        {
            Seconds3+=Time.deltaTime;
            if(Seconds2>=5)
            {
                Seconds2+=Time.deltaTime;
                float flgCount=Random.Range(0,2);
            
                if(flgCount==0)
                {
                    TopMove();
                }
                if(flgCount==1)
                {
                    UnderMove();
                }
            }
            Seconds2=0;
        }
        
        if(Seconds1>=15)
        {
            Seconds1=0;
            Seconds2=0;
        }
        
    }

    void TopMove()
    {
        Instantiate(Missile, new Vector3(0, 5.5f, 0), Quaternion.identity);
        Missile.SetActive (true);
    }
    void UnderMove()
    {
        Instantiate(Missile, new Vector3(0, -5.5f, 0), Quaternion.identity);
        Missile.SetActive (true);
    }
    
}
