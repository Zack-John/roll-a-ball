using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpHeight = 300f;
    int count;
    int jumpCount;

    public Text countText;
    public Text winText;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        // set initial score display
        SetCountText();
        winText.text = "";
    }

    private void Update()
    {

        bool jump = Input.GetKeyDown(KeyCode.Space);

        if (jump)
        {
            if (jumpCount < 2)
            {
                rb.AddForce(Vector3.up * jumpHeight);
                jumpCount += 1;
            }
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // create movement vector, apply movement
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * speed);

        // if space key is pressed...
        
            // are we on the ground?
                // first jump
            // are we in the air?
                // have we already double jumped?
                    // double jump
    }

    private void OnTriggerEnter(Collider other)
    {

        // are we colliding with a pickup?
        if (other.gameObject.CompareTag("Pickup"))
        {
            // deactivate pickup
            other.gameObject.SetActive(false);

            // increment score, update UI
            count += 1;
            SetCountText();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // are we on the ground?
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    void SetCountText()
    {
        // update count text
        countText.text = "Count: " + count.ToString();

        // if we've collected all pickups...
        if (count >= 20)
        {
            // display win text
            winText.text = "You're Winner!";
        }

    }
}
