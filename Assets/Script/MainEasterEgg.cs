using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainEasterEgg : MonoBehaviour
{
    private bool interactable = false;
    private CharacterController player;
  
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI[] bonneLettre;
    [SerializeField] private GameObject[] pendaison;
    private int essai = 8;
    private bool canPress = true;
    [SerializeField] private GameObject[] fullPendaison;
    [SerializeField] private GameObject[] endOfEasterEgg;
    [SerializeField] private TextMeshProUGUI lettreEnonce;
    private List<string> lettre;
    private float timer = 3f;
    private float secondTimer = 10f;
    private bool endEvent = false;
    private int[] winLetter;
    private bool stopPressKey = false;
    public bool Interactable
    {
        set => interactable = value;
    }

    private void Awake()
    {
        lettre = new List<string>();
        winLetter = new int[10];
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

  // recupere les input presse et affiche ce qui doit l etre
    void Update()

    {
        string addLetter = "";
      
        foreach (var letter in lettre)
        {
            addLetter += letter+" | ";
          
        }

        lettreEnonce.text = "Lettres utilisées: " + addLetter;
        if (essai <=0 || winLetter[0] == 1 && winLetter[1] == 1 && winLetter[2] == 1 && winLetter[3] == 1 && winLetter[4] == 1
            && winLetter[5] == 1 && winLetter[6] == 1 && winLetter[7] == 1 && winLetter[8] == 1 && winLetter[9] == 1 && !endEvent)
        {
            stopPressKey = true;
            essai = 0;
            timer -= Time.deltaTime;
           
            if (timer <= 0)
            {
                lettre.Clear();
                for (int i = 0; i < fullPendaison.Length; i++)
                {
                    fullPendaison[i].SetActive(false);
                }
                for (int i = 0; i < endOfEasterEgg.Length; i++)
                {
                    endOfEasterEgg[i].SetActive(true);
                }

                timer =0;
                secondTimer -= Time.deltaTime;
                if (secondTimer <=0)
                {
                    for (int i = 0; i < endOfEasterEgg.Length; i++)
                    {
                        endOfEasterEgg[i].SetActive(false);
                    }

                    endEvent = true;
                    interactable = false;
                    player.MoveAgain();
                }
            }
                           
            
        }
        if(interactable &&!endEvent)
        {
            player.StopMove();
            if (canPress)
            {
                essai -= 1;
                canPress = false;
            }
            panel.SetActive(true);
           
            if (Input.inputString != "")
            {
                int asciCode = System.Convert.ToInt32(Input.inputString[0]);
                if (asciCode >= 65 && asciCode <= 122 && !stopPressKey)
                {
                    bool error = false;
                    foreach (var letter in lettre)
                    {
                        if (letter == Input.inputString)
                        {
                            error = true;
                            
                        }

                    }

                    if (!error)
                    {
                        lettre.Add(Input.inputString);
                    }
                    if (asciCode == 77 || asciCode == 109)
                    {
                        bonneLettre[0].text = "M";
                        bonneLettre[4].text = "M";
                        winLetter[0] = 1;

                    }

                    else if (asciCode == 65 || asciCode == 101)
                    {
                        bonneLettre[1].text = "E";
                        winLetter[1] = 1;

                    }

                    else if (asciCode == 78 || asciCode == 110)
                    {
                        bonneLettre[2].text = "N";
                        winLetter[2] = 1;

                    }

                    else if (asciCode == 85 || asciCode == 117)
                    {
                        bonneLettre[3].text = "U";
                        winLetter[3] = 1;

                    }

                    else if (asciCode == 67 || asciCode == 99)
                    {
                        bonneLettre[5].text = "C";
                        winLetter[4] = 1;

                    }

                    else if (asciCode == 70 || asciCode == 102)
                    {
                        bonneLettre[6].text = "F";
                        winLetter[5] = 1;

                    }

                    else if (asciCode == 73 || asciCode == 105)
                    {
                        bonneLettre[7].text = "I";
                        winLetter[6] = 1;

                    }

                    else if (asciCode == 82 || asciCode == 114)
                    {
                        bonneLettre[8].text = "R";
                        winLetter[7] = 1;

                    }

                    else  if (asciCode == 83 || asciCode == 115)
                    {
                        bonneLettre[9].text = "S";
                        winLetter[8] = 1;

                    }

                    else  if (asciCode == 84 || asciCode == 116)
                    {
                        bonneLettre[10].text = "T";
                        winLetter[9] = 1;

                    }
                    else if(!error)

                    // if (asciCode != 84 && asciCode != 116 && asciCode != 115 && asciCode != 114 &&
                    //     asciCode != 105 &&
                    //     asciCode != 102 && asciCode != 117 && asciCode != 110 && asciCode != 101 &&
                    //     asciCode != 83 && asciCode != 82 && asciCode != 73 && asciCode != 70 && asciCode != 85 &&
                    //     asciCode != 78 && asciCode != 65 && asciCode != 77  && asciCode != 67 && asciCode != 99  && asciCode != 109)
                    {
                       
                        canPress = true;
                        if (essai == 7)
                            pendaison[0].SetActive(true);

                        if (essai == 6)
                            pendaison[1].SetActive(true);

                        if (essai == 5)
                            pendaison[2].SetActive(true);
                    

                        if (essai == 4)
                            pendaison[3].SetActive(true);


                        if (essai == 3)
                            pendaison[4].SetActive(true);

                        if (essai == 2)
                            pendaison[5].SetActive(true);

                        if (essai == 1)
                            pendaison[6].SetActive(true);
                        
                       
                    }
                }
            }
            
        }
    }
    
}
        
        

    


        
    
   

