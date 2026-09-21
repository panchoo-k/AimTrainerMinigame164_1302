using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public void Shoot()
    {
        if (!GameManager.Instance.GameActive)
            return;

        Ray ray = cam.ViewportPointToRay(
            new Vector3(0.5f, 0.5f)
        );

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                GameManager.Instance.RegisterHit();

                target.Hit();

                return;
            }
        }

        GameManager.Instance.RegisterMiss();
    }
}