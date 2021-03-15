using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    
    //scene qui lance le jeu
    public void ChangerScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameScene);

    }

    public string menuScene;

    //RetourMenu
    public void BackScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuScene);

    }
}
