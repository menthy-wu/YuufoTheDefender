using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningVideo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
