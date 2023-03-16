using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Grid<MapStateObject> grid;
    private bool turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            //Vector3 quadSize = new Vector3(1,1) * grid.GetCellSize();
            //MapStateObject mapStateObject = grid.GetGridObject(transform.position);
            //mapStateObject.FlipActive();
            //Debug.Log(transform.position);
            if (grid.GetGridObject(transform.position + Vector3.up * grid.GetCellSize()).active == true){
                transform.position += Vector3.up * grid.GetCellSize();
                turn = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            //transform.position += Vector3.down;
            if (grid.GetGridObject(transform.position + Vector3.down * grid.GetCellSize()).active == true){
                transform.position += Vector3.down * grid.GetCellSize();
                turn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A)){
            //transform.position += Vector3.left;
            if (grid.GetGridObject(transform.position + Vector3.left * grid.GetCellSize()).active == true){
                transform.position += Vector3.left * grid.GetCellSize();
                turn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            //transform.position += Vector3.right;
            if (grid.GetGridObject(transform.position + Vector3.right * grid.GetCellSize()).active == true){
                transform.position += Vector3.right * grid.GetCellSize();
                turn = true;
            }
        }

        if (turn == true && grid.GetGridObject(transform.position).damage == true){
            turn = false;
            Debug.Log("damage");
        }
        
    }

    public void SetGrid(Grid<MapStateObject> grid) {
        this.grid = grid;
    }
}
