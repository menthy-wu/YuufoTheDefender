using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 startPos;

    float speed = 7f;

    Rigidbody2D rb;

    public GameObject player;
    // Start is called before the first frame update

    public Transform target;
    Vector2 moveDirection;
    private Transform myTransform;
    void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        target = player.transform;
        // rotate the projectile to aim the target:
        myTransform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        // distance moved since last frame:
        float amtToMove = speed * Time.deltaTime;
        // translate projectile in its forward direction:
        myTransform.Translate(Vector3.forward * amtToMove);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
