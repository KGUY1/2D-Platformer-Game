using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEALTH : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    private Animator anim;
    private bool dead;
    public float currentHealth { get; private set; }
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float flashNumber;//number of flashes when hurt
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth>0)
        {
            //hurt animation
            anim.SetTrigger("hurt");
            //iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            //ded
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PLAYERMOVEMENT>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11,true);
        for (int i = 0; i < flashNumber; i++)//invulnerability duration
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFramesDuration / (flashNumber * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (flashNumber * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
