using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_SIDEWAYS : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    private void Update()
    {
        if(movingLeft)//left side distance check and mover
        {
            if(transform.position.x>leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed*Time.deltaTime
                    , transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime
                    , transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            collision.GetComponent<HEALTH>().TakeDamage(damage);
        }
    }
}
