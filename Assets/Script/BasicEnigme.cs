﻿using System.Collections;
using UnityEngine;
using TMPro;

public class BasicEnigme : MonoBehaviour
{
   [Header("UI Enigme")]
  
  
   [SerializeField] protected TextMeshProUGUI enonce;
   [SerializeField] protected TextMeshProUGUI titreEnigme;
   [SerializeField] private string indiceText;
 
   [SerializeField] protected TextMeshProUGUI notNowText;
   protected Vector3 notNowTextStartPos;
   private bool cantEnigme;
   [Header("Distance necessaire pour activer l'enigme")]
   [SerializeField] protected float rangeActivateEnigme;
   private CharacterController player;
   [Header("Objet qui seront active une fois l enigme lancer")]
   [SerializeField] protected GameObject[] activatedInterface;
   [Header("Scoring")]
   [SerializeField] private TextMeshProUGUI scoringText;
   [SerializeField] protected TextMeshProUGUI winText;
   private string rank;
   [SerializeField] protected TextMeshProUGUI textForInteraction;

   public string Rank => rank;
   private int rankCoef;

   public int RankCoef => rankCoef;

   private float timer=0f;
    public float Timer => timer;
    
    private string timerString; 
    public string TimerString => timerString;

    private bool increaseTimer = true;
    [SerializeField] private float secondeForSRank;
    [SerializeField] private float secondeForARank;
    [SerializeField] private float secondeForBRank;
    
    
    private bool usedHelp;
    [SerializeField] protected TextMeshProUGUI helpText;
    protected bool enigmeActivate;
  

   private bool endEnigme;
   [SerializeField] protected Outline outline;

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
      enigmeActivate = true;
     TimerControl();
      
      if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme)
      {
         outline.GetComponent<Outline>().enabled = true;
         textForInteraction.text = "Press[E]";
         if (Input.GetKeyDown(KeyCode.E))
         {
            for (int i = 0; i < activatedInterface.Length; i++)
            {
               activatedInterface[i].SetActive(true);
            }
               
            player.StopMove();
         }
            
      }
      else
      {
         outline.GetComponent<Outline>().enabled = false;
         textForInteraction.text = "";
      }
   }
   
// met un message si l enigme d avant n ai pas fini
   protected void CantDoEnigme()
   {
      if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme)
      {
         outline.GetComponent<Outline>().enabled = true;
         if (Input.GetKeyDown(KeyCode.E))
         {
            cantEnigme = true;
            notNowText.gameObject.SetActive(true);
            StopCoroutine(nameof(StopMessage));
            StartCoroutine(nameof(StopMessage));
         }
      }
      else
      {
         outline.GetComponent<Outline>().enabled = false;
      }

      if (cantEnigme)
      {
         notNowText.gameObject.transform.Translate(Vector3.up*Time.deltaTime);
      }
   }
// fait disparaitre le message et permet au joueur de se deplacer 
   IEnumerator StopMessage()
   {
      yield return new WaitForSeconds(2f);
      cantEnigme = false;
      notNowText.gameObject.transform.position = notNowTextStartPos;
      notNowText.gameObject.SetActive(false);
     
   }
   // si une enigme est reussi cela fermera l'interface automatiquement
   protected IEnumerator LeaveEnigmeAfterWin()
   {
      CalculateRank();
      
         yield return new WaitForSeconds(3f);
      for (int i = 0; i < activatedInterface.Length; i++)
      {
         activatedInterface[i].SetActive(false);
       
      }
     
      winText.gameObject.SetActive(false);
      player.MoveAgain();
      EndEnigme = true;
     
   }
// permet de fermer l interface si l on appuie sur le bouton quitte
   public virtual void LeaveEnigme()
   {
      winText.gameObject.SetActive(false);
      scoringText.gameObject.SetActive(false);
      helpText.gameObject.SetActive(false);
    
      for (int i = 0; i < activatedInterface.Length; i++)
      {
         activatedInterface[i].SetActive(false);
       
      }
      
      player.MoveAgain();
   }

   void CalculateRank()
   {
      increaseTimer = false;
      helpText.gameObject.SetActive(false);
      scoringText.gameObject.SetActive(false);
      winText.gameObject.SetActive(true);

      if (!usedHelp)
      {
         if (timer < secondeForSRank)
         {
            rank = "S";
            rankCoef = 1;
         }
         if (timer < secondeForARank && timer>secondeForSRank)
         {
            rank = "A";
            rankCoef = 2;
         }
         if (timer < secondeForBRank && timer>secondeForARank)
         {
            rank = "B";
            rankCoef = 3;
         }
         if (timer >secondeForBRank )
         {
            rank = "C";
            rankCoef = 4;
         }
      }
      else if(usedHelp && timer < secondeForBRank )
      {
         rank = "B";
         rankCoef = 3;
      }
     
      winText.text = "Bravo,vous avez réussi l'enigme en " + timerString + " \nVoici votre note: " +
                     rank;
   }
   // Bouton indice pour aiguiller le joueur si il galere trop
   public void GetSomeHelp()
   {
      if (enigmeActivate)
      {
         helpText.gameObject.SetActive(true);
         StopCoroutine(nameof(IndiceDisable));
         StartCoroutine(nameof(IndiceDisable));
         
      
         if (timer > secondeForARank )
         {
            helpText.text = indiceText;
            usedHelp = true;
         }
         else
         {
            helpText.text = "Il est bien trop tot pour abandonner";
         }
      }
     
   }

   IEnumerator IndiceDisable()
   {
      yield return new WaitForSeconds(4f);
      helpText.gameObject.SetActive(false);
   }
// controle l affichage du timer format etc
   void TimerControl()
   {
      if(increaseTimer)
         timer += Time.deltaTime;
      int seconds = (int) (timer % 60);
      int minutes = (int) (timer / 60) % 60;
      int hour = (int) (timer / 3600) % 24;
      scoringText.gameObject.SetActive(true);
      timerString= string.Format("{0:00}:{1:00}:{2:00}",hour,minutes,seconds);
      scoringText.text = timerString;
   }
}
