using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmeVenn : BasicEnigme
 {
     [SerializeField] private Button[] symbole;
     [SerializeField] private EnigmeBaton enigmeBaton;
     private int[] correctCombination = {1, 2, 3};
     private int[]result = {0,0,0};
     [SerializeField] private GameObject pageTwo;
     [SerializeField] private GameObject pageThree;
     [SerializeField] private GameObject pageFourth;
     [SerializeField] private GameObject mainPage;
     [SerializeField] private GameObject pageOne;

     private void Start()
     {
         notNowTextStartPos = notNowText.gameObject.GetComponent<Transform>().position;
         notNowTextStartPos = notNowText.gameObject.transform.position;
     }

     void Update()
     {
         Confirm();
         StartEnigme();
         
         if (EndEnigme)
         {
             outline.enabled = false;
             GetComponent<EnigmeVenn>().enabled = false;
         }
         
     }
     // permet de stocker un chiffre dans les symbole afin de le compare avec le resultat
     public void isSelected(int index)
     {
         result[0] = result[1];
         result[1] = result[2];
         result[2] = index;
        
        
         symbole[index].interactable = false;
       

     }
// permet de confirmer la suite de symbole realiser affiche un texte selon win/lose
     public void Confirm()
     {
         if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
             result[2] == correctCombination[2])
         {
             winText.gameObject.SetActive(true);
           
             StartCoroutine(nameof(LeaveEnigmeAfterWin));
         }
     }
// remet les symbole en interractable
     public void Reset()
     {
         foreach (var button in symbole)
         {
             button.interactable = true;
         }

        

         result[0] = 0;
         result[1] = 0;
         result[2] = 0;

     }
// override de startEnigme afin d'afficher l interface de l enigme seulement si l enigme d avant est fini et si c est le cas le texte devient celui de l enigme actuel
     protected override void StartEnigme()
     {
         if (enigmeBaton.EndEnigme)
         {
           
            base.StartEnigme();
         }
         else
         {
            CantDoEnigme();
         }

     }

     public void GoSecondPage()
     {
         mainPage.SetActive(false);
         pageTwo.SetActive(true);
         pageThree.SetActive(false);
         pageFourth.SetActive(false);
         pageOne.SetActive(false);
     }
     public void GoThirdPage()
     {
         mainPage.SetActive(false);
         pageThree.SetActive(true);
         pageTwo.SetActive(false);
         pageFourth.SetActive(false);
         pageOne.SetActive(false);
     }

     public void GoPageFourth()
     {
         mainPage.SetActive(false);
         pageThree.SetActive(false);
         pageTwo.SetActive(false);
         pageFourth.SetActive(true);
         pageOne.SetActive(false);
     }
     public void GoMainPage()
     {
         mainPage.SetActive(true);
         pageThree.SetActive(false);
         pageTwo.SetActive(false);
         pageFourth.SetActive(false);
         pageOne.SetActive(false);
     }
     public void GoPageOne()
     {
         mainPage.SetActive(false);
         pageThree.SetActive(false);
         pageTwo.SetActive(false);
         pageFourth.SetActive(false);
         pageOne.SetActive(true);
     }
    
 }