using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    private static bool jeuEnPause = false;
    [SerializeField] private GameObject pauseMenu;
     private CharacterController player;
    [SerializeField] private GameObject optionPause;
    [SerializeField] private GameObject soundPage;
    [SerializeField] private GameObject inputPage;
    

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    private void Update()
    {
        PauseTime();
    }

    //Permet de mettre pause seulement en appuyant sur echap
    private void PauseTime()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jeuEnPause)
            {
                pauseMenu.SetActive(false);
               player.MoveAgain();
                jeuEnPause = false;
                optionPause.SetActive(false);
                soundPage.SetActive(false);
                inputPage.SetActive(false);
            }
            else
            {
               player.StopMove();
                pauseMenu.SetActive(true);
                jeuEnPause = true;
            }
        }
      
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
       optionPause.SetActive(true);
       soundPage.SetActive(false);
       inputPage.SetActive(false);
    }
    public void Sound()
    {
        pauseMenu.SetActive(false);
        inputPage.SetActive(false);
        optionPause.SetActive(false);
        soundPage.SetActive(true);
    }

    public void InputMenu()
    {
        pauseMenu.SetActive(false);
        inputPage.SetActive(true);
        optionPause.SetActive(false);
        soundPage.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetourPauseScreen()
    {
        pauseMenu.SetActive(true);
        optionPause.SetActive(false);
        soundPage.SetActive(false);
        inputPage.SetActive(false);
    }
}
