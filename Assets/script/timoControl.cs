using UnityEngine;

public class timoControl : MonoBehaviour
{
    public enum GhostNodeStatesEnum
    {
        hidden,
        startnode,
        movingInNodes
    }
    public GameObject TimoNodeStart;
    public PacMove pacMove;
    public GameObject StartingNode;

    public void ReachedCenterOfNode(NodeController nodeController)
    {
        
    }
    void awake()
    {
        pacMove = GetComponent<PacMove>();
        StartingNode = TimoNodeStart;
        pacMove.currentNode = StartingNode;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
