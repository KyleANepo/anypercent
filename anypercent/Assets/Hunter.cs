using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Hunter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject bullet;
    [SerializeField] AudioClip swing;
    [SerializeField] AudioClip toss;
    [SerializeField] AudioClip damage;
    [SerializeField] AudioClip die;

    private bool pipe;
    private bool wrench;

    private float horizontal;

    private Rigidbody2D rb;

    [SerializeField] float speed = 10.0f;
    [SerializeField] float jump = 2.0f;
    [SerializeField] float health = 5.0f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Paused) return;

        damageTimer -= Time.deltaTime;

        if (!isDamage)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (isDamage && damageTimer <= 0f)
        {
            isDamage = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            SFXManager.Instance.PlaySoundFXClip(toss, transform, .5f);
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (pipe || wrench)
        {
            if (!isDamage)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else if (Input.GetMouseButtonDown(1) && GameManager.Instance.wrenches > 0)
        {
            AttackHigh();
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        

        animator.SetBool("pipe", pipe);
        animator.SetBool("wrench", wrench);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
        GameManager.Instance.wrenches -= 1;
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

    private float damageTimer = 0f;
    private bool isDamage;

    

    public void Die()
    {
        if (damageTimer < 0f)
        {
            isDamage = true;
            if (GameManager.Instance.health > 1)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
                rb.AddForce(transform.up * 7f, ForceMode2D.Impulse);
                rb.AddForce(transform.right * -8f, ForceMode2D.Impulse);
                GameManager.Instance.health -= 1f;
                
                SFXManager.Instance.PlaySoundFXClip(damage, transform, 1f);
            }
            else
            {
                GameManager.Instance.health = 5f;
                GameManager.Instance.OnDeath();
                SFXManager.Instance.PlaySoundFXClip(damage, transform, 1f);
                Destroy(gameObject);
            }
            damageTimer = 0.5f;
        }
    }
}
