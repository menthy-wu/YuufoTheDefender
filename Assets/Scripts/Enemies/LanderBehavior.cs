using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderBehavior : MonoBehaviour
{
    public bool connectedCow = false;
    float timer;
    Vector3 trans;
    GameObject bulletHolder;
    GameObject BackGround;
    //Rigidbody2D rb;
    [SerializeField] float fireRate ;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject mutant;
    [SerializeField] float speed;
    [SerializeField] float MaxUp;
    [SerializeField] float MaxDown;
    [SerializeField] float MaxRight;
    [SerializeField] float MaxLeft;

    void Start ()
    {
        timer = 0f;
       // rb = GetComponent<Rigidbody2D>();
        bulletHolder = GameObject.Find("BulletsHolder");
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
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (connectedCow && transform.position.y>=MaxUp)
        {
            GameObject Enemy = GameObject.Find("Enemies");
            GameObject mutantt = Instantiate(mutant, transform.position, Quaternion.identity);
            mutantt.transform.parent = Enemy.transform;
            Destroy(gameObject);
        }
       if (transform.position.x>MaxRight+ BackGround.transform.position.x || transform.position.x<MaxLeft+ BackGround.transform.position.x)
        {
            trans.x = -trans.x;
        }
        if (transform.position.y>MaxUp || transform.position.y<MaxDown)
        {
            trans.y = -trans.y;
        }
        if (connectedCow)
            trans = new Vector3(0, speed, 0);
        transform.Translate(trans);
        CheckIfTimeToFire();
        Transform[] ts = GetComponentsInChildren<Transform>();
        foreach (Transform t in ts)
        {
            if (t.transform.tag == "Cow" && t.GetComponent<OnImpact>().IsCaptured == false)
             {
                //Debug.Log("Cow parented");
                //rb.velocity = new Vector2(0f, 1f);
                connectedCow = true;
            }
        }
    }
    void CheckIfTimeToFire()
    {
        if (timer>= fireRate)
        {
            timer = 0f;
            GameObject bu = Instantiate(bullet, transform.position, Quaternion.identity);
            bu.transform.SetParent(bulletHolder.transform);
        }
        timer += Time.deltaTime;
    }
}
