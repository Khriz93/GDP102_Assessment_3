using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // This doesn't work yet but it's a beginning... It doesn't break Unity at least

    Transform dung;
    Rigidbody rb;
    public float speed;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dung = GameObject.FindGameObjectWithTag("Dung").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (dung)
        {
            print("FoundDung");
            Vector3 direction = (dung.position - transform.position).normalized;
            moveDirection = direction;
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y) * speed;
        }
    }
}
