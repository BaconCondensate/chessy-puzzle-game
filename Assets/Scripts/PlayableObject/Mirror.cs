using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mirror : PlayableObject
{
    [SerializeField] private int orientation = 0;
    [SerializeField] private GameObject LaserParticlePrefab;
    // Start is called before the first frame update
    

    protected override void Start()
    {
        base.Start();

        // Additional stuff specific for this type
        Player.OnPlayerMovementEvent +=refreshOrientation;
        
        this.Wait (0.1f, ()=>{
            grid.GetGridObject(transform.position).SetActive(false);
            refreshOrientation(initialOrientation);
        });
    }
    void OnDestroy(){
        Player.OnPlayerMovementEvent -=refreshOrientation;
    }






    private void refreshOrientation(object sender, Player.OnPlayerMovementEventArgs e){
        Quaternion newrotation = new Quaternion(0f,0f,0f,1);
        int i = 1;
        int j = 1;
        orientation += e.direction+1;

        this.Wait (0.001f, ()=>{
            if (orientation%2 == 0){
                newrotation.eulerAngles = new Vector3(0,0,45);
                transform.rotation = newrotation;

                while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(-j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;


                while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, -j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }







            }
            if (orientation%2 == 1){
                newrotation.eulerAngles = new Vector3(0,0,135);
                transform.rotation = newrotation;

                while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;


                while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(-j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, -j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
            }
        });
        
    }

    private void refreshOrientation(int initialOrientation){
        Quaternion newrotation = new Quaternion(0f,0f,0f,1);
        int i = 1;
        int j = 1;
        orientation = initialOrientation;

        this.Wait (0.001f, ()=>{
            if (orientation%2 == 0){
                newrotation.eulerAngles = new Vector3(0,0,45);
                transform.rotation = newrotation;

                while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(-j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;


                while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, -j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, -j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(-i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }







            }
            if (orientation%2 == 1){
                newrotation.eulerAngles = new Vector3(0,0,135);
                transform.rotation = newrotation;

                while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;


                while (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, -i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(-j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(-j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(i, 0) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(0, j) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(0, j) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
                i = 1;
                j = 1;

                while (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize())!=null)
                {
                    if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).damage==true){
                        //Debug.Log("active");
                    } else if (grid.GetGridObject(transform.position + new Vector3(0, i) * grid.GetCellSize()).active==false){
                        //Debug.Log("trigger mirror");
                        while (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize())!=null){
                            if (grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).active==true){    
                                grid.GetGridObject(transform.position + new Vector3(j, 0) * grid.GetCellSize()).SetDamage(true);
                                Instantiate(LaserParticlePrefab, transform.position + new Vector3(j, 0) * grid.GetCellSize(), Quaternion.identity);
                            } else{
                                break;
                            }
                            j++;
                        }
                        break;
                    } else{
                        break;
                    }
                    //Debug.Log(i);
                    i++;
                }
            }
        });
        
    }

}
