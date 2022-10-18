using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startPage;
    [SerializeField] GameObject creditPage;
    [SerializeField] GameObject tutorialPage;
    [SerializeField] GameObject gameRunTime;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject VictoryPage;
    [SerializeField] GameObject GameOverPage;
    [SerializeField] GameObject SettingsPage;
    [SerializeField] GameObject Buffer;
    [SerializeField] GameObject CutScene;
    GameObject currentPage;
    float  timer;
    float staytime = 2f;
    //[SerializeField] GameObject tutorialPage;

    public enum state
    {
        startPage,
        creditPage,
        tutorialPage,
        gameTime,
        pause,
        gameOver,
        Victory,
        settings,
        cutScene
    }
   public state  currentState;
    void Start()
    {
        currentState = state.startPage;
        currentPage = startPage;
    }

    void Update()
    {
        if(currentState == state.startPage)
        {
            changePage(startPage);
        }
        else if(currentState == state.cutScene)
        {
            changePage(CutScene);
        }
        else if (currentState == state.settings)
        {
            changePage(SettingsPage);
        }
        else if(currentState == state.creditPage)
        {
            changePage(creditPage);
        }
        else if (currentState == state.gameTime)
        {
            if(pauseUI.activeSelf)
                pauseUI.SetActive(false);
            changePage(gameRunTime);
        }
        else if (currentState == state.tutorialPage)
        {
            changePage(tutorialPage);
        }
        else if (currentState == state.pause)
        {
            pauseUI.SetActive(true);
        }
        else if(currentState == state.Victory)
        {
            changePage(VictoryPage);
            timer += Time.deltaTime;
            if (timer >= staytime)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene("Game");
                    //currentState = state.startPage;
                    //SoundManager.instance.pauseVictory();
                    //SoundManager.instance.playintro();
                }
            }
        }
        else if (currentState == state.gameOver)
        {
            changePage(GameOverPage);
            timer += Time.deltaTime;
            if ( timer >= staytime)
            {
                if (Input.anyKeyDown)
                {
                    //Debug.Log(Time.deltaTime - timer);
                    SceneManager.LoadScene("Game");
                    //currentState = state.startPage;
                    //SoundManager.instance.pauseDefeatSound();
                    //SoundManager.instance.playintro();
                }
            }
        }
    }
    void changePage(GameObject page)
    {
        if(currentPage == page)
        {
            return;
        }
        if(currentPage == pauseUI)
        {
            currentPage.SetActive(false);
            page.SetActive(true);
            currentPage = page;
            return;
        }
        if (!Buffer.activeSelf)
            Buffer.SetActive(true);
        if (Buffer.activeSelf && Buffer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("showScene") && Buffer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            timer = 0;
            currentPage.SetActive(false);
            page.SetActive(true);
            Buffer.GetComponent<Animator>().SetBool("hide",true);
        }
        if (Buffer.activeSelf && Buffer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("hideScene") && Buffer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Buffer.GetComponent<Animator>().SetBool("hide", false);
            Buffer.SetActive(false);
            currentPage = page;
        }
    }
}
