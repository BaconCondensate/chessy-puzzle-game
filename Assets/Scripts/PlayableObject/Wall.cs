using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Wall : PlayableObject
{
    // Start is called before the first frame update
    

    protected override void Start()
    {
        base.Start();
        
        this.Wait (0.1f, ()=>{
            grid.GetGridObject(transform.position).SetActive(false);
        });
    }
}
