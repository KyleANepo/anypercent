using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour, IEnemy
{
    private float Health = 17f;
    private bool Ready;
    private bool Defeated;
    private float DamageTimer;
    private float AttackTimer = 5f;
    private Transform player;
    public Vector3 locationOffset;

    [SerializeField] private GameObject spawner;
    [SerializeField] private AudioClip die;
    [SerializeField] private CameraShake shake;
    [SerializeField] private GameObject block;
    [SerializeField] private AudioClip boom;
    [SerializeField] private GameObject winscreen;
    [SerializeField] private GameObject winkill;
    [SerializeField] private AudioClip winsound;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (Defeated) return;

        DamageTimer -= Time.fixedDeltaTime;
        AttackTimer -= Time.fixedDeltaTime;

        if (AttackTimer <= 0)
        {
            AttackTimer = Random.Range(5f, 7f);
            Attack();
        }
    }

    private void Attack()
    {
        shake.Shake();
        SFXManager.Instance.PlaySoundFXClip(boom, transform, 1f);
        GameObject projectile = Instantiate(block, player.transform.position + Quaternion.identity * locationOffset, transform.rotation);
        Destroy(projectile, 3f);
    }

    public void SetReady()
    {
        Ready = true;
        Debug.Log("Ready!");

        // set spawner to active
        spawner.SetActive(true);
    }

    public void Die()
    {
        if (!Ready || DamageTimer > 0 || Defeated) return;

        if (Health > 0)
        {
            Health -= 1;
            DamageTimer = 0.5f;
            SFXManager.Instance.PlaySoundFXClip(die, transform, 1f);
        } else if (Health <= 0)
        {
            // start end sequence
            Defeated = true;
            winscreen.SetActive(true);
            winkill.SetActive(true);
            SFXManager.Instance.PlaySoundFXClip(winsound, transform, 1f);
            Debug.Log("Boss defeated!");
            spawner.SetActive(false);
        }
    }
}
