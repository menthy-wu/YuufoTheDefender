using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletController : MonoBehaviour
{
    [SerializeField] float speed;                      //the speed of the bullet
    //[SerializeField] float remainTime;           //the time for the bullet to alive
    public bool towardsRight = true;          //if the bullet is moving towards right or left
    Rigidbody2D rb;
    GameObject score;
    GameObject Cows;
    [SerializeField] GameObject CowPrefab;
    void Start()
    {
        SoundManager.instance.playShootSound();
        score = GameObject.Find("Score");
        Cows = GameObject.Find("Cows");
        //Destroy(gameObject, remainTime);              // destroy the bullet after a spicific time
        rb = this.GetComponent<Rigidbody2D>();
        if (towardsRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);   //if the bullet is towards right, set the speed to positive
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);//if the bullet is towards left, set the speed to negetive
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bomber")
        {
            SoundManager.instance.playenemyDie();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 150).ToString();
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Lander")
        {
            SoundManager.instance.playenemyDie2();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 250).ToString();
            if (other.transform.parent.gameObject.GetComponent<LanderBehavior>().connectedCow)
            {
                GameObject newCow = Instantiate(CowPrefab);
                newCow.GetComponent<OnImpact>().fly = true;
                newCow.transform.position = other.transform.position;
                newCow.transform.parent = Cows.transform;
            }
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
            }
            else if (other.tag == "Mutant")
        {
            SoundManager.instance.playenemyDie();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 150).ToString();
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
        }
        else if (other.tag == "Enemy")
        {
            SoundManager.instance.playenemyDie2();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 150).ToString();
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Baiter")
        {
            SoundManager.instance.playenemyDie();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 150).ToString();
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
            }
            else if (other.tag == "Pod")
        {
            SoundManager.instance.playenemyDie2();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 1000).ToString();
                other.transform.parent.gameObject.GetComponent<PodBehavior>().Burst();
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
            }
            else if (other.tag == "swarmer")
        {
            SoundManager.instance.playenemyDie();
            score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + 150).ToString();
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
