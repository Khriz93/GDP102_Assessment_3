using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float jumpSpeed = 10f;
    public GameObject dungToBePickedUp;
    public GameObject dungHolder;


    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;
    private bool canPickUp;
    private bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        canPickUp = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, movement);
        transform.Rotate(0, rotation, 0);

        if (movement == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            /*
            Needs more work. When jumping if you run into something or hit something the player
            flips around
            */
            rb.velocity = new Vector3(0, jumpSpeed);
        }

        if (canPickUp == true)
        {
            if (Input.GetKey(KeyCode.E) && !hasItem)
            {
                /*
                Making the rigidbody for the dung kinematic so that its not acted upon by forces.
                Then placing the dung game object within the empty dung holder in front of the player.
                Also turned off the box collider for the dung game object as it was making the player fly
                backwards when picking it up again
                */
                dungToBePickedUp.GetComponent<Rigidbody>().isKinematic = true;
                dungToBePickedUp.transform.position = dungHolder.transform.position;
                dungToBePickedUp.transform.parent = dungHolder.transform;
                dungToBePickedUp.GetComponent<BoxCollider>().enabled = false;
                hasItem = true;
            }
        }

        if (Input.GetKey(KeyCode.Q) && hasItem == true)
        {
            // Releases the dung game object from the dung holder
            dungToBePickedUp.GetComponent<Rigidbody>().isKinematic = false;
            dungToBePickedUp.transform.parent = null;
            dungToBePickedUp.GetComponent<BoxCollider>().enabled = true;
            hasItem = false;
        }
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        // Checks for dung collision so it can be picked up
        if (collider.gameObject.tag == "Ball" && canPickUp == false)
        {
            Debug.Log("Grabbed!");
            dungToBePickedUp = collider.gameObject;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    
        // Checks to see if the player has exited the dung collider
        if (collider.gameObject.tag == "Ball")
        {
            Debug.Log("Released!");
            canPickUp = false;
        }
    }
}
