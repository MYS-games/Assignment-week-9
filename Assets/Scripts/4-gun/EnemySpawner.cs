using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemySpawne;
   // [SerializeField] GameObject muzzleFlash;
    [SerializeField] Terrain terrain;
    [SerializeField] float yOffset = 0.5f;
    [SerializeField] float numberOfEnemies = 5f;
    [SerializeField] float timeBetweenSpawns = 2f;
    private float terrainWidth;
    private float terrainLength;

    private float xTerrainPos;
    private float zTerrainPos;

    void Start()
    {
        //Get terrain size
        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

        //Get terrain position
        xTerrainPos = terrain.transform.position.x;
        zTerrainPos = terrain.transform.position.z;

        this.StartCoroutine(generateObjectOnTerrain());
    }
    private IEnumerator generateObjectOnTerrain()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            //Generate random x,z,y position on the terrain
            float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
            float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
            float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

            //Apply Offset if needed
            yVal = yVal + yOffset;
            GameObject objInstance = (GameObject)Instantiate(enemySpawne, new Vector3(randX, yVal, randZ), Quaternion.identity);

        }
      
      
    }

    // Update is called once per frame
    void Update()
    {
        var enemyNumber = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if (enemyNumber < numberOfEnemies)
        {
            float randX = UnityEngine.Random.Range(xTerrainPos, xTerrainPos + terrainWidth);
            float randZ = UnityEngine.Random.Range(zTerrainPos, zTerrainPos + terrainLength);
            float yVal = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));

            //Apply Offset if needed
            yVal = yVal + yOffset;
          //  Enemy t = enemySpawne.GetComponent<Enemy>();
           
            GameObject objInstance = (GameObject)Instantiate(enemySpawne, new Vector3(randX, yVal, randZ), Quaternion.identity);
           // GameObject flameInstance = (GameObject)Instantiate(muzzleFlash, new Vector3(randX, yVal, randZ), Quaternion.identity);

        }
    }
}
