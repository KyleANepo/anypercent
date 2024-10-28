using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemCrate : MonoBehaviour, IEnemy
{
    [SerializeField] Sprite sprite;
    [SerializeField] Sprite sprite2;
    [SerializeField] GameObject crateVFX;
    [SerializeField] AudioClip crateSFX;
    [SerializeField] List<GameObject> items;
    private int index;
    private bool isBroken;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, items.Count);
    }

    public void Die()
    {
        if (isBroken) return;

        isBroken = true;
        SFXManager.Instance.PlaySoundFXClip(crateSFX, transform, 1f);
        GameObject CE = Instantiate(crateVFX, transform.position, transform.rotation);
        CE.GetComponent<deatheffect>().entitySprite = sprite;
        Destroy(CE, 1.5f);
        CE = Instantiate(crateVFX, transform.position, transform.rotation);
        CE.GetComponent<deatheffect>().entitySprite = sprite2;
        Destroy(CE, 1.5f);
        Instantiate(items[index], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
