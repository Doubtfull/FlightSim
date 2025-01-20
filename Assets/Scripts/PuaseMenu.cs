using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Import the Input System namespace

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    public PlayerInput playerInput; // Reference to PlayerInput
    private InputAction pauseAction; // Action for pausing the game


    void OnEnable()
    {
        // Enable the pause action
        pauseAction.Enable();
    }

    void OnDisable()
    {
        // Disable the pause action
        pauseAction.Disable();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OnPausePerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
