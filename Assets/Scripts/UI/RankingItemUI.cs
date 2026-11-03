using TMPro;
using UnityEngine;

public sealed class RankingItemUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text scoreText;

    public void SetData(int rank, string playerName, int score)
    {
        rankText.text = rank.ToString();
        playerNameText.text = playerName;
        scoreText.text = score.ToString();
    }
}