using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float frequency;
    [SerializeField] public float magnitude;
    private float sinCenterY;
    private Transform player;

    //private Rigidbody2D rb;

    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        sinCenterY = transform.position.y;
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.Paused || !ready) return;

        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * magnitude;
        pos.x -= speed * Time.fixedDeltaTime;
        pos.y = sinCenterY + sin;

        transform.position = pos;

        if (player && player.transform.position.x - 10 > transform.position.x)
        {
            Debug.Log("eye left screen");
            Destroy(gameObject);
        }
    }

    public GameObject de;
    public AudioClip die;
    private SpriteRenderer SpriteRenderer;

    public void Die()
    {
        if (!ready) return;

        SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
        GameObject CE = Instantiate(de, transform.position, transform.rotation);
        CE.GetComponent<deatheffect>().entitySprite = SpriteRenderer.sprite;
        Destroy(CE, 1.5f);
        Destroy(gameObject);
    }

    public void SetReady()
    {
        ready = true;
        Debug.Log("Ready!");
    }
}
