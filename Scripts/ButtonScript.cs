using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonScript : MonoBehaviour
{
    public int number;
    public bool active;
    public float difButActAndNotAct;
    public Tilemap tilemap;
    public TileBase tile;
    public GameObject startChain;
    public String dir;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (difButActAndNotAct != 0)
        {
            if (difButActAndNotAct > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f,
                    transform.position.z);
                difButActAndNotAct -= 1;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f,
                    transform.position.z);
                difButActAndNotAct += 1;
            }
        }
    }



    public void changeActive()
    {
        if (active == false)
        {
            difButActAndNotAct = 2;
            drawChain();
            active = true;
        }
        else
        {
            difButActAndNotAct = -2;
            deleteChain();
            active = false;
        }
    }


    public void drawChain()
    {
        if (dir == "up")
        {
            for (int i = 0; i < number; i++)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x,
                                          (int)startChain.transform.position.y + i,
                                          (int)startChain.transform.position.z), tile);
            }
        }
        else if (dir == "down")
        {
            for (int i = 0; i < number; i++)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x,
                                          (int)startChain.transform.position.y - i,
                                          (int)startChain.transform.position.z), tile);
            }
        }
        else if (dir == "right")
        {
            for (int i = 0; i < number; i++)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x + i,
                                          (int)startChain.transform.position.y,
                                          (int)startChain.transform.position.z), tile);
            }
        }
        else if (dir == "left")
        {
            for (int i = 0; i < number; i++)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x - i,
                                          (int)startChain.transform.position.y,
                                          (int)startChain.transform.position.z), tile);
            }
        }


    }

    public void deleteChain()
    {
        if (dir == "up")
        {
            for (int i = number; i >= 0; i--)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x,
                                          (int)startChain.transform.position.y + i,
                                          (int)startChain.transform.position.z), null);
            }
        }
        else if (dir == "down")
        {
            for (int i = number; i >= 0; i--)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x,
                                          (int)startChain.transform.position.y - i,
                                          (int)startChain.transform.position.z), null);
            }
        }
        else if (dir == "right")
        {
            for (int i = number; i >= 0; i--)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x + i,
                                          (int)startChain.transform.position.y,
                                          (int)startChain.transform.position.z), null);
            }
        }
        else if (dir == "left")
        {
            for (int i = number; i >= 0; i--)
            {
                tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x - i,
                                          (int)startChain.transform.position.y,
                                          (int)startChain.transform.position.z), null);
            }
        }


    }
}
