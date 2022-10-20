using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameUIManager : MonoBehaviour
{
    public  int life;                                                       //how many lives do you have
    [SerializeField] GameObject lifePrefab;                      //the image of life points
    [SerializeField] GameObject score;                              //score text
    [SerializeField] float healthWide;                                  //the interval between two health points pos
    [SerializeField] GameObject healthBar;                     //a empty parent game object for the health points
    GameObject[] lifeBar;                                                       //a list to keep all the health points
    public  int livesRemain;                                                                  // how many lives do the player have
    void Awake()
    {
        livesRemain = life;                                                                         //set the remaining life to the life num
        Vector3 healthBarPos = healthBar.transform.position;    // get the position to put the health bar
        lifeBar = new GameObject[life];                                               //initialize the health points list
        for(int i  = 0; i <lifeBar.Length; i++)                                         //create health points with health point prefab and put it into the list
        {
            lifeBar[i] = Instantiate(lifePrefab);                                        //create health point
            lifeBar[i].transform.SetParent(healthBar.transform);    //put it into the parent game object
            lifeBar[i].transform.position = healthBarPos + Vector3.right * healthWide*i; //set the position of the health point
        }
    }

    void Update()
    {
        
    }
    void addScore(int num)
    {
        score.GetComponent<Text>().text = (int.Parse(score.GetComponent<Text>().text) + num).ToString();
    }
    public bool hurt()                                          // if the player get hurt, delete one health point
    {
        if (livesRemain == 0)
            return false; // die
        livesRemain--;                                            //lost one life
        Destroy(lifeBar[livesRemain]);              //destory the health point
        if (livesRemain == 0)
            return false; // die
        return true; //alive
    }
}
