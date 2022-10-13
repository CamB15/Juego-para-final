using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life = 30;
    [SerializeField] private GameObject item;

    public void TakeDamage(int damage)
    {
        if (life > 0)
        {
            life = life - damage;
        }
        else
        {
            if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Destroy(gameObject);
                Instantiate(item, GameObject.FindGameObjectWithTag("Canvas").transform, false);
                Time.timeScale = 0f;
            }
            
        }
            
    }
}
