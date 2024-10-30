using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeKnight : MonoBehaviour, IEnemy
{
    public GameObject de;
    public AudioClip die;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;

    [SerializeField] private float health;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip toss;

    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer -= Time.deltaTime;

        if (player && player.transform.position.x - 10 > transform.position.x)
        {
            Debug.Log("axeman left screen");
            Destroy(gameObject);
        }
    }

   public void AxeThrow()
    {
        GameObject b = Instantiate(bullet, transform);
        Destroy(b, 2f);
        SFXManager.Instance.PlaySoundFXClip(toss, transform, .5f);
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
