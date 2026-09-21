using UnityEngine;

public class StartButton : MonoBehaviour, IInteractable
{
    public string GetInteractText()
    {
        if (GameManager.Instance.GameActive ||
            GameManager.Instance.CountdownActive)
        {
            return "";
        }

        return "[E] START AIM TRAINER";
    }

    public void Interact()
    {
        if (GameManager.Instance.GameActive ||
            GameManager.Instance.CountdownActive)
        {
            return;
        }

        GameManager.Instance.StartCountdown();
    }
}