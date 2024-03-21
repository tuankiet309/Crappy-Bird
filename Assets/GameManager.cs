using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private State state;
    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }
   
    void Start()
    {
        DefaultGame(true);
    }
    public void DefaultGame(bool state)
    {
        UIManager.Instance.SwicthStartMenu(state);
        if (state == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void PlayGame(bool state)
    {
        UIManager.Instance.SwicthPauseMenu(state);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PauseGame(bool state)
    {
        UIManager.Instance.SwicthPauseMenu(state);
        if(state==true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void EndGame(bool state)
    {
        if (state == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIManager.Instance.EndMenu.SetActive(true);
    }
    public enum State
    {
        Default,
        Play,
        Pause,
        End,
    }
}
