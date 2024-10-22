using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitbox;
    [SerializeField] private GameObject bullet;
    [SerializeField] AudioClip swing;
    [SerializeField] AudioClip toss;

    private bool pipe;
    private bool wrench;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pipe || wrench)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            AttackHigh();
        }

        animator.SetBool("pipe", pipe);
        animator.SetBool("wrench", wrench);
    }

    void Attack()
    {
        pipe = true;
        SFXManager.Instance.PlaySoundFXClip(swing, transform, .5f);
    }

    void AttackOver()
    {
        pipe = false;
    }

    void AttackHigh()
    {
        wrench = true;
        GameObject b = Instantiate(bullet, transform);
        Destroy(b, 2f);
        SFXManager.Instance.PlaySoundFXClip(toss, transform, .5f);
    }

    void AttackHighOver()
    {
        wrench = false;
    }

    public void HitboxOn()
    {
        hitbox.SetActive(true);
    }

    public void HitboxOff()
    {
        hitbox.SetActive(false);
    }
}
