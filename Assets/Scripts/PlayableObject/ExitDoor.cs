using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : PlayableObject
{
    protected override void Start(){
        base.Start();
        this.Wait (0.1f, ()=>{
            grid.GetGridObject(transform.position).SetExit(true);
        });
    }
}
