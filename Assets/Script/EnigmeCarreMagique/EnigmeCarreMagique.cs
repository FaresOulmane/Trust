﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeCarreMagique : BasicEnigme
{
    [SerializeField] private PlaqueNumber[] plaqueNumber;
    [SerializeField] private Plaque[] plaque;

    [SerializeField] private EnigmeVenn enigmeVenn;
    [SerializeField] private Animator coffreAnim;
    AudioSource audioSource;
    
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        notNowTextStartPos = notNowText.gameObject.GetComponent<Transform>().position;
        notNowTextStartPos = notNowText.gameObject.transform.position;
    }
  // recupere le chiffre des plaque
    void Update()
    {
        StartEnigme();
        Confirm();
        if (EndEnigme)
        {
            outline.enabled = false;
            GetComponent<EnigmeCarreMagique>().enabled = false;
        }
       
    }
    // reset la position des plaques
    public void ResetPos()
    {
        for (int i = 0; i < plaque.Length; i++)
        {
            plaque[i].transform.position = plaque[i].StartedPos;
        }

      
    }
    // override de startEnigme afin d'afficher l interface de l enigme seulement si l enigme d avant est fini et si c est le cas le texte devient celui de l enigme actuel
    protected override void StartEnigme()
    {
        if (enigmeVenn.EndEnigme)
        {
           
            base.StartEnigme();
        }
        else
        {
            CantDoEnigme();
        }

    }
    //verifie si l addition des chiffee en vertical/horizontal/diagonale fait 15 partout si c est le cas c'est gagner
   public void Confirm()
   {
       if (plaqueNumber[0].Num + plaqueNumber[4].Num + plaqueNumber[8].Num == 15 &&
           plaqueNumber[0].Num + plaqueNumber[1].Num + plaqueNumber[2].Num == 15 &&
           plaqueNumber[3].Num + plaqueNumber[4].Num + plaqueNumber[5].Num == 15 &&
           plaqueNumber[6].Num + plaqueNumber[7].Num + plaqueNumber[8].Num == 15 &&
           plaqueNumber[0].Num + plaqueNumber[3].Num + plaqueNumber[6].Num == 15 &&
           plaqueNumber[1].Num + plaqueNumber[4].Num + plaqueNumber[7].Num == 15 &&
           plaqueNumber[2].Num + plaqueNumber[5].Num + plaqueNumber[8].Num == 15 &&
           plaqueNumber[6].Num + plaqueNumber[4].Num + plaqueNumber[2].Num == 15
       )
       {
         
          
           winText.gameObject.SetActive(true);
           audioSource.Play();
           StartCoroutine(nameof(LeaveEnigmeAfterWin));
           StartCoroutine(nameof(AnimCoffre));
       }
      
   }
   
   IEnumerator AnimCoffre()
   {
       yield return new WaitForSeconds(3.5f);
       coffreAnim.SetBool("open",true);
       
         
   }
   
}
