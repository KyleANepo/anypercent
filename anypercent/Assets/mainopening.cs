using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainopening : MonoBehaviour
{

    [SerializeField] AudioClip title;

    public void Finished()
    {
        SFXManager.Instance.PlaySoundFXClip(title, transform, 1f);
        Destroy(gameObject);
    }
}
