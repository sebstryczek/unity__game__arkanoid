using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] Transform leaderboardRoot;
    [SerializeField] GameObject prefabLeaderboardItem;
    
    private void Start()
    {
        Dictionary<string, int> results = LeaderboardManager.Instance.Results;
        results = results.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        int index = 1;
        foreach (KeyValuePair<string, int> item in results)
        {
            GameObject go = Instantiate(this.prefabLeaderboardItem, this.leaderboardRoot);
            LeaderboardItem leaderboardItem = go.GetComponent<LeaderboardItem>();
            leaderboardItem.Init(index, item.Key, item.Value);
            index++;
        }
    }
}
