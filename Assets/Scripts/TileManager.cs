using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

    public GameObject[] tiles;

    private float spawnZ = -20f;
    private float tileLength = 20f;
    private float safeZone = 20f;
    private int tilesOnScreen = 5;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
	}

    

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tiles[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tiles[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tiles.Length <= 1)
            return 0;

        int RandomIndex = lastPrefabIndex;
        while (RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, tiles.Length);
        }

        lastPrefabIndex = RandomIndex;
        return RandomIndex;
    }
}
