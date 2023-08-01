using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 100f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
    }
    private void OnTriggerEnter(Collider collision)     // This isn't currently working
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (collision.CompareTag("Ball"))
            {
                print("Grabbed!");
                collision.transform.SetParent(this.transform);
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            if (collision.CompareTag("Ball"))
            {
                print("Released!");
                collision.transform.SetParent(null);
            }
        }
    }
}
