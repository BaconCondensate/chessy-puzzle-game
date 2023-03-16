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

        grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
    }

    private void Grid_OnGridObjectChanged(object sender, Grid<MapStateObject>.OnGridObjectChangedEventArgs e){
        Debug.Log("Grid_OnGridValueChanged");
        UpdateVisual();
    }

    private void UpdateVisual(){
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0;x<grid.GetWidth();x++){
            for (int y = 0;y<grid.GetHeight();y++){
                int index = x * grid.GetHeight() + y;
                //Debug.Log(index);
                Vector3 quadSize = new Vector3(1,1) * grid.GetCellSize();

                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x,y) + quadSize*0.5f, 0f, quadSize, Vector2.zero, Vector2.zero);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
