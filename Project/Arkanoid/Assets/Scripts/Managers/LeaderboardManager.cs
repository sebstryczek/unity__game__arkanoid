using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : StorageManager<LeaderboardManager, Leaderboard>
{
    public Dictionary<string, int> Results { get { return this.storage.State.results; } }
    
    protected override void Awake()
    {
        this.fileName = "leaderboard.dat";
        base.Awake();

        if (!this.storage.IsFileExist)
        {
            this.storage.Create();
        }
        else
        {
            this.storage.LoadFromFile();
        }

        if (this.storage.State.results == null)
        {
            this.storage.State.results = new Dictionary<string, int>();
        }
    }

    public void AddItem(string name, int score)
    {
        if (this.storage.State.results.ContainsKey(name))
        {
            this.storage.State.results[name] = score;
        }
        else
        {
            this.storage.State.results.Add(name, score);
        }

        this.storage.SaveToFile();
    }
}
