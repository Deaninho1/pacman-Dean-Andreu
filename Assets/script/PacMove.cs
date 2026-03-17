using UnityEngine;

public class PacMove : MonoBehaviour
{
    public GameObject currentNode;
    public float MS = 5f;

    public string direction = "";
    public string LastMovingDirection = "";
    public bool isTimo = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       NodeController currentNodecontroller = currentNode.GetComponent<NodeController>(); 

       transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, MS*Time.deltaTime);

       if (transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y)
        {
            if (isTimo)
            {
                GetComponent<timoControl>().ReachedCenterOfNode(currentNodecontroller);
            }
          GameObject newNode = currentNodecontroller.GetNodeFromDirection(direction);
          if(newNode != null)
            {
                currentNode = newNode;
                LastMovingDirection = direction;
            }
            else
            {
                direction = LastMovingDirection;
                newNode = currentNodecontroller.GetNodeFromDirection(direction);
                if(newNode != null)
                {
                    currentNode = newNode;
                }
            } 
        }
    }

    public void setDirection(string newDirection)
    {
        direction = newDirection;
    }
}
