using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAFruit : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    //private bool follow = true;

    // Update is called once per frame
    /*void Update()
    {
        if (follow)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (distance > 0.4)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }*/
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            follow = true;
        }
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Ground"))
        {
            player = GameObject.FindGameObjectWithTag("Player");
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            if (distance < 0.4)
            {
                Destroy(gameObject);
                player.GetComponent<PlayerMove>().SumarFruta();
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }
}
