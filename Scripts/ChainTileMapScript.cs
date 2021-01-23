using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChainTileMapScript : MonoBehaviour
{
    public int number;
    public Tilemap tilemap;
    public TileBase tile;
    public GameObject startChain;
    // Start is called before the first frame update
    void Start()
    {
        tilemap.SetTile(new Vector3Int((int)startChain.transform.position.x,
                                       (int)startChain.transform.position.y,
                                       (int)startChain.transform.position.z), tile);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
