using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchItem : MonoBehaviour
{
    [SerializeField] AudioClip powerupSFX;

    public void IncreaseHealth()
    {
        SFXManager.Instance.PlaySoundFXClip(powerupSFX, transform, 1f);
        GameManager.Instance.wrenches += 3;
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
