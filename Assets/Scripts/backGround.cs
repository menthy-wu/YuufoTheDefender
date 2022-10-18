using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    [SerializeField] float speed; //when the player click a or d
    [SerializeField] float rightSide; // the  right side of the background
    [SerializeField] float leftSide;//the left Side of the backGround
    [SerializeField] GameObject gameManager;
    bool towardsRight = true;
    Vector3 trans;
    Queue que;
    int queLength = 60;
    void Start()
    {
        que = new Queue();
        for(int i  = 0; i< queLength; i++)
        {
            que.Enqueue(new Vector3(0,0,0)); 
        }
       // rb = GetComponent<Rigidbody2D>();
    }
    Vector3 getAvra(Queue que)
    {
        float x = 0;
        float y = 0;
        float z = 0;
        foreach(Vector3 vec in que)
        {
            x += vec.x;
            y += vec.y;
            z += vec.z;
        }
        x /= queLength;
        y /= queLength;
        z /= queLength;
        return new Vector3(x,y,z);
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        //transform.Translate(new Vector3(-speed * (Input.GetAxis("Horizontal")), 0, 0));
        trans = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            towardsRight = false;
            trans = new Vector3(-speed*(Input.GetAxis("Horizontal")), 0,0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            towardsRight = true;
           trans = new Vector3(-speed * (Input.GetAxis("Horizontal")), 0, 0);
        }
        que.Enqueue(trans);
        que.Dequeue();
        //Debug.Log(que.ToArray());
        transform.Translate(getAvra(que));
        // the background gets to the end of the left side
        if (transform.position.x > leftSide && !towardsRight)
        {
            transform.position = new Vector3(rightSide, transform.position.y, transform.position.z);
        }
        // the background gets to the end of the right side
        else if (transform.position.x < rightSide  && towardsRight)
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
        }
    }
}
