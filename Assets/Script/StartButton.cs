using UnityEngine;

public class StartButton : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameManager.Instance.GameActive)
            return;

        GameManager.Instance.StartGame();

        Debug.Log("AIM TRAINER STARTED!");
    }
}