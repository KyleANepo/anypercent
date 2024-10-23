using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deatheffect : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Sprite entitySprite;
    private float thrust = 6f;

    // Start is called before the first frame update
    void Start()
    {
        DeathEffect();
    }

    void DeathEffect()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        sprite.sprite = entitySprite;

        rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        rb.AddForce(transform.right * Random.Range(-2f, 2f), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-4f, 4f), ForceMode2D.Impulse);
    }

}
