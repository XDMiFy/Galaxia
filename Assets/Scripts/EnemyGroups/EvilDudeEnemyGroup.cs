using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilDudeEnemyGroup : BasedGroup
{
    public EvilDude dude1;
    public EvilDude dude2;
    public EvilDude dude3;
    private float speed = 0.1f;
    private int oneDirection = -1;
    private List<EvilDude> sheep = new List<EvilDude>();
    private System.Random generator = new System.Random();
    
    void Start()
    {
        sheep.Add(dude1);
        sheep.Add(dude2);
        sheep.Add(dude3);

        InvokeRepeating("GroupShoot", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        sheep.RemoveAll( item => item == null);
        if( dude1 == null 
        && dude2 == null 
        && dude3 == null){
            isNotBoom = false;
            CancelInvoke("GroupShoot");
        }
        if( oneDirection == -1)
        {
            float min = GetLeftEdge();
            min += speed*oneDirection;
            if(min <= -9.8){
                oneDirection *= -1;
            }else{
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    transform.position.z
                );
            }

        } else
        {
            float max = GetRightEdge();
            max += speed*oneDirection;
            if(max >= 9.84){
                oneDirection *= -1;
            }else{
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    transform.position.z
                );
            }

        }
        
    }

    float GetLeftEdge()
    {
        float min = float.MaxValue;
        for( int c = 0; c <sheep.Count; c++){
                if( sheep[c].transform.position.x < min ){
                    min = sheep[c].transform.position.x;
                }
        }
        return min;
    }

    float GetRightEdge()
    {
        float max = float.MinValue;
        for( int c = 0; c <sheep.Count; c++){
                if( sheep[c].transform.position.x > max ){
                    max = sheep[c].transform.position.x;
                }
        }
        return max;
    }
    void GroupShoot() {
        int RandomIndex = generator.Next(0, sheep.Count);
        sheep[RandomIndex].Shoot();
    }
}
