using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}