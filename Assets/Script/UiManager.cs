//using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameObject Option;
    public GameObject Play;
    public GameObject Pause;
    public GameObject PauseSprite;
    public GameObject WelcomeMessage;
    AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();  
        Time.timeScale = 1.0f;
        StartCoroutine(StartMessage(WelcomeMessage));
    }

    // Update is called once per frame

    public void PauseFunction()
    {
        AudioSource.Play();
        Play.SetActive(true); 
        Option.SetActive(false);
        Time.timeScale = 0;
        PauseSprite.SetActive(true);
        Pause.SetActive(false);
    }
    public void PlayFunction()
    {
        AudioSource.Play();
        Pause.SetActive(true);
        Menu.SetActive(false );
        Time.timeScale = 1.0f;
        Option.SetActive(true);
        PauseSprite.SetActive(false);
        Play.SetActive(false);
    }
    public void MenuFunction()
    {
        AudioSource.Play();
        Menu.SetActive(true);
        Option.SetActive(false);
        Time.timeScale = 0;
        Play.SetActive(false);
        Pause.SetActive (false);
    }
    public void ExitFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(0);
    }
    public void RestarFunction()
    {
        AudioSource.Play();
        SceneManager.LoadScene(1);
    }

    IEnumerator StartMessage(GameObject GO)
    {
        GO.SetActive(true);
        yield return new WaitForSeconds(5f);
        GO.SetActive(false);
    }



}
