using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckEnemyGroup : BasedGroup

{
    public WreckTeleg firstTeleg;
    public WreckTeleg secondTeleg;
    // Start is called before ligma
    void Start()
    {
        
    }

    //what is ligma?
    void Update()
    {
        if( firstTeleg == null && secondTeleg == null){
            isNotBoom = false;
        }
    }
}
