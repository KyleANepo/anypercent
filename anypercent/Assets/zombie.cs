using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour, IEnemy
{
    public GameObject de;
    public AudioClip die;
    [SerializeField] public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.Paused) return;

        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void Die()
    {
        SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
        GameObject CE = Instantiate(de, transform.position, transform.rotation);
        CE.GetComponent<deatheffect>().entitySprite = SpriteRenderer.sprite;
        Destroy(CE, 1.5f);
        Destroy(gameObject);
    }
}
