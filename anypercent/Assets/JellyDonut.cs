using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyDonut : MonoBehaviour
{
    [SerializeField] float healthRecovered = 3f;
    [SerializeField] AudioClip powerupSFX;


    public void IncreaseHealth()
    {
        SFXManager.Instance.PlaySoundFXClip(powerupSFX, transform, 1f);
        GameManager.Instance.health = 5f;
        Destroy(gameObject);
    }

    public void ItemGone()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().GetComponent<Hunter>())
        {
            IncreaseHealth();
        }
    }
}
