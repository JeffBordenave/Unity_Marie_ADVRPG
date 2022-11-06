using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject pauseScreen;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(!pauseScreen.activeSelf);
            if (pauseScreen.activeSelf) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}
