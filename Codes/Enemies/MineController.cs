using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector3 moveDirection;
    [SerializeField]float speed = 0.5f;
    [SerializeField] float remainTime;

    void Awake()
    {
    }
    void Start()
    {
        Destroy(gameObject, remainTime);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        moveDirection = (player.transform.position-transform.position).normalized;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
    }
}
