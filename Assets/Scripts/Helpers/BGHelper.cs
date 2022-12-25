using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( bgRenderer != null){
            bgRenderer.material.mainTextureOffset = new Vector2(0.1f*Time.time,0f);
        }
    }
    public Renderer bgRenderer;
}
