using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    //3d array for a world
    public GameObject tilePrefab;
    private Tile[,,] grid;
    
   

    int diameter;

    //  gameObject.GetComponent<Renderer>().material.color;

    private void Awake()
    {
        diameter = 5;
    }


    void Start()
    {
        SetUpGrid();        
    }


    void SetUpGrid()
    {

        grid = new Tile[diameter, diameter, diameter];

        if (grid != null)
        {

            for(int x = 0; x < grid.GetLength(0); x++)
            { 
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int z = 0; z < grid.GetLength(2); z++)
                    {
                        GameObject temp = Instantiate(tilePrefab, new Vector3((x - (diameter / 2) + 0.5f) , (y - (diameter / 2) + 0.5f) , (z - (diameter / 2) + 0.5f) ), Quaternion.identity);
                        

                        grid[x, y, z] = temp.GetComponent<Tile>();
                        grid[x, y, z].x = x;
                        grid[x, y, z].y = y;
                        grid[x, y, z].z = z;
                         
                    }
                }
            }

        }

    }

}






//public class GridController : MonoBehaviour
//{
//    [SerializeField]
//    public GameObject tilePrefab;
//    public GameObject coverTile;
//
//    public int width;
//    public int height;
//
//    Tile resourcesCentre;
//    public Tile[,] gridArray;
//    public GameObject[,] coverGrid;
//    public CoverTile[,] coverTileGrid;
//
//    private void Awake()
//    {
//        height = width = 16;
//    }
//
//    private void Start()
//    {
//        SetUpGrid();
//        // SetUpCoverGrid();
//    }
//
//
//
//    void SetRandSpot()
//    {
//        int tempInt = Random.Range(0, width * height - 1);
//
//        for (int x = 0; x < gridArray.GetLength(0); x++)
//        {
//            for (int y = 0; y < gridArray.GetLength(1); y++)
//            {
//                if (gridArray[x, y].id == tempInt)
//                {
//                    var tileRenderer = gridArray[x, y].tile.GetComponent<Renderer>();
//                    tileRenderer.material.SetColor("_Color", new Color(0, 1, 0, 1));
//
//
//                    gridArray[x, y].intensity = 100;
//                    gridArray[x, y].hasResources = true;
//                    gridArray[x, y].x = x;
//                    gridArray[x, y].y = y;
//
//                    resourcesCentre = gridArray[x, y];
//                }
//            }
//        }
//    }
//
//    void FillOutTiles(Tile tile)
//    {
//
//        for (int x = 0; x < gridArray.GetLength(0); x++)
//        {
//            for (int y = 0; y < gridArray.GetLength(1); y++)
//            {
//                if (!gridArray[x, y].hasResources)
//                {
//                    gridArray[x, y].intensity += 100 / (Mathf.Abs(tile.x - x) + Mathf.Abs(tile.y - y)) / 2;
//
//
//                    var tileRenderer = gridArray[x, y].tile.GetComponent<Renderer>();
//
//                    Color currentColor = gridArray[x, y].GetComponent<Renderer>().material.GetColor("_Color");
//
//                    float currR = gridArray[x, y].GetComponent<Renderer>().material.GetColor("_Color").r;
//                    float currG = gridArray[x, y].GetComponent<Renderer>().material.GetColor("_Color").g;
//                    float currB = gridArray[x, y].GetComponent<Renderer>().material.GetColor("_Color").b;
//
//
//                    float tempR = 1.0f / (Mathf.Abs(tile.x - x) + Mathf.Abs(tile.y - y)) / 2;
//                    float tempG = 0;
//                    float tempB = 1.0f / (Mathf.Abs(tile.x - x) + Mathf.Abs(tile.y - y)) / 2;
//
//                    tileRenderer.material.SetColor("_Color", new Color(currR - tempR, currG - tempG, currB - tempB));
//                }
//
//            }
//        }
//
//    }
//
//
//    public void SetUpGrid()
//    {
//        if (gridArray != null)
//        {
//            for (int x = 0; x < gridArray.GetLength(0); x++)
//            {
//                for (int y = 0; y < gridArray.GetLength(1); y++)
//                {
//                    Destroy(gridArray[x, y].tile);
//                    gridArray[x, y] = null;
//                }
//            }
//            gridArray = null;
//        }
//
//        gridArray = new Tile[width, height];
//
//        int counter = 0;
//
//        for (int x = 0; x < gridArray.GetLength(0); x++)
//        {
//            for (int y = 0; y < gridArray.GetLength(1); y++)
//            {
//                GameObject temp = Instantiate(tilePrefab, new Vector3((x - (height / 2) + 0.5f) * 0.5f, (y - (width / 2) + 0.5f) * 0.5f, 0), Quaternion.identity);
//
//                gridArray[x, y] = temp.GetComponent<Tile>();
//                gridArray[x, y].id = counter;
//                counter++;
//
//                gridArray[x, y].x = x;
//                gridArray[x, y].y = y;
//            }
//        }
//
//
//        for (int i = 0; i < (height * width) / 51.2f; i++)
//        {
//            SetRandSpot();
//            FillOutTiles(resourcesCentre);
//        }
//
//        SetUpCoverGrid();
//
//    }
//
//
//
//    public void SetUpCoverGrid()
//    {
//        if (coverTileGrid != null)
//        {
//            for (int x = 0; x < coverTileGrid.GetLength(0); x++)
//            {
//                for (int y = 0; y < coverTileGrid.GetLength(1); y++)
//                {
//                    Destroy(coverTileGrid[x, y].tile);
//                    coverTileGrid[x, y] = null;
//                }
//            }
//            coverTileGrid = null;
//        }
//
//
//        coverTileGrid = new CoverTile[width, height];
//
//        int counter = 0;
//
//        for (int x = 0; x < coverTileGrid.GetLength(0); x++)
//        {
//            for (int y = 0; y < coverTileGrid.GetLength(1); y++)
//            {
//
//                GameObject temp = Instantiate(coverTile, new Vector3((x - (height / 2) + 0.5f) * 0.5f, (y - (width / 2) + 0.5f) * 0.5f, 0), Quaternion.identity);
//                coverTileGrid[x, y] = temp.GetComponent<CoverTile>();
//                coverTileGrid[x, y].id = counter;
//                counter++;
//
//                coverTileGrid[x, y].x = x;
//                coverTileGrid[x, y].y = y;
//            }
//        }
//    }
//
//
//
//    void AddExtraSpots()
//    {
//
//    }
//
//}