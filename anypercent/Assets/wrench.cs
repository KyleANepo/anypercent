using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrench : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.up * 18f, ForceMode2D.Impulse);
        rb.AddForce(transform.right * 8f, ForceMode2D.Impulse);
        rb.AddTorque(20f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
