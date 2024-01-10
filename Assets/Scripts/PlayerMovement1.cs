using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed;
    public Rigidbody playerRigidbody;
    public int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            
            score++;
            scoretext.text = "Coins Collected = " + score;
            if (score == 4)
            {
                SceneManager.LoadScene("GameWin");
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
