using UnityEngine;
using UnityEngine.UI;

public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] private Text textIndex;
    [SerializeField] private Text textName;
    [SerializeField] private Text textScore;

    public void Init(int id, string name, int score)
    {
        this.textIndex.text = id.ToString();
        this.textName.text = name;
        this.textScore.text = score.ToString();
    }
}
