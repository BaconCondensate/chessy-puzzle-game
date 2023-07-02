using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;



public class LaserParticle : PlayableObject
{
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //ChessCode.OnMovementEvent += DestroyObject;
    }
    void Update(){
        if (grid==null||particleSystem==null)
        {
            DestroyObject(0f);
        }
        if (grid.GetGridObject(transform.position).damage==false){
            DestroyObject(1f);
        }
    }
    private void OnDestroy(){
        ChessCode.OnGridSpawnEvent -= SetGrid;
    }

    /*private void DestroyObject(object sender, ChessCode.OnMovementEventArgs e){
        if (gameObject!=null){
            Destroy(gameObject, 1f);
        }
        
    }*/

    private void DestroyObject(float time){
        if (particleSystem!=null){
            particleSystem.Stop();
        }
        if (gameObject!=null){
            Destroy(gameObject, time);
        }
    }

    
}
