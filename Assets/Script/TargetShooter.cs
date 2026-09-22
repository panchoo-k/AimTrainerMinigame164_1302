using System.Collections;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("Bullet Tracer")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private LineRenderer bulletTracer;
    [SerializeField] private float tracerTime = 0.05f;
    [SerializeField] private float shootDistance = 100f;

    private Coroutine tracerCoroutine;

    public void Shoot()
    {
        if (!GameManager.Instance.GameActive)
            return;

        Ray ray = cam.ViewportPointToRay(
            new Vector3(0.5f, 0.5f)
        );

        // If we don't hit anything, tracer travels forward 100 units.
        Vector3 tracerEnd =
            ray.origin + ray.direction * shootDistance;

        if (Physics.Raycast(ray, out RaycastHit hit, shootDistance))
        {
            tracerEnd = hit.point;

            ShowTracer(tracerEnd);

            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                GameManager.Instance.RegisterHit();

                target.Hit();

                return;
            }
        }
        else
        {
            ShowTracer(tracerEnd);
        }

        GameManager.Instance.RegisterMiss();
    }

    private void ShowTracer(Vector3 endPoint)
    {
        if (tracerCoroutine != null)
            StopCoroutine(tracerCoroutine);

        tracerCoroutine =
            StartCoroutine(TracerRoutine(endPoint));
    }

    private IEnumerator TracerRoutine(Vector3 endPoint)
    {
        bulletTracer.enabled = true;

        bulletTracer.SetPosition(0, muzzlePoint.position);
        bulletTracer.SetPosition(1, endPoint);

        yield return new WaitForSeconds(tracerTime);

        bulletTracer.enabled = false;

        tracerCoroutine = null;
    }
}