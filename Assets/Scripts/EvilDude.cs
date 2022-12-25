using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilDude : MonoBehaviour
{
    public GameObject bulletExample;
    public int evilHP = 50;
    private SpriteRenderer pulpyRenderer;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        pulpyRenderer = GetComponent<SpriteRenderer>();
        halfWidth = pulpyRenderer.bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D( Collider2D col)
    {
        GameObject pew = col.gameObject;
        Pew pewScript = pew.GetComponent<Pew>();
        if (pewScript != null)
        {
            evilHP -= pewScript.pewDMG;
            if (evilHP <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(pew);
        }
    }
    public void Shoot(){
        GameObject clone = Instantiate(bulletExample);
        clone.transform.position = transform.position;
    }
}
