using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantBehavior : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 startPos;
    GameObject player;
    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

       // rb = GetComponent<Rigidbody2D>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
