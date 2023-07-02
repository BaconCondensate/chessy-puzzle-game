using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : PlayableObject
{

    [SerializeField] private int orientation = 0;
    [SerializeField] private GameObject LaserParticlePrefab;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // Additional stuff specific for this type
        Player.OnPlayerMovementEvent +=refreshOrientation;
        ChessCode.OnGridSpawnEvent += SetGrid;


        this.Wait (0.1f, ()=>{
            grid.GetGridObject(transform.position).SetActive(false);
            refreshOrientation(initialOrientation);
            //Debug.Log("NOOOOO");
        });
    }
    void OnDestroy(){
        Player.OnPlayerMovementEvent -=refreshOrientation;
        ChessCode.OnGridSpawnEvent -= SetGrid;
    }
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(grid);
        //Debug.Log(GameObject.Find("Visual").GetComponent<ChessCode>());
    }


    private void refreshOrientation(object sender, Player.OnPlayerMovementEventArgs e){
        Quaternion newrotation = new Quaternion(0f,0f,0f,1);
        int i = 1;
        if (e.direction%2 != 0){
            orientation += e.direction ;
        } else {orientation += 2;}
        

        

        if (orientation%4 == 0)
        {
            newrotation.eulerAngles = new Vector3(0,0,0);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, i) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 1){
            newrotation.eulerAngles = new Vector3(0,0,90);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(-i, 0) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 2)
        {
            newrotation.eulerAngles = new Vector3(0,0,180);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, -i) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 3)
        {
            newrotation.eulerAngles = new Vector3(0,0,270);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(i, 0) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        }
    }


    private void refreshOrientation(int initialOrientation){
        Quaternion newrotation = new Quaternion(0f,0f,0f,1);
        int i = 1;
        orientation = initialOrientation;

        

        if (orientation%4 == 0)
        {
            newrotation.eulerAngles = new Vector3(0,0,0);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, i) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 1){
            newrotation.eulerAngles = new Vector3(0,0,90);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(-i, 0) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 2){
            newrotation.eulerAngles = new Vector3(0,0,180);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, -i) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        } else if (orientation%4 == 3){
            newrotation.eulerAngles = new Vector3(0,0,270);
            transform.rotation = newrotation;

            while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null){
                if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==true){    
                    grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).SetDamage(true);
                    Instantiate(LaserParticlePrefab, transform.position + new Vector3(i, 0) * grid.GetCellSize(), Quaternion.identity);
                } else{
                    break;
                }
                i++;
            }
        }
    }

}
