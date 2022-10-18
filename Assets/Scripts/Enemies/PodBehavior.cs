using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject swarmer;
    [SerializeField] int numOfSwarmer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);
        if (transform.position.y <= -4.52)
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
    }
    public void Burst()
    {
        for(int i = 0; i< numOfSwarmer; i++)
        {
            GameObject swm =Instantiate(swarmer, transform.position, Quaternion.identity);
            swm.transform.parent = GameObject.Find("Enemies").transform;
            swm.transform.Translate(new Vector3(0,i,0));
        }
    }
}
