using UnityEngine;
using UnityEngine.UI;

public sealed class RankingPanelController : UIPanel
{
    [Header("References")]
    [SerializeField] private Button closeButton;
    [SerializeField] private RankingItemUI rankingItemPrefab;
    [SerializeField] private Transform rankingList;

    private void OnEnable()
    {
        closeButton.onClick.AddListener(Hide);
        RefreshRanking();
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(Hide);
    }

    private void RefreshRanking()
    {
        ClearRankingList();

        CreateRankingItem(1, "玩家A", 1500);
        CreateRankingItem(2, "玩家B", 1200);
        CreateRankingItem(3, "玩家C", 900);
        CreateRankingItem(4, "玩家D", 600);
        CreateRankingItem(5, "玩家E", 300);
    }

    private void CreateRankingItem(
        int rank,
        string playerName,
        int score)
    {
        RankingItemUI item =
            Instantiate(rankingItemPrefab, rankingList);

        item.SetData(rank, playerName, score);
    }

    private void ClearRankingList()
    {
        for (int i = rankingList.childCount - 1; i >= 0; i--)
        {
            Destroy(rankingList.GetChild(i).gameObject);
        }
    }
}