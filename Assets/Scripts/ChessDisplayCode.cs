using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ChessDisplayCode : MonoBehaviour{  

    private Grid<MapStateObject> grid;
    private Mesh mesh;


    private void Awake(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(Grid<MapStateObject> grid) {
        this.grid = grid;
        UpdateVisual();

        //grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }

    private void UpdateVisual(){
        //MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0;x<grid.GetWidth();x++){
            for (int y = 0;y<grid.GetHeight();y++){
                int index = x * grid.GetHeight() + y;
                Debug.Log(index);
            }
        }
    }
}
