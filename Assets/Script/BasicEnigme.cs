using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.UI;

public class BasicEnigme : MonoBehaviour
{
   [Header("UI Enigme")]
   [SerializeField] protected GameObject panel;
   [SerializeField] protected GameObject quitBtn;
   [SerializeField] protected TextMeshProUGUI enonce;
   [SerializeField] protected TextMeshProUGUI titreEnigme;
   [SerializeField] protected GameObject reponse;
   [SerializeField] protected TextMeshProUGUI winText;
   [SerializeField] protected TextMeshProUGUI failedText;
   [SerializeField] protected TextMeshProUGUI notNowText;
   [Header("Distance necessaire pour activer l'enigme")]
   [SerializeField] protected float rangeActivateEnigme;
   private CharacterController player;
   [Header("Objet qui seront active une fois l enigme lancer")]
   [SerializeField] protected GameObject[] activatedInterface;

   private bool endEnigme;

   public bool EndEnigme
   {
      get => endEnigme;
      set => endEnigme = value;
   }

   private void Awake()
   {
      EndEnigme = false;
      player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
   }
   // Active tout les elements necessaire a l'enigme
   protected virtual void StartEnigme()
   {
      if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme) 
      {
         if (Input.GetKeyDown(KeyCode.A))
         {
            for (int i = 0; i < activatedInterface.Length; i++)
            {
               activatedInterface[i].SetActive(true);
            }
               
            player.StopMove();
         }
            
      }
   }
// met un message si l enigme d avant n ai pas fini
   protected void CantDoEnigme()
   {
      if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme)
      {
         if (Input.GetKeyDown(KeyCode.A))
         {
            player.StopMove();
            panel.SetActive(true);
            notNowText.gameObject.SetActive(true);
            StopCoroutine(nameof(StopMessage));
            StartCoroutine(nameof(StopMessage));
         }
      }
   }
// fait disparaitre le message et permet au joueur de se deplacer 
   IEnumerator StopMessage()
   {
      yield return new WaitForSeconds(3f);
      notNowText.gameObject.SetActive(false);
      player.MoveAgain();
      panel.SetActive(false);
   }
   // si une enigme est reussi cela fermera l'interface automatiquement
   protected IEnumerator LeaveEnigmeAfterWin()
   {
      yield return new WaitForSeconds(2f);
      for (int i = 0; i < activatedInterface.Length; i++)
      {
         activatedInterface[i].SetActive(false);
       
      }
      winText.gameObject.SetActive(false);
      player.MoveAgain();
      EndEnigme = true;
   }
// permet de fermer l interface si l on appuie sur le bouton quitte
   public void LeaveEnigme()
   {
      for (int i = 0; i < activatedInterface.Length; i++)
      {
         activatedInterface[i].SetActive(false);
       
      }
      
      player.MoveAgain();
   }
}
