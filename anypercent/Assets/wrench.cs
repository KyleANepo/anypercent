using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    private Rigidbody2D rb;
    private float thrust = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * 8f, ForceMode2D.Impulse);
        rb.AddForce(transform.right * 8f, ForceMode2D.Impulse);
        rb.AddTorque(10f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
