using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 0.1f;
    public int damage = 100;
    
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
        bool check = ScreenHelpers.ObjectNah(newPos);

        if (!check) {
            Destroy(gameObject);
        } else {
            transform.position = newPos;
        }    
    }
}
