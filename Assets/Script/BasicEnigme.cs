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
  
   [SerializeField] protected TextMeshProUGUI enonce;
   [SerializeField] protected TextMeshProUGUI titreEnigme;
   [SerializeField] private string indiceText;
   [SerializeField] protected TextMeshProUGUI failedText;
   [SerializeField] protected TextMeshProUGUI notNowText;
   [Header("Distance necessaire pour activer l'enigme")]
   [SerializeField] protected float rangeActivateEnigme;
   private CharacterController player;
   [Header("Objet qui seront active une fois l enigme lancer")]
   [SerializeField] protected GameObject[] activatedInterface;
   [Header("Scoring")]
   [SerializeField] private TextMeshProUGUI scoringText;
   [SerializeField] protected TextMeshProUGUI winText;
   private string rank;

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
         if (Input.GetKeyDown(KeyCode.E))
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
         if (Input.GetKeyDown(KeyCode.E))
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
   protected virtual void LeaveEnigme()
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
      else
      {
         rank = "C";
         rankCoef = 4;
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
      
         if (Timer > secondeForARank )
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
