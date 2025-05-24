using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    [SerializeField] private AudioMixerSnapshot snapshotNormal;
    [SerializeField] private AudioMixerSnapshot snapshotPause;
   

    private Button buttonPause;

    private bool pauseState = false;

    private void Start()
    {
        GameObject buttonPauseObject = GameObject.FindGameObjectWithTag("ui_ButtonPause");
        buttonPause = buttonPauseObject.GetComponent<Button>();

        if (Application.isMobilePlatform == false)
        {
            buttonPauseObject.SetActive(false);
        }

        SetPause(false);

        buttonPause.onClick.AddListener(() =>
        {
            pauseState = !pauseState;
            SetPause(pauseState);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseState = !pauseState;
            SetPause(pauseState);
        }
    }

    public void SetPause(bool pause)
    {
        menu.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;

        if (pause)
        {
            snapshotPause.TransitionTo(.5f);
        }
        else
        {
            snapshotNormal.TransitionTo(.5f);
        }
    }

    public void Reload() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
