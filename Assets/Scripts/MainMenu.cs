using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("Master", volume);
    }

    public void Quit()
    {
        Debug.Log("I Quit.");
        Application.Quit();
    }
}
