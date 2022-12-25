using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private float speed = 0.1f;

    public float healthPoints = 100f;
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;
    private float halfWidth;

    void Start()
    {
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void Update()
    {
        Vector3 newRPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
        Vector3 newLPos = new Vector3(transform.position.x - speed, transform.position.y, 0);
        Vector3 checkLPos = new Vector3(newLPos.x - halfWidth, newLPos.y, 0);
        Vector3 checkRPos = new Vector3(newRPos.x + halfWidth, newRPos.y, 0);

        if (Input.GetKey(KeyCode.D)) {
            bool check = ScreenHelpers.ObjectNah(checkRPos);
            if (check) {
                transform.position = newRPos; 
            }            
        }

        if (Input.GetKey(KeyCode.A)) {
            bool check = ScreenHelpers.ObjectNah(checkLPos);
            if (check) {
                transform.position = newLPos; 
            }
        }

         bool IsPew = Input.GetKey(KeyCode.K);
        if (IsPew == true){
            GameObject BulletClone = Instantiate(bullet);
            BulletClone.transform.position = transform.position;

        } 
    }
    void OnTriggerEnter2D(Collider2D Crash){
        GameObject theCauseOfCrash = Crash.gameObject;
        EnemyBullet evilPewScript = theCauseOfCrash.GetComponent<EnemyBullet>();
        if( evilPewScript != null){
            healthPoints -= evilPewScript.damage;
            Destroy(theCauseOfCrash);
            if(healthPoints <= 0){
                Destroy(gameObject);
            }
        }
    }
    

    
}
