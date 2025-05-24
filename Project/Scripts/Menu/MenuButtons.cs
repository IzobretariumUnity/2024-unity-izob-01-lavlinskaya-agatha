using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void Play1()
    {
        SceneManager.LoadScene("Circle Move");
    }

    public void Play2()
    {
        SceneManager.LoadScene("Circle Move 2");
    }

    public void Play3()
    {
        SceneManager.LoadScene("Circle Move 3");
    }

    public void Play4()
    {
        SceneManager.LoadScene("CollicionDetech");
    }

    public void Quit()
    {
        Application.Quit();
    }
}


