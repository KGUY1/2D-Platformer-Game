using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEALTHCOLLECTIBLE : MonoBehaviour
{
    [SerializeField]private float healthValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<HEALTH>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
}
