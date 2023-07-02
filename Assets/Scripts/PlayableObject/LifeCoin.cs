using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCoin : PlayableObject
{
    [SerializeField] protected int lifeAmount=1;

    protected override void Start(){
        base.Start();
        if (grid!=null){
            grid.GetGridObject(transform.position).SetPickup(true);
        }
    }
    
    void Update(){
        if (grid!=null){
            if (grid.GetGridObject(transform.position).pickup==false){
                MainManager.AddLife(lifeAmount);
                Destroy(gameObject, 0);
            }
        }
        
    }
}
