using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    public float speed;

    public GameObject winUI;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
            rigidbody2d.velocity = new Vector2(0f,-speed);
        }
        else
        {
            rigidbody2d.velocity=new Vector2(0f, 0f);
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
        }
    }
}
