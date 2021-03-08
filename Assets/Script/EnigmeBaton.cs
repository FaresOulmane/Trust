using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeBaton : BasicEnigme
{
    public float rangeActivateEnigme;

    public CharacterController player;
    private bool endEnigme;

    public bool EndEnigme
    {
        get => endEnigme;
        set => endEnigme = value;
    }

    public GameObject enigme;
    // Start is called before the first frame update
    void Start()
    {
        EndEnigme = false;
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        enonce.text = "Ouvrez le cadenas à l'aide du code que vous avez trouvez";
        titreEnigme.text = "Enigme 1 : Batons";
        
    }

     void Update()
    {
       StartEnigme();
    }

     void StartEnigme()
     {
         if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme) 
         {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 enigme.SetActive(true);
                 reponse.SetActive(false);
                 player.StopMove();
             }
            
         }
     }

     public void LeaveEnigme()
     {
         enigme.SetActive(false);
         player.MoveAgain();
     }
}
