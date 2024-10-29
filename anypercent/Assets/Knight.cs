using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour, IEnemy
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitbox;
    public GameObject de;
    public AudioClip die;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;

    [SerializeField] private float health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer -= Time.deltaTime;
        animator.SetBool("IsPlayer", IsPlayer());
    }

    bool IsPlayer()
    {
        return Physics2D.OverlapCircle(playerCheck.position, 0.2f, playerLayer);
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

    public void Die()
    {
        if (damageTimer < 0f)
        {
            SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
            health -= 1f;
        }

        if (health < 0f)
        {
            SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
            GameObject CE = Instantiate(de, transform.position, transform.rotation);
            CE.GetComponent<deatheffect>().entitySprite = SpriteRenderer.sprite;
            Destroy(CE, 1.5f);
            Destroy(gameObject);
            damageTimer = 1f;
        }
    }
}
