using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPage : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    [SerializeField] GameObject four;
    int currentpage = 0;
    GameObject[] pages;
    private void Start()
    {
        pages = new GameObject[] { one, two, three, four };
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastPage();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nextPage();
        }
    }
    void nextPage()
    {
        if (currentpage == 3)
        {
            return;
        }
        else
        {
            pages[currentpage].SetActive(false);
            currentpage++;
            pages[currentpage].SetActive(true);
        }
    }
    void lastPage()
    {
        if (currentpage == 0)
        {
            return;
        }
        else
        {
            pages[currentpage].SetActive(false);
            currentpage--;
            pages[currentpage].SetActive(true);
        }
    }
}
