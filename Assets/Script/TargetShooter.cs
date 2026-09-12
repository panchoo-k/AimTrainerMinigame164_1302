using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                target.Hit();
            }
        }
    }
}