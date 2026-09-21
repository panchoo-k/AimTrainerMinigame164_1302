using System.Collections;
using TMPro;
using UnityEngine;

public class HitFeedback : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText;

    [SerializeField] private float showTime = 0.4f;
    [SerializeField] private float popSize = 1.4f;

    private Vector3 originalScale;
    private Coroutine feedbackCoroutine;

    private void Awake()
    {
        originalScale = feedbackText.transform.localScale;

        feedbackText.gameObject.SetActive(false);
    }

    public void ShowHit()
    {
        ShowFeedback("HIT!");
    }

    public void ShowMiss()
    {
        ShowFeedback("MISS!");
    }

    private void ShowFeedback(string message)
    {
        if (feedbackCoroutine != null)
        {
            StopCoroutine(feedbackCoroutine);
        }

        feedbackCoroutine = StartCoroutine(
            FeedbackAnimation(message)
        );
    }

    private IEnumerator FeedbackAnimation(string message)
    {
        feedbackText.gameObject.SetActive(true);

        feedbackText.text = message;

        Color color = feedbackText.color;
        color.a = 1f;
        feedbackText.color = color;

        feedbackText.transform.localScale =
            originalScale * popSize;

        float timer = 0f;

        while (timer < showTime)
        {
            timer += Time.deltaTime;

            float progress = timer / showTime;

            feedbackText.transform.localScale =
                Vector3.Lerp(
                    originalScale * popSize,
                    originalScale,
                    progress
                );

            color.a = 1f - progress;
            feedbackText.color = color;

            yield return null;
        }

        feedbackText.transform.localScale = originalScale;

        feedbackText.gameObject.SetActive(false);

        feedbackCoroutine = null;
    }
}