using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ChessCode : MonoBehaviour
{
    private Grid<MapStateObject> grid;
    [SerializeField] private ChessDisplayCode chessDisplayCode;
    [SerializeField] private Player player;
    private bool turn;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid<MapStateObject>(10, 5, 10f, Vector3.zero, (Grid<MapStateObject> g, int x, int y) => new MapStateObject(g, x, y));
        chessDisplayCode.SetGrid(grid);
        player.SetGrid(grid);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            MapStateObject mapStateObject = grid.GetGridObject(position);
            if (mapStateObject != null){
                mapStateObject.FlipActive();
           }
        }

        if (Input.GetMouseButtonDown(0)){
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            MapStateObject mapStateObject = grid.GetGridObject(position);
            if (mapStateObject != null){
                mapStateObject.FlipDamage();
           }
        }

        if (Input.GetKeyDown(KeyCode.F)){
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            MapStateObject mapStateObject = grid.GetGridObject(position);
            Debug.Log(mapStateObject.active);
        }
    }
}

public class MapStateObject{

    private Grid<MapStateObject> grid;
    private int x;
    private int y;

    public MapStateObject(Grid<MapStateObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
        //active = "";
        //damage = "";
        //objectspawn = "";
    }

    public bool active; //checks whether or not the grid is active and can be walked on
    public bool damage; //checks whether or not a grid will do damage
    public int objectspawn; //object type

    public void FlipActive(){
        active ^= true;
        grid.TriggerGridObjectChanged(x,y);
    }

    public void FlipDamage(){
        damage ^= true;
        grid.TriggerGridObjectChanged(x,y);
    }

    public override string ToString(){
        return active + "\n" + damage;
    }
}
