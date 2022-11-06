using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject HUD;
    //public GameObject Player;

    //private void Start()
    //{
    //    HUD.SetActive(false);
    //    Time.timeScale = 0;
    //    Player.SetActive(false);
    //}

    public void OnPlayButton()
    {
        //HUD.SetActive(true);
        //Player.SetActive(true);
        SceneManager.LoadScene(1);
    }
}