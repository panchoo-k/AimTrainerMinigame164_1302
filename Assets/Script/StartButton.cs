using UnityEngine;

public class StartButton : MonoBehaviour, IInteractable
{
    public string GetInteractText()
    {
        return "[E] START AIM TRAINER";
    }

    public void Interact()
    {
        if (GameManager.Instance.GameActive)
            return;

        GameManager.Instance.StartGame();
    }
}