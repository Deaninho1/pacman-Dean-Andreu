using UnityEngine;

public class PacPlayer : MonoBehaviour
{
    PacMove pacMove;
    void Start()
    {
        pacMove = GetComponent<PacMove>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            pacMove.setDirection("left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pacMove.setDirection("right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pacMove.setDirection("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pacMove.setDirection("down");
        }
    }
}
