using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PlayableObject
{
    [SerializeField] protected int coinAmount=1;

    protected override void Start(){
        base.Start();
        if (grid!=null){
            grid.GetGridObject(transform.position).SetPickup(true);
        }
    }
    
    void Update(){
        if (grid!=null){
            if (grid.GetGridObject(transform.position).pickup==false){
                MainManager.AddScore(coinAmount);
                Destroy(gameObject, 0);
            }
        }
        
    }
}
