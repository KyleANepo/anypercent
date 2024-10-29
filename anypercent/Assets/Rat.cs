using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour, IEnemy
{
    public GameObject de;
    public AudioClip die;
    [SerializeField] public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.Paused) return;

        rb.velocity = new Vector2(-speed, rb.velocity.y);

        if (player && player.transform.position.x - 10 > transform.position.x)
        {
            Debug.Log("rat left screen");
            Destroy(gameObject);
        }
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
