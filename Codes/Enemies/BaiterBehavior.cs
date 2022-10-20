using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaiterBehavior : MonoBehaviour
{
    private Vector3 startPos;
     GameObject player;
    public float speed = 2f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
