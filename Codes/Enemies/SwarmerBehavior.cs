using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmerBehavior : MonoBehaviour
{
    Vector3 trans;
    [SerializeField] float speed;
    [SerializeField] float MaxUp;
    [SerializeField] float MaxDown;
    [SerializeField] float MaxRight;
    [SerializeField] float MaxLeft;
     GameObject BackGround;
    // Start is called before the first frame update
    void Start()
    {
        BackGround = GameObject.Find("BackGround");
        int rand = Random.Range(0, 2);
        int rand2 = Random.Range(0, 2);
        if (rand == 0 && rand2 == 0)
        {
            trans = (new Vector3(-speed, speed, 0));
        }
        else if (rand == 1 && rand2 == 0)
        {
            trans = (new Vector3(speed, speed, 0));
        }
        else if (rand == 0 && rand2 == 1)
        {
            trans = (new Vector3(-speed, -speed, 0));
        }
        else if (rand == 1 && rand2 == 1)
        {
            trans = (new Vector3(speed, -speed, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (transform.position.x > MaxRight + BackGround.transform.position.x || transform.position.x < MaxLeft + BackGround.transform.position.x)
        {
            trans.x = -trans.x;
        }
        if (transform.position.y > MaxUp)
        {
            trans.y = -trans.y;
            transform.position = new Vector3(transform.position.x, MaxUp, transform.position.z);
        }
        if ( transform.position.y < MaxDown)
            {
            trans.y = -trans.y;
            transform.position = new Vector3(transform.position.x, MaxDown, transform.position.z);
        }
        transform.Translate(trans);
    }
}
