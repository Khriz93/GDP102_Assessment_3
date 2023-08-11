using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconController : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed = 1;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, posA.position) < 0.1f) targetPos = posB.position;

        if (Vector3.Distance(transform.position, posB.position) < 0.1f) targetPos = posA.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }
}
