using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : PlayableObject
{
    //temporary
    public GameObject UI_Win;
    public GameObject UI_Lose;


    [SerializeField] private float moveSpeed = 5f;
    public Transform movePoint;
    private bool canMove = true;

    public static event EventHandler<OnPlayerMovementEventArgs> OnPlayerMovementEvent;
    public class OnPlayerMovementEventArgs : EventArgs {
        public int direction;
    }

    //private bool turn;
    //private Grid<MapStateObject> grid;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        movePoint.parent = null;
        GameObject.Find("Button_Continue").GetComponent<Button>().interactable = false;

        // Additional stuff specific for this type
        ChessCode.OnMovementEvent += PlayerMovement;
    }
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        grid.GetGridObject(transform.position).SetPickup(false);
        
    }
    void OnDestroy(){
        ChessCode.OnMovementEvent -= PlayerMovement;
    }

    private void PlayerMovement(object sender, ChessCode.OnMovementEventArgs e){
        if (Vector3.Distance(transform.position, movePoint.position)<=.05f && canMove == true){
        switch (e.direction)
        {
            case 0:
                if (grid.GetGridObject(movePoint.position + Vector3.up * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(movePoint.position + Vector3.up * grid.GetCellSize()).active == true){


                        int height, width;
                        height = grid.GetHeight();
                        width = grid.GetWidth();
                        for (int x = 0; x < width; x++) {
                            for (int y = 0; y < height; y++) {
                                MapStateObject mapStateObject = grid.GetGridObject(x, y);
                                mapStateObject.SetDamage(false);
                            }
                        }


                        OnPlayerMovementEvent?.Invoke(this, new OnPlayerMovementEventArgs { direction = e.direction });
                        movePoint.position += Vector3.up * grid.GetCellSize();
                    }
                }
                break;
            case 1:
                if (grid.GetGridObject(movePoint.position + Vector3.left * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(movePoint.position + Vector3.left * grid.GetCellSize()).active == true){


                        int height, width;
                        height = grid.GetHeight();
                        width = grid.GetWidth();
                        for (int x = 0; x < width; x++) {
                            for (int y = 0; y < height; y++) {
                                MapStateObject mapStateObject = grid.GetGridObject(x, y);
                                mapStateObject.SetDamage(false);
                            }
                        }




                        OnPlayerMovementEvent?.Invoke(this, new OnPlayerMovementEventArgs { direction = e.direction });
                        movePoint.position += Vector3.left * grid.GetCellSize();
                    }
                }
                break;
            case 2:
                if (grid.GetGridObject(movePoint.position + Vector3.down * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(movePoint.position + Vector3.down * grid.GetCellSize()).active == true){


                        int height, width;
                        height = grid.GetHeight();
                        width = grid.GetWidth();
                        for (int x = 0; x < width; x++) {
                            for (int y = 0; y < height; y++) {
                                MapStateObject mapStateObject = grid.GetGridObject(x, y);
                                mapStateObject.SetDamage(false);
                            }
                        }



                        OnPlayerMovementEvent?.Invoke(this, new OnPlayerMovementEventArgs { direction = e.direction });
                        movePoint.position += Vector3.down * grid.GetCellSize();
                    }
                }
                break;
            case 3:
                if (grid.GetGridObject(movePoint.position + Vector3.right * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(movePoint.position + Vector3.right * grid.GetCellSize()).active == true){


                        int height, width;
                        height = grid.GetHeight();
                        width = grid.GetWidth();
                        for (int x = 0; x < width; x++) {
                            for (int y = 0; y < height; y++) {
                                MapStateObject mapStateObject = grid.GetGridObject(x, y);
                                mapStateObject.SetDamage(false);
                            }
                        }



                        OnPlayerMovementEvent?.Invoke(this, new OnPlayerMovementEventArgs { direction = e.direction });
                        movePoint.position += Vector3.right * grid.GetCellSize();
                    }
                }
                break;
            default:
                break;
        }}
        
        this.Wait(0.2f, ()=>{
            



            if(grid.GetGridObject(movePoint.position).exit == true){
                canMove = false;
                //Instantiate(UI_Win, new Vector3(100, 100), Quaternion.identity);
                GameObject.Find("Button_Continue").GetComponent<Button>().interactable = true;
                Destroy(gameObject);
            } else if (grid.GetGridObject(movePoint.position).damage == true){
                canMove = false;
                MainManager.LoseLife();
                if (MainManager.Instance.Life > 0){
                    //Instantiate(UI_Lose, new Vector3(100, 100), Quaternion.identity);
                    Destroy(gameObject);

                    int height, width;
                    height = grid.GetHeight();
                    width = grid.GetWidth();
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            MapStateObject mapStateObject = grid.GetGridObject(x, y);
                            mapStateObject.SetDamage(false);
                        }
                    }
                    
                } else {
                    //Instantiate(UI_Lose, new Vector3(100, 100), Quaternion.identity);
                    GameObject.Find("Button_Restart").GetComponent<Button>().interactable = false;
                    Destroy(gameObject);

                    int height, width;
                    height = grid.GetHeight();
                    width = grid.GetWidth();
                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            MapStateObject mapStateObject = grid.GetGridObject(x, y);
                            mapStateObject.SetDamage(false);
                        }
                    }
                }
                
            }

            
            


        });
        
    }



}
