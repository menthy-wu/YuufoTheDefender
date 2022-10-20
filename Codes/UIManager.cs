using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    Animator anim;
    GameObject gameManager;


    public void OnPointerEnter()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 1);
    }
    public void OnPointerExit()
    {
        gameObject.GetComponent<Animator>().SetInteger("state", 2);
    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        anim = GetComponent<Animator>();
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    public void  gameStartButton()
    {
        Time.timeScale = 1;
        SoundManager.instance.playButtonClick();
        SoundManager.instance.pauseintro();
        SoundManager.instance.pauseAll();
        SoundManager.instance.playbattleTheme();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.gameTime;
    }
    public void gotoCutScene()
    {
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.cutScene;

    }
    public void creditButton()
    {
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.creditPage;
    }
    public void settingButton()
    {
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.settings;
    }
    public void returnButton()
    {
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.startPage;
    }
    public void tutorialPage()
    {
        Time.timeScale = 1;
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.tutorialPage;
    }
    public void pauseButton()
    {
        SoundManager.instance.playButtonClick();
        SoundManager.instance.playButtonClick();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.pause;
        Time.timeScale = 0;
    }
    public void menuButton()
    {
        Time.timeScale = 1;
        SoundManager.instance.playButtonClick();
        SoundManager.instance.pausebattleTheme();
        SoundManager.instance.playintro();
        gameManager.GetComponent<GameManager>().currentState = GameManager.state.startPage;
    }
    public void changeVolume()
    {
        SoundManager.instance.changeVolum(gameObject.GetComponent<Slider>().value);
    }
}
