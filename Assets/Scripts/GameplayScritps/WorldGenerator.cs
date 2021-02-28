using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    //3d array for a world
    public GameObject tilePrefab;
    public GameObject treasurePrefab;
    private Tile[,,] grid;


   public int treasureID;
   public  Vector3 treasureLocation;
    int diameter;

    //  gameObject.GetComponent<Renderer>().material.color;

    private void Awake()
    {
        diameter = 5;
    }


    void Start()
    {
        treasureLocation = new Vector3();
        treasureID = PickRandLocation();
        SetUpGrid();
        FillOutMap();
    }


    void SetUpGrid()
    {

        grid = new Tile[diameter, diameter, diameter];

        if (grid != null)
        {
            
            int counter = 0;
            for(int x = 0; x < grid.GetLength(0); x++)
            { 
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int z = 0; z < grid.GetLength(2); z++)
                    {
                        GameObject temp;
                        if(treasureID == counter)
                        {
                            temp = Instantiate(treasurePrefab, new Vector3((x - (diameter / 2) + 0.5f), (y - (diameter / 2) + 0.5f), (z - (diameter / 2) + 0.5f)), Quaternion.identity);
                            Debug.Log("treasure");
                        }
                        else
                        {
                            temp = Instantiate(tilePrefab, new Vector3((x - (diameter / 2) + 0.5f), (y - (diameter / 2) + 0.5f), (z - (diameter / 2) + 0.5f)), Quaternion.identity);
                        }
                        

                        grid[x, y, z] = temp.GetComponent<Tile>();
                        grid[x, y, z].body = temp;
                        grid[x, y, z].x = x;
                        grid[x, y, z].y = y;
                        grid[x, y, z].z = z;
                        grid[x, y, z].id = counter;
                        counter++;
                        if(treasureID == grid[x, y, z].id)
                        {
                            treasureLocation = new Vector3(x, y, z);
                        }
                    }
                }
            }

        }

    }


    int PickRandLocation()
    {
        //bool unFinished = true;
        int randInt = 0;
        randInt = Random.Range(diameter, diameter * diameter * diameter);
        // while (!unFinished)
        // {
        //     randInt = Random.Range(diameter, diameter * diameter * diameter);
        //     for (int x = 0; x < grid.GetLength(0); x++)
        //     {
        //         for (int y = 0; y < grid.GetLength(1); y++)
        //         {
        //             for (int z = 0; z < grid.GetLength(2); z++)
        //             {
        //                 if(grid[x,y,z].id ==randInt)
        //                 {
        //                     if((x+1)%5 != 0 && (y + 1) % 5 != 0 && (z + 1) % 5 != 0)
        //                     {
        //                         unFinished = false;
        //                     }
        //                 }
        //             }
        //         }
        //     }
        // }
        return randInt;
        
    }


    void FillOutMap()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int z = 0; z < grid.GetLength(2); z++)
                {

                    if(treasureID != grid[x,y,z].id)
                    {
                        float distance = 3 / ((Mathf.Abs(grid[x, y, z].x) - Mathf.Abs(treasureLocation.x) + 0.0001f) + (Mathf.Abs(grid[x, y, z].y) - Mathf.Abs(treasureLocation.y) + 0.0001f) + ((Mathf.Abs(grid[x, y, z].z) - Mathf.Abs(treasureLocation.z)) + 0.0001f));
                        grid[x, y, z].body.GetComponent<MeshRenderer>().material.color = new Color(distance*2, 1, 1);
                    }

                    
                  

                }
            }
        }
    }



    
}

