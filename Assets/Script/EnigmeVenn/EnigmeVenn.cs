using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmeVenn : BasicEnigme
 {
     [SerializeField] private Button[] symbole;
     [SerializeField] private EnigmeBaton enigmeBaton;
     private int[] correctCombination = {0, 1, 2};
     private int[]result = {0,0,0};
     
     void Update()
     {
       
         StartEnigme();
         if (EndEnigme)
         {
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
             failedText.gameObject.SetActive(false);
             StopCoroutine(nameof(LeaveEnigmeAfterWin));
             StartCoroutine(nameof(LeaveEnigmeAfterWin));
         }
         else
         {
             failedText.gameObject.SetActive(true);
         }
     }
// remet les symbole en interractable
     public void Reset()
     {
         foreach (var button in symbole)
         {
             button.interactable = true;
         }

         failedText.gameObject.SetActive(false);

         result[0] = 0;
         result[1] = 0;
         result[2] = 0;

     }
// override de startEnigme afin d'afficher l interface de l enigme seulement si l enigme d avant est fini et si c est le cas le texte devient celui de l enigme actuel
     protected override void StartEnigme()
     {
         if (enigmeBaton.EndEnigme)
         {
             enonce.text = "Appuyez sur les bons symbole";
             titreEnigme.text = "Enigme 2 : Diagramme de Venn";
            base.StartEnigme();
         }
         else
         {
            CantDoEnigme();
         }

     }
     protected override void LeaveEnigme()
     {
         base.LeaveEnigme();
         failedText.gameObject.SetActive(false);
     }
    
 }