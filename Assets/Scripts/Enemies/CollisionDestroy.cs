using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyProjectile" || collision.gameObject.tag == "Lander" || collision.gameObject.tag == "Cow")
        {
            Debug.Log("collided");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Pod")
        {
            Debug.Log("Pod destroyed");
            FindObjectOfType<PodBehavior>().Burst();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
