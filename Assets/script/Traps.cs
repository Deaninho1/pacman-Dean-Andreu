using UnityEngine;

public class Traps : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            
            Player player = collision.gameObject.GetComponent<Player>();
            
            Destroy(gameObject);
            
        }

        if(collision.gameObject.tag == "Power")
        {
            
            Player player = collision.gameObject.GetComponent<Player>();
            
            Destroy(gameObject);
            
        }
    }
}
