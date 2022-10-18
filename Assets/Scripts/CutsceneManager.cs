using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    [SerializeField] GameObject four;
    [SerializeField] GameObject five;
    [SerializeField] GameObject six;
    [SerializeField] GameObject seven;
    [SerializeField] GameObject eight;
    [SerializeField] GameObject nine;
    [SerializeField] GameObject ten;
    [SerializeField] GameObject eleven;
    bool play = false;
    int currentpage = 0;
    GameObject[] pages;
    private void Start()
    {
        pages =new GameObject[] { one, two, three, four, five, six, seven, eight,nine,ten, eleven };
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            play = false;
            nextPage();
        }
        if ((currentpage == 0 || currentpage == 1) && !play)
        {
            play = true;
            SoundManager.instance.pauseAll();
            SoundManager.instance.playCutsceneTheme1_2();
        }
        else if ((currentpage == 2) && !play)
        {
            play = true;
            SoundManager.instance.pauseAll();
            SoundManager.instance.playCutsceneTheme3();
        }
        else if ((currentpage == 3) && !play)
        {
            play = true;
            SoundManager.instance.pauseAll();
            SoundManager.instance.playCutsceneTheme4();
        }
        else if ((currentpage == 4 || currentpage == 5) && !play)
        {
            play = true;
            SoundManager.instance.pauseAll();
            SoundManager.instance.playCutsceneTheme5_6();
        }
        else if ((currentpage == 6) && !play)
        {
            play = true;
            SoundManager.instance.pauseAll();
            SoundManager.instance.playCutsceneTheme7();
        }
        else if(currentpage == 6)
        {
            SoundManager.instance.playYuufo();
        }
        else if (currentpage == 7)
        {
            SoundManager.instance.playLander();
        }
        else if (currentpage == 8)
        {
            SoundManager.instance.playYuufo();
        }
    }
    void nextPage()
    {
        if (currentpage == 10)
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
}
