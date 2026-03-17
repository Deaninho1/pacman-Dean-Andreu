using UnityEngine;

public class SpawnNodes : MonoBehaviour
{
    int numToSpawn = 8;
    public float currentSpawnOffSet;
    public float spawnoffset = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
       if (gameObject.name == "node")
        {
            currentSpawnOffSet = spawnoffset;
            for (int i = 0; i < numToSpawn; i++)
            {
                GameObject clone = Instantiate(gameObject, new Vector3(transform.position.x , transform.position.y + currentSpawnOffSet,0),Quaternion.identity);
                currentSpawnOffSet += spawnoffset;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
