using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour, IEnemy
{
    [SerializeField] public float speed;
    [SerializeField] public float frequency;
    [SerializeField] public float magnitude;
    private float sinCenterY;
    
    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        sinCenterY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.Paused) return;

        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * magnitude;
        pos.x -= speed * Time.fixedDeltaTime;
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }

    public GameObject de;
    public AudioClip die;
    private SpriteRenderer SpriteRenderer;

    public void Die()
    {
        SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
        GameObject CE = Instantiate(de, transform.position, transform.rotation);
        CE.GetComponent<deatheffect>().entitySprite = SpriteRenderer.sprite;
        Destroy(CE, 1.5f);
        Destroy(gameObject);
    }
}
