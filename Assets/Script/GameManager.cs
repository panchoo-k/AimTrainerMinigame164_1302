using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    [SerializeField] private float gameTime = 60f;

    [Header("Aim Trainer")]
    [SerializeField] private GameObject targetHolder;
    [SerializeField] private GameObject trainingHUD;

    [Header("Result Board")]
    [SerializeField] private ResultBoard resultBoard;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text accuracyText;
    [SerializeField] private HitFeedback hitFeedback;
    [SerializeField] private TMP_Text countdownText;

    private float timeRemaining;

    private int score;
    private int hits;
    private int misses;
    private int totalShots;

    private bool gameActive;
    private bool countdownActive;

    public float TimeRemaining => timeRemaining;
    public int Score => score;
    public bool GameActive => gameActive;

    public bool CountdownActive => countdownActive;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameActive = false;

        targetHolder.SetActive(false);
        trainingHUD.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameActive)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateUI();
    }

    public void StartGame()
    {
        score = 0;
        hits = 0;
        misses = 0;
        totalShots = 0;

        timeRemaining = gameTime;
        gameActive = true;

        targetHolder.SetActive(true);
        trainingHUD.SetActive(true);

        UpdateUI();

        Debug.Log("GAME START!");
    }
    public void StartCountdown()
    {
        if (gameActive || countdownActive)
            return;

        StartCoroutine(CountdownRoutine());
    }
    private IEnumerator CountdownRoutine()
    {
        countdownActive = true;

        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);

        countdownActive = false;

        StartGame();
    }

    public void RegisterHit()
    {
        if (!gameActive)
            return;

        totalShots++;
        hits++;
        score++;

        hitFeedback.ShowHit();

        UpdateUI();
    }

    public void RegisterMiss()
    {
        if (!gameActive)
            return;

        totalShots++;
        misses++;

        hitFeedback.ShowMiss();

        UpdateUI();
    }

    private float GetAccuracy()
    {
        if (totalShots == 0)
            return 0;

        return (float)hits / totalShots * 100f;
    }

    private void UpdateUI()
    {
        scoreText.text = "SCORE: " + score;

        timerText.text =
            "TIME: " + Mathf.CeilToInt(timeRemaining);

        accuracyText.text =
            "ACCURACY: " + GetAccuracy().ToString("F1") + "%";
    }

    private void EndGame()
    {
        gameActive = false;

        targetHolder.SetActive(false);
        UpdateUI();
        trainingHUD.SetActive(false);

        resultBoard.ShowResults(
            score,
            hits,
            misses,
            GetAccuracy()
        );

        Debug.Log("GAME OVER!");
        Debug.Log("Final Score: " + score);
        Debug.Log("Hits: " + hits);
        Debug.Log("Misses: " + misses);
        Debug.Log("Accuracy: " + GetAccuracy().ToString("F1") + "%");
    }
}