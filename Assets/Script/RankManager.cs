using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    [SerializeField] private EnigmeBaton eb;
    [SerializeField] private EnigmeCryptex ec;
    [SerializeField] private EnigmeCarreMagique ecm;
    [SerializeField] private EnigmeVenn ev;
    private CharacterController player;
    [SerializeField] private TextMeshProUGUI finalRank;
    private float finalTimer;
    private string finalTimerString;
    private string finalstringRank;
    [SerializeField] private TextMeshProUGUI finalTimerForPause;
    private void Awake()
    {
       finalRank.gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }
    void Update()
    {
        StartCoroutine(RegroupResult());
        finalTimer = eb.Timer + ec.Timer + ecm.Timer + ev.Timer;
    }
    // controle l affichage du timer format etc
    void TimerControl()
    {
       
        int seconds = (int) (finalTimer % 60);
        int minutes = (int) (finalTimer / 60) % 60;
        int hour = (int) (finalTimer / 3600) % 24;
      
        finalTimerString = string.Format("{0:00}:{1:00}:{2:00}",hour,minutes,seconds);
        finalTimerForPause.text = finalTimerString;
    }
    // Recupere les note et temps contenu dans les autres scripts et affiche les resultat
   IEnumerator RegroupResult()
    {
        TimerControl();
       
        if (eb.EndEnigme && ec.EndEnigme && ecm.EndEnigme && ev.EndEnigme)
        {
            yield return new WaitForSeconds(2f);
            player.StopMove();
            finalRank.gameObject.SetActive(true);
           
            float finalRankWithCoef =
                ((eb.Timer * eb.RankCoef)+ (ev.Timer * ev.RankCoef)+ (ec.Timer * ec.RankCoef) + (ecm.Timer * ecm.RankCoef)) /
                (eb.RankCoef + ev.RankCoef + ec.RankCoef + ecm.RankCoef);

            if (finalRankWithCoef <= 15*60)
            {
                finalstringRank = "S";
            }
            if (finalRankWithCoef> 15*60 && finalRankWithCoef <=20 *60)
            {
                finalstringRank = "A";
            }
            if (finalRankWithCoef > 20*60 && finalRankWithCoef <=25*60)
            {
                finalstringRank = "B";
            }
            if (finalRankWithCoef > 25*60)
            {
                finalstringRank = "C";
            }
            finalRank.text = "Félicitation pour avoir fini le jeu !!\n\n Voici vos résultat: \n\nEnigme 1: Batons," +
                             eb.TimerString + "," + eb.Rank + " \n\nEnigme 2: Diagramme de Venn," + ev.TimerString + "," + ev.Rank +
                             " \n\nEnigme 3: Carre Magique," + ecm.TimerString + "," + ecm.Rank+ " \n\nEnigme 4: Cryptex," +
                             ec.TimerString + "," + ec.Rank + " \n\nVotre Temps Final: " + finalTimerString+" \n\nVotre note final: "+finalstringRank;
        }
    }
}
