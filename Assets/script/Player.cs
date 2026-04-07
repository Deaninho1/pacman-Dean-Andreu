using System.Collections;


using Unity.VisualScripting;
using UnityEditor;


using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    public int Health = 100;
    public GameObject WinUI;
    public enum VargasModes
    {
        Normal,

        PoweredUp
    }

    public VargasModes CurrentVargasModes;
    public Image healthImage;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       healthImage.fillAmount = Health/100f;

       if (CurrentVargasModes == VargasModes.PoweredUp)
        {
            gameObject.tag = "Power";
            Debug.Log("POWERRR");
        }
        else
        {
            gameObject.tag = "Player";
        }

    
    }
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Damage" && gameObject.tag == "Player")
        {
            
            Health -= 25;
            
            if (Health <= 0)
            {
                Die();
            }

            Debug.Log("Damage taken");
        }

        if(collision.gameObject.tag == "Cask")
        {
            if (CurrentVargasModes == VargasModes.Normal)
            {
                CurrentVargasModes = VargasModes.PoweredUp;
            }
            else
            {
                CurrentVargasModes = VargasModes.Normal;
            }

            Debug.Log("POWER");
            
        }
        
        if(collision.gameObject.tag == "Damage" && CurrentVargasModes == VargasModes.PoweredUp)
        {
            CurrentVargasModes = VargasModes.Normal;
        }

         if (collision.gameObject.tag == "Timo" && gameObject.tag == "Power")
        {
            Time.timeScale = 0;
            WinUI.SetActive(true); 
        }

    } 

    
  
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    
}
