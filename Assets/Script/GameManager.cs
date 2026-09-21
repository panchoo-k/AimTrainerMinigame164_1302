using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    [SerializeField] private float gameTime = 60f;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text accuracyText;
    [SerializeField] private HitFeedback hitFeedback;

    private float timeRemaining;

    private int score;
    private int hits;
    private int misses;
    private int totalShots;

    private bool gameActive;

    public float TimeRemaining => timeRemaining;
    public int Score => score;
    public bool GameActive => gameActive;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
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

        UpdateUI();

        Debug.Log("GAME START!");
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

        UpdateUI();

        Debug.Log("GAME OVER!");
        Debug.Log("Final Score: " + score);
        Debug.Log("Hits: " + hits);
        Debug.Log("Misses: " + misses);
        Debug.Log("Accuracy: " + GetAccuracy().ToString("F1") + "%");
    }
}