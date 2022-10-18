using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Lander;
    [SerializeField] GameObject Bomber;
    [SerializeField] GameObject Pod;
    [SerializeField] GameObject Cow;
    [SerializeField] int LanderNum;
    [SerializeField] int BomberNum;
    [SerializeField] int PodNum;
    [SerializeField] int CowNum;
    [SerializeField] float MaxUp;
    [SerializeField] float MaxDown;
    [SerializeField] float MaxRight;
    [SerializeField] float MaxLeft;
    GameObject Enemies;
    GameObject Cows;
    // Start is called before the first frame update
    void Awake()
    {
        Enemies = GameObject.Find("Enemies");
        Cows = GameObject.Find("Cows");
        for (int i = 0; i < LanderNum; i++)
        {
            float x = Random.Range(MaxLeft, MaxRight);
            float y = Random.Range(MaxDown, MaxUp);
            GameObject ene = Instantiate(Lander);
            ene.transform.position = new Vector3(x, y, 0);
            ene.transform.parent = Enemies.transform;
        }
        for (int i = 0; i < BomberNum; i++)
        {
            float x = Random.Range(MaxLeft, MaxRight);
            float y = Random.Range(MaxDown, MaxUp);
            GameObject ene = Instantiate(Bomber);
            ene.transform.position = new Vector3(x, y, 0);
            ene.transform.parent = Enemies.transform;
        }
        for (int i = 0; i < PodNum; i++)
        {
            float x = Random.Range(MaxLeft, MaxRight);
            float y = Random.Range(MaxDown, MaxUp);
            GameObject ene = Instantiate(Pod);
            ene.transform.position = new Vector3(x, y, 0);
            ene.transform.parent = Enemies.transform;
        }
        for (int i = 0; i < CowNum; i++)
        {
            int flip = Random.Range(0, 2);
            float x = Random.Range(MaxLeft, MaxRight);
            GameObject cow = Instantiate(Cow);
            if (flip == 0)
            {
                cow.transform.localScale = new Vector3(-cow.transform.localScale.x, cow.transform.localScale.y, cow.transform.localScale.z);
            }
            cow.transform.position = new Vector3(x, -4.52f, 0);
            cow.transform.parent = Cows.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
