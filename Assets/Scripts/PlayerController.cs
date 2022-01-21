using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    



    public float jumpSpeed = 0.1f;

    public bool jump;


    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private int count;

    public float speed = 2000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
        jump = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Salta");
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
        }



    }


    private void OnTriggerStay(Collider other)
    {
        print("toca el piso");
        jump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        print(" No toca el piso");
        jump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            other.gameObject.SetActive(false);
            this.SetCountText();
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 7)
        {
            winTextObject.SetActive(true);
        }
    }

}
