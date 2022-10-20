using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnImpact : MonoBehaviour
{
    public bool fly = false;
     bool BeingRescued  = false;
    public bool IsCaptured = false;
    [SerializeField] float fallSpeed = 0.1f;
    float landHeight = -4.52f;
    GameObject Cows;
    GameObject Score;

    private void Start()
    {
        Cows = GameObject.Find("Cows");
        Score = GameObject.Find("Score");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("HI");
        if(other.tag == "Lander")
        {
            transform.parent = other.transform;
            IsCaptured = true;
        }
        if(other.tag  == "Player" && fly )
        {
            transform.parent= other.transform;
            BeingRescued = true;
            other.GetComponent<PlayerController>().rescuedCow = true;
            Score.GetComponent<Text>().text = (int.Parse(Score.GetComponent<Text>().text) + 500).ToString();
        }
    }
    private void Update()
    {
        if(BeingRescued)
        {
            if (transform.parent.transform.position.y <= landHeight+0.5)
            {
                transform.parent = Cows.transform;
                transform.position = new Vector3(transform.position.x, landHeight, transform.position.z);
                BeingRescued = false;
                fly = false;
                Score.GetComponent<Text>().text = (int.Parse(Score.GetComponent<Text>().text) + 500).ToString();
            }
        }
        if(!BeingRescued && fly &&! (transform.parent.name == "Player"))
        {
            transform.Translate(0, -fallSpeed, 0);
            if (transform.position.y <= landHeight)
            {
                Destroy(gameObject);
            }
        }
    }
}
