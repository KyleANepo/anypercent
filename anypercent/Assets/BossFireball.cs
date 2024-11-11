using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().GetComponent<Hunter>())
        {
            collision.GetComponent<Collider2D>().GetComponent<Hunter>().Die();
            Destroy(gameObject);
        }
    }
}
