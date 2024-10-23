using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject bullet;
    [SerializeField] AudioClip swing;
    [SerializeField] AudioClip toss;

    private bool pipe;
    private bool wrench;

    private float horizontal;

    private Rigidbody2D rb;

    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pipe || wrench)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            AttackHigh();
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        animator.SetBool("pipe", pipe);
        animator.SetBool("wrench", wrench);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void FixedUpdate()
    {
        if (pipe || wrench)
            return;
    }

    void Attack()
    {
        pipe = true;
        SFXManager.Instance.PlaySoundFXClip(swing, transform, .5f);
    }

    void AttackOver()
    {
        pipe = false;
    }

    void AttackHigh()
    {
        wrench = true;
        
    }

    void Throw()
    {
        GameObject b = Instantiate(bullet, transform);
        Destroy(b, 2f);
        SFXManager.Instance.PlaySoundFXClip(toss, transform, .5f);
    }

    void AttackHighOver()
    {
        wrench = false;
    }

    public void HitboxOn()
    {
        hitbox.SetActive(true);
    }

    public void HitboxOff()
    {
        hitbox.SetActive(false);
    }
}
