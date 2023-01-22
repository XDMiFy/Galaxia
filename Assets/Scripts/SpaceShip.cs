using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        Vector3 newUPos = new Vector3(transform.position.x, transform.position.y + speed, 0);
        Vector3 newDPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
        Vector3 checkUPos = new Vector3(newUPos.x, newUPos.y + halfWidth, 0);
        Vector3 checkDPos = new Vector3(newDPos.x, newDPos.y - halfWidth, 0);

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

        if (Input.GetKey(KeyCode.W)) {
            bool check = ScreenHelpers.ObjectNah(checkUPos);
            if (check) {
                transform.position = newUPos; 
            }            
        }

        if (Input.GetKey(KeyCode.S)) {
            bool check = ScreenHelpers.ObjectNah(checkDPos);
            if (check) {
                transform.position = newDPos; 
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
                SceneManager.LoadSceneAsync(ScreenIDs.LoseScreenID);
                Destroy(gameObject);
            }
        } else {
            WreckTeleg teleg = theCauseOfCrash.GetComponent<WreckTeleg>();
            if (teleg != null) {
                Destroy(theCauseOfCrash);
                SceneManager.LoadSceneAsync(ScreenIDs.LoseScreenID);
                Destroy(gameObject);
            }
        }
    }
    

    
}
