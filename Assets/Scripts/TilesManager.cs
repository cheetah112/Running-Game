using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tiles;
    public float zSpawnPos = 30;
    public GameObject player;
    public float tileLenght = 30;
    private Queue<GameObject> listTile;
    private void Start() {
        listTile = new Queue<GameObject>();
    }
    private void Update() {
        if(zSpawnPos - player.transform.position.z < tileLenght * 5f)
        {
            SpawnTile(Random.Range(0,tiles.Length - 1));
        }
        if(listTile.Count > 6)
        {
            Destroy(listTile.Dequeue());
        }
    }
    private void SpawnTile(int tileIndex)
    {
        var tile = Instantiate(tiles[tileIndex]);
        tile.transform.position = Vector3.forward * zSpawnPos;
        zSpawnPos += tileLenght;
        listTile.Enqueue(tile);
    }
}
