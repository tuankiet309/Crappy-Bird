using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] public GameObject EndMenu;
    [SerializeField] private GameObject PauseMenu;
    public static UIManager Instance;
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
    public void SwicthStartMenu(bool state)
    {
       
            StartMenu.SetActive(state);
        
    }
    public void SwicthPauseMenu(bool state)
    {
         PauseMenu.SetActive(state);
       
    }
    public void SwicthEndMenu(bool state)
    {              
            EndMenu.SetActive(state);
    }

}
