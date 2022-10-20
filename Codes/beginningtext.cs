using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginningtext : MonoBehaviour
{
    [SerializeField] GameObject text;
    IEnumerator show()
    {
        yield return new WaitForSeconds(5f);
        text.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(show());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
