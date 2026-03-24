
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    public GameObject nodesContainer;
    public GhostNodeStatesEnum ghostNodeStates;

    List<NodeController> currentPath = new List<NodeController>();

    public void ReachedCenterOfNode(NodeController nodeController)
    {
        if (ghostNodeStates == GhostNodeStatesEnum.movingInNodes)
        {
           // Debug.Log("reached nodeController " + nodeController.gameObject.name);
            if (currentPath.Count > 1)
            {
                //Debug.Log("reached path " + currentPath[0].gameObject.name);
                currentPath.RemoveAt(0);
                //GotoRandomNode();
                pacMove.currentNode = currentPath[0].gameObject;
                Debug.Log("goto path " + pacMove.currentNode);
            }
            else
            {
                Debug.Log("reached path clear ");
                currentPath.Clear();
                GotoRandomNode();

            }

            // currentPath.Clear();

        }
    }

    // List<NodeController> open = new List<NodeController>(
    // );
    List<NodeController> closedList = new List<NodeController>();
    void FindPath(NodeController target)
    {
        NodeController[] nodeControllers = nodesContainer.transform.GetComponentsInChildren<NodeController>();
        for (int i = 0; i < nodeControllers.Length; i++)
        {
            Vector3 delta = gameObject.transform.position - nodeControllers[i].gameObject.transform.position;
            if (delta.magnitude < 0.5f)
            {
                StartingNode = nodeControllers[i].gameObject;
                break;

            }
            
        }
        //         open.AddRange(
        //         nodesContainer.transform.GetComponentsInChildren<NodeController>());
        NodeController current = pacMove.currentNode.GetComponent<NodeController>();
        // open.Remove(current);
        closedList.Clear();
        currentPath.Clear();
        closedList.Add(current);

        Debug.Log("current.connected" + current.connected.Count);
        foreach (var item in current.connected)
        {
            Debug.Log("item " + item);
            if (IteratePathFrom(item, target))
            {
               // if (current.HasConnected(currentPath[0])==false)//niet meer nodig gezien we de startnode nu goed zetten
                {
                    currentPath.Reverse();

                }
                pacMove.currentNode = currentPath[0].gameObject;
                Debug.Log("found path length " + currentPath.Count);
                foreach (NodeController n in currentPath)
                {
                    Debug.Log("node " + n.gameObject.name);

                }
                //we found something;
                break;
            }
        }
    }

    private bool IteratePathFrom(NodeController current, NodeController target)
    {
        closedList.Add(current);
        if (current == target)
        {
            currentPath.Add(current);
            //we found a path;
            Debug.Log("found path");
            return true;

        }
        else
        {
            foreach (var item in current.connected)
            {
                if (closedList.Contains(item) == false)
                {
                    if (IteratePathFrom(item, target))
                    {
                        currentPath.Add(current);
                        return true;
                    }
                }
            }

        }
        return false;
    }

    void Awake()
    {
        pacMove = GetComponent<PacMove>();
        StartingNode = TimoNodeStart;
        GotoRandomNode(73);

        // pacMove.currentNode = currentPath[0].gameObject;

    }
    void Start()
    {

        //pacMove = GetComponent<PacMove>();
        //StartingNode = TimoNodeStart;
    }

    // Update is called once per frame
    void Update()
    {





    }

    private void GotoRandomNode(int rng = -1)
    {
        if (currentPath.Count == 0)
        {
            NodeController[] nodeControllers = nodesContainer.transform.GetComponentsInChildren<NodeController>();
            if (nodeControllers.Length > 0 && nodeControllers.FirstOrDefault(i=>i.readyForPathfinding)!= null)
            {
                for (global::System.Int32 i = 0; i < nodeControllers.Length; i++)
                {
                    nodeControllers[i].gameObject.name = "node " + i;
                }

                NodeController target = nodeControllers[Random.Range(0, nodeControllers.Length)];
                if (rng != -1)
                {
                    target = nodeControllers[rng];

                }
               // target = nodeControllers[41];//debug
                Debug.Log("target " + target.gameObject.name);
                FindPath(target);
            }
        }
    }

    public void determineTimoDirection(string direction)
    {

    }
}
