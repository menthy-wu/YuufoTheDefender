using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;                              //rigidBody Component
    bool towardsRight = true;           //If the plane is facing right
    bool speedUp = false;                  // if the plane is speed up
    [SerializeField] Animator anim;
    [SerializeField] float vSpeed;      //Vertical moving Speed
    [SerializeField] float hSpeed;     //Horizontal moving speed
    [SerializeField] float accOffset; // the offset when the plane is speed up
    [SerializeField] float MaxHeight;
    [SerializeField] float MinHeight;
    [SerializeField] float towardsRightPosition; //When the plane is facing right, it is at the left of the screen
    [SerializeField] float towardsLeftPosition;   //When the plane is facing left, it is at the right of the screen
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject backGround;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject sprite;
    [SerializeField] GameObject black;
    [SerializeField] GameObject bubble;
     GameObject Enemies;
    public bool rescuedCow = false;

    IEnumerator UnableBubble()
    {
        yield return new WaitForSeconds(3f);
        bubble.SetActive(false);
        GetComponent<CircleCollider2D>().enabled = true;
    }
    void Awake()
    {
        StartCoroutine(UnableBubble());
        Enemies = GameObject.Find("Enemies");
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (black.activeSelf == true && black.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            StartCoroutine(UnableBubble());
            anim.SetInteger("state", 0);
            black.SetActive(false);
            Time.timeScale = 1;
            transform.position = new Vector3(-4, 0, 0);
            backGround.transform.position = new Vector3(0, 0, 0);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && anim.GetCurrentAnimatorStateInfo(0).IsName("YuufoShoot"))
        {
            anim.SetInteger("state", 0);
        }
        if (Time.timeScale == 0)
            return;
        float v = 0;   // vertical verlocity
        float h = 0;  //horizontal verlocity

        //button
        if (Input.GetKey(KeyCode.W)) // up
        {
            if (transform.position.y <= MaxHeight)
                v = vSpeed;
        }
        else if (Input.GetKey(KeyCode.S))//down
        {
            if (transform.position.y >= MinHeight)
                v = -vSpeed;
        }
        else if (Input.GetKey(KeyCode.D)) //right press
        {
            if (!speedUp)
            {
                speedUp = true;
                transform.position = new Vector3(transform.position.x + accOffset, transform.position.y, transform.position.z);//speed up  offset
            }
            if (!towardsRight)    //If change from facing left ot facing right
                sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, sprite.transform.localScale.y, sprite.transform.localScale.z); // Flip
            towardsRight = true;
        }
        else if (Input.GetKey(KeyCode.A))//left press
        {
            if (!speedUp)
            {
                speedUp = true;
                transform.position = new Vector3(transform.position.x - accOffset, transform.position.y, transform.position.z);//speed up  offset
            }
            if (towardsRight)    //If change from facing right ot facing left
                sprite.transform.localScale = new Vector3(-sprite.transform.localScale.x, sprite.transform.localScale.y, sprite.transform.localScale.z); // Flip
            towardsRight = false;
        }
        else if (Input.GetKeyUp(KeyCode.D)) //right release
        {
            transform.position = new Vector3(transform.position.x - accOffset, transform.position.y, transform.position.z);
            speedUp = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))//left release
        {
            transform.position = new Vector3(transform.position.x + accOffset, transform.position.y, transform.position.z);
            speedUp = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("state", 1);
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<bulletController>().towardsRight = this.towardsRight;
        }

        //Horizontal Move
        if (towardsRight && transform.position.x > towardsRightPosition)   // if the plane is not at the right position
        {
            h = -hSpeed;
        }
        else if (!towardsRight && transform.position.x < towardsLeftPosition) // if the plane is not at the right position{
        {
            h = hSpeed;
        }
        transform.Translate(new Vector3(h, v, 0));
        backGround.transform.Translate(new Vector3(h, 0, 0));
        if(Enemies.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
            SoundManager.instance.playVictory();
            SoundManager.instance.pausebattleTheme();
            gameManager.GetComponent<GameManager>().currentState = GameManager.state.Victory;
        }
    }



    //Hit Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mutant" || collision.tag == "Mines" || collision.tag == "Enemy" || collision.tag == "Lander" || collision.tag == "Pod" || collision.tag == "Baiter" || collision.tag == "swarmer" || collision.tag == "Bomber")
        {
            die();
        }
    }
    void die()
    {
        SoundManager.instance.playplayerDying();
        black.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = 0;
        black.SetActive(true);
        bubble.SetActive(true);
        GetComponent<CircleCollider2D>().enabled = false;
        if (!UI.GetComponent<inGameUIManager>().hurt())
        {
            SoundManager.instance.pausebattleTheme();
            SoundManager.instance.playDefeatSound();
            gameManager.GetComponent<GameManager>().currentState = GameManager.state.gameOver;
            Time.timeScale = 1;
        }
    }
}
