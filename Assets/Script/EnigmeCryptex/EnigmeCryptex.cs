using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeCryptex : BasicEnigme
{  
    private int[] result;
    [SerializeField] private Animator animator;
    private int[] correctCombination;

    [SerializeField] private EnigmeCarreMagique carreMagique;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        result = new int[] {0, 0, 0, 0,0,0,0};
        correctCombination = new int[]{12,0,2,7,8,13,4};
        notNowTextStartPos = notNowText.gameObject.GetComponent<Transform>().position;
        notNowTextStartPos = notNowText.gameObject.transform.position;
       
    }
// s abonne a l event
    private void Update()
    {
        CryptexRotate.RotatedCryptex += CheckResults;
        StartEnigme();
        if (EndEnigme)
        {
            outline.enabled = false;
            GetComponent<EnigmeCryptex>().enabled = false;
        }
    }
    // override de startEnigme afin d'afficher l interface de l enigme seulement si l enigme d avant est fini et si c est le cas le texte devient celui de l enigme actuel
    protected override void StartEnigme()
    {
        if (carreMagique.EndEnigme)
        {
           
            base.StartEnigme();
        }
        else
        {
            CantDoEnigme();
        }

    }
// permet de checker la lettre sur le cryptex et si tout les chiffres associe au lettre sont bons alors il s ouvre et lance la coroutine de reussite d enigme
    private void CheckResults(string codeName,int number)
    {
        switch (codeName)
        {
            case "alphabet1" :
                result[0] = number;
                break;
            case "alphabet2" :
                result[1] = number;
                break;
            case "alphabet3" :
                result[2] = number;
                break;
            case "alphabet4" :
                result[3] = number;
                break;
            case "alphabet5" :
                result[4] = number;
                break;
            case "alphabet6" :
                result[5] = number;
                break;
            case "alphabet7" :
                result[6] = number;
                break;
        }
        if (result[0] == correctCombination[0] && 
            result[1] == correctCombination[1] &&
            result[2] == correctCombination[2] && 
            result[3] == correctCombination[3] && 
            result[4] == correctCombination[4] && 
            result[5] == correctCombination[5] &&
            result[6] == correctCombination[6])
           
        {
            winText.gameObject.SetActive(true);
            animator.SetBool("unlock", true);
            _audioSource.Play();
            StopCoroutine(nameof(LeaveEnigmeAfterWin));
            StartCoroutine(nameof(LeaveEnigmeAfterWin));
            
           
        }

       
    }
}
