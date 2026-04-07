using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MushroomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    [SerializeField] private float timer;
    void Start()
    {
        timer = 0f;
    }

  
    void Update()
    {
      shroomTimer();

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward);
        for (int i = 0; i < hits.Length; i++)
        {
            float distance = 5f;
            if (distance < 5F)
            {
               
            }
            
        
        }

            
        
    }

    public void shroomTimer()
    {
           timer += Time.deltaTime;
        if(timer > 5f)
        {
            SpawnShroom();
            timer = 0f;
            Debug.Log("shroom spawned");
        }  
    }

    
    public void SpawnShroom()
    {
      if (gameObject.tag == ("Timo"))
        {
            GameObject traps = Instantiate(prefab, transform.parent);
            traps.transform.position = transform.position; 

        }  
    }
}
