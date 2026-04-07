using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject WinUi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gym");
        Time.timeScale = 1;
        
    }
}
