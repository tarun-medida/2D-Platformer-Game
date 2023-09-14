using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float speed;

    public GameObject winUI;
    public GameObject pauseUI;
    public bool isGameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameWon)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rigidbody2d.velocity = new Vector2(speed, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rigidbody2d.velocity = new Vector2(-speed, 0f);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                rigidbody2d.velocity = new Vector2(0f, speed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rigidbody2d.velocity = new Vector2(0f, -speed);
            }
            else
            {
                rigidbody2d.velocity = new Vector2(0f, 0f);
            }
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            pauseUI.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            pauseUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            winUI.SetActive(true);
            isGameWon = true;
        }
    }

    public void RestartGame()
    {
        Debug.Log("Button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        isGameWon = true;
       
    }

    public void ResumeGame()
    {
        isGameWon = false;
    }
}
