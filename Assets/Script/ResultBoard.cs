using TMPro;
using UnityEngine;

public class ResultBoard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hitsText;
    [SerializeField] private TMP_Text missesText;
    [SerializeField] private TMP_Text accuracyText;

    private void Start()
    {
        ClearBoard();
    }

    public void ClearBoard()
    {
        scoreText.text = "SCORE: --";
        hitsText.text = "HITS: --";
        missesText.text = "MISSES: --";
        accuracyText.text = "ACCURACY: --";
    }

    public void ShowResults(int score, int hits, int misses, float accuracy)
    {
        scoreText.text = "SCORE: " + score;
        hitsText.text = "HITS: " + hits;
        missesText.text = "MISSES: " + misses;
        accuracyText.text = "ACCURACY: " + accuracy.ToString("F1") + "%";
    }
}