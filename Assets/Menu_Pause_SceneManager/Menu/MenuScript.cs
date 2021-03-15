using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
   [SerializeField] private GameObject mainPage;
   [SerializeField] private GameObject soundPage;
   [SerializeField] private GameObject inputPage;
   [SerializeField] private GameObject settingPage;

   public void MainMenu()
   {
      inputPage.SetActive(false);
      mainPage.SetActive(true);
      settingPage.SetActive(false);
      soundPage.SetActive(false);
   }
   public void Options()
   {
      inputPage.SetActive(false);
      mainPage.SetActive(false);
      settingPage.SetActive(true);
      soundPage.SetActive(false);
   }

   public void Sound()
   {
      inputPage.SetActive(false);
      mainPage.SetActive(false);
      settingPage.SetActive(false);
      soundPage.SetActive(true);
   }

   public void InputMenu()
   {
      inputPage.SetActive(true);
      mainPage.SetActive(false);
      settingPage.SetActive(false);
      soundPage.SetActive(false);
   }

   public void QuitGame()
   {
     Application.Quit();
   }
}
