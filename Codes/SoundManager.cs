using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    float defaltSFX = 0.05f;
    [SerializeField] AudioSource shoot;
    [SerializeField] AudioSource enemyDie;
    [SerializeField] AudioSource enemyDie2;
    [SerializeField] AudioSource battleTheme;
    [SerializeField] AudioSource intro;
    [SerializeField] AudioSource playerDying;
    [SerializeField] AudioSource ButtonClick;
    [SerializeField] AudioSource DefeatSound;
    [SerializeField] AudioSource Victory;
    [SerializeField] AudioSource CutsceneTheme1_2;
    [SerializeField] AudioSource CutsceneTheme3;
    [SerializeField] AudioSource CutsceneTheme4;
    [SerializeField] AudioSource CutsceneTheme5_6;
    [SerializeField] AudioSource CutsceneTheme7;
    [SerializeField] AudioSource Yuufo;
    [SerializeField] AudioSource Lander;
    static SoundManager Instance;
    public static SoundManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<SoundManager>();
                if (Instance == null)
                {
                    GameObject soundM = new GameObject();
                    soundM.name = "soundManager";
                    Instance = soundM.AddComponent<SoundManager>();
                   // DontDestroyOnLoad(soundM);
                }
            }
            return Instance;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void playSound(AudioSource audio)
    {
        audio.Play();
    }
    public void pauseSound(AudioSource audio)
    {
        audio.Pause();
    }
    public void playShootSound()
    {
        playSound(shoot);
    }
    public void pauseShootSound()
    {
        pauseSound(shoot);
    }
    public void playenemyDie()
    {
        playSound(enemyDie);
    }
    public void pauseenemyDie2()
    {
        pauseSound(enemyDie2);
    }
    public void playenemyDie2()
    {
        playSound(enemyDie2);
    }
    public void pauseenemyDie()
    {
        pauseSound(enemyDie);
    }
    public void playbattleTheme()
    {
        playSound(battleTheme);
        //Debug.Log("playbattleTheme");
    }
    public void pausebattleTheme()
    {
        pauseSound(battleTheme);
    }
    public void playintro()
    {
        playSound(intro);
    }
    public void pauseintro()
    {
        pauseSound(intro);
    }
    public void playplayerDying()
    {
        playSound(playerDying);
    }
    public void pauseplayerDying()
    {
        pauseSound(playerDying);
    }
    public void playButtonClick()
    {
        playSound(ButtonClick);
    }
    public void playVictory()
    {
        playSound(Victory);
    }
    public void pauseVictory()
    {
        pauseSound(Victory);
    }
    public void playDefeatSound()
    {
        playSound(DefeatSound);
    }
    public void pauseDefeatSound()
    {
        pauseSound(DefeatSound);
    }
    public void changeVolum(float num)
    {
        shoot.volume = defaltSFX * num;
        enemyDie.volume = defaltSFX * num;
        enemyDie2.volume = defaltSFX * num;
        battleTheme.volume = defaltSFX * num; 
        intro.volume = defaltSFX * num; 
        playerDying.volume = defaltSFX * num; 
        ButtonClick.volume = defaltSFX * num;
        DefeatSound.volume = defaltSFX * num;
        Victory.volume = defaltSFX * num;
        CutsceneTheme1_2.volume = defaltSFX * num;
        CutsceneTheme3.volume = defaltSFX * num;
        CutsceneTheme4.volume = defaltSFX * num;
        CutsceneTheme5_6.volume = defaltSFX * num;
        CutsceneTheme7.volume = defaltSFX * num;
    }
    public void playCutsceneTheme1_2()
    {
            playSound(CutsceneTheme1_2);
    }
    public void pauseCutsceneTheme1_2()
    {
        pauseSound(CutsceneTheme1_2);
    }
    public void playCutsceneTheme3()
    {
        playSound(CutsceneTheme3);
    }
    public void pauseCutsceneTheme3()
    {
        pauseSound(CutsceneTheme3);
    }
    public void playCutsceneTheme4()
    {
        playSound(CutsceneTheme4);
    }
    public void pauseCutsceneTheme4()
    {
        pauseSound(CutsceneTheme4);
    }
    public void playCutsceneTheme5_6()
    {
        playSound(CutsceneTheme5_6);
    }
    public void pauseCutsceneTheme5_6()
    {
        pauseSound(CutsceneTheme5_6);
    }
    public void playCutsceneTheme7()
    {
        playSound(CutsceneTheme7);
    }
    public void pauseCutsceneTheme7()
    {
        pauseSound(CutsceneTheme7);
    }
    public void playYuufo()
    {
        playSound(Yuufo);
    }
    public void pauseYuufo()
    {
        pauseSound(Yuufo);
    }
    public void playLander()
    {
        playSound(Lander);
    }
    public void pauseLander()
    {
        pauseSound(Lander);
    }
    public void pauseAll()
    {
        pauseSound(intro);
        pauseSound(CutsceneTheme1_2);
        pauseSound(CutsceneTheme3);
        pauseSound(CutsceneTheme4);
        pauseSound(CutsceneTheme5_6);
        pauseSound(CutsceneTheme7);
    }
}
