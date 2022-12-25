using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip123 : MonoBehaviour
{
    float woosh = 0.1f;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isKeyLeft = Input.GetKey(KeyCode.A);
        if (isKeyLeft == true){
                transform.position = new Vector3(transform.position.x - 2*woosh, transform.position.y, 0);
        }
        bool isKeyRight = Input.GetKey(KeyCode.D);
        if (isKeyRight == true){
                transform.position = new Vector3(transform.position.x + 2*woosh, transform.position.y, 0);
        }
        bool isKeyUp = Input.GetKey(KeyCode.W);
        if (isKeyUp == true){
                transform.position = new Vector3(transform.position.x, transform.position.y + woosh, 0);
        }
        bool isKeyDown = Input.GetKey(KeyCode.S);
        if (isKeyDown == true){
                transform.position = new Vector3(transform.position.x, transform.position.y - woosh, 0);
        }
        bool IsPew = Input.GetKeyUp(KeyCode.K);
        if (IsPew == true){
            GameObject BulletClone = Instantiate(bullet);
            BulletClone.transform.position = transform.position;

        } 
    }
}
