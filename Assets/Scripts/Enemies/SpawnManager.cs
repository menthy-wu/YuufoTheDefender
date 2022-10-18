using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject baiter;
    [SerializeField] float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn(baiter, delay));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawn(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        //Debug.Log("baiter cloned");
        var newBait = GameObject.Instantiate(go);
    }
}
