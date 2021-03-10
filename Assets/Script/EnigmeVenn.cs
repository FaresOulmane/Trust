using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmeVenn : MonoBehaviour
 {
     
 
   
     public Text failed;
     [SerializeField] private Button[] symbole;
   
     private int[] correctCombination = {1, 2, 3};
     private int[]result = {0,0,0};
    
     public void isSelected(int index)
     {
         result[0] = result[1];
         result[1] = result[2];
         result[2] = index;
         Debug.Log(index);
        
         symbole[index].interactable = false;
       

     }

     public void Confirm()
     {
         if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
             result[2] == correctCombination[2])
         {
             Debug.Log("gg");
         }
         else
         {
             failed.text = " rate";
         }
     }

     public void Reset()
     {
         foreach (var button in symbole)
         {
             button.interactable = true;
         }

         failed.text = "";

         result[0] = 0;
         result[1] = 0;
         result[2] = 0;

     }
     
   
 }