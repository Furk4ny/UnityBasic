using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public TextMeshProUGUI playerscoreText;
    public TextMeshProUGUI endGame;


    float speedAmoont = 5f;
    float jumpAmonut = 5.9f;
    public bool gameover = false;
    private bool isJumping;
    public int score;
    public int end;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        rgb = GetComponent<Rigidbody2D>();
        score= 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerscoreText.text = score.ToString();
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmoont * Time.deltaTime;


        if (Input.GetMouseButtonDown(0) && gameover)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rgb.AddForce(Vector3.up * jumpAmonut, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }       
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("dead"))
        {
            
            endGame.text = "GAME OVER!";
            gameover = true;
            Time.timeScale = 0f;          
        }

        if (collision.gameObject.CompareTag("zemin"))
        {
            isJumping = false;
        }
    }

}

