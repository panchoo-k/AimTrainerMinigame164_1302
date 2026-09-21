using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private TMP_Text interactText;

    private IInteractable currentInteractable;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Ray ray = cam.ViewportPointToRay(
            new Vector3(0.5f, 0.5f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable =
                hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;

                interactText.text =
                    interactable.GetInteractText();

                interactText.gameObject.SetActive(true);

                return;
            }
        }

        currentInteractable = null;
        interactText.gameObject.SetActive(false);
    }

    public void Interact()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}