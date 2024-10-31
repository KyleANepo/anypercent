using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareNoise : MonoBehaviour
{
    [SerializeField] AudioClip scare;
    bool played;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().GetComponent<Hunter>() && !played)
        {
            SFXManager.Instance.PlaySoundFXClip(scare, transform, 1f);
            played = true;
        }
    }
}
