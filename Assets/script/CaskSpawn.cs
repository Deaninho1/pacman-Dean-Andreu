using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CaskSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    [SerializeField] private float timer;
    void Start()
    {
        timer = 0f;
    }

  
    void Update()
    {
      CaskTimer();

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward);
        for (int i = 0; i < hits.Length; i++)
        {
            float distance = 5f;
            if (distance < 5F && gameObject.tag == "Cask")
            {
               gameObject.tag = "NoSpawn";
            }
            else
            {
                gameObject.tag = "CaskSpawn";
            }
            
        
        }

            
        
    }

    public void CaskTimer()
    {
           timer += Time.deltaTime;
        if(timer > 10f)
        {
            SpawnCask();
            timer = 0f;
            Debug.Log("Cask spawned");
        }  
    }

    
    public void SpawnCask()
    {
      if (gameObject.tag == ("CaskSpawn"))
        {
            GameObject capsule = Instantiate(prefab, transform.parent);
            capsule.transform.position = transform.position; 

        }  
    }
}
