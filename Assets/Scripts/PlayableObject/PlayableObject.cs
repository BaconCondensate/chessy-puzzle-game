using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class PlayableObject : MonoBehaviour
{
    protected Grid<MapStateObject> grid;
    [SerializeField] protected int initialOrientation;

    

    public void SetGrid(object sender, ChessCode.OnGridSpawnEventArgs e) {
        this.grid = e.grid;
        //Debug.Log(grid);
        ChessCode.OnGridSpawnEvent -= SetGrid;
    }

    protected virtual void Start(){
        ChessCode.OnGridSpawnEvent += SetGrid;
    }
}
