using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeBaton : BasicEnigme
{
    private int[] result;

    private int[] correctCombination;
    [SerializeField] private Animator coffreAnim;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject cadenasCoffre;
    
   public void Start()
   {
       enonce.text = "Ouvrez le cadenas à l'aide du code que vous avez trouvez";
        titreEnigme.text = "Enigme 1 : Batons";
        result = new int[] {0, 0, 0, 0};
        correctCombination = new int[]{3,6,6,5};
        LockRotate.Rotated += CheckResults;
        
    }
// desactive le script une fois l enigme fini
     void Update()
     {
        
       StartEnigme();
       if (EndEnigme)
       {
           enigmeActivate = false;
           outline.enabled = false;
           GetComponent<EnigmeBaton>().enabled = false;
       }
    }
// permet de checker le chiffre sur les roulette du cadenas et si tout les chiffre ssont bons alors il s ouvre et lance la coroutine de reussite d enigme
     private void CheckResults(string codeName,int number)
     {
         switch (codeName)
         {
             case "code_1" :
                 result[0] = number;
                 break;
             case "code_2" :
                 result[1] = number;
                 break;
             case "code_3" :
                 result[2] = number;
                 break;
             case "code_4" :
                 result[3] = number;
                 break;
         }

         if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
             result[2] == correctCombination[2] && result[3] == correctCombination[3])
         {
             winText.gameObject.SetActive(true);
             animator.SetBool("unlock", true);
             StopCoroutine(nameof(LeaveEnigmeAfterWin));
             StartCoroutine(nameof(LeaveEnigmeAfterWin));
             StartCoroutine(AnimCoffre());
         }
     }

     IEnumerator AnimCoffre()
     {
         yield return new WaitForSeconds(3f);
         cadenasCoffre.SetActive(false);
         coffreAnim.SetBool("open",true);
         
     }

}
