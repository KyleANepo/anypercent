using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterTransition : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5f, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }
}
