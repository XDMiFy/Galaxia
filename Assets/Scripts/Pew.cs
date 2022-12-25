using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pew : MonoBehaviour
{
    public SpriteRenderer BulletRenderer;
    float pewSpeed = 0.2f;
    public int pewDMG = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + pewSpeed,
            0
        );
        if( transform.position.y > 5){
            Destroy(gameObject);
        }
    }
}
