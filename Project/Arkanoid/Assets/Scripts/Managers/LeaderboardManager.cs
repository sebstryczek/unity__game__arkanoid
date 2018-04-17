using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManagement : MonoBehaviour
{
    private string fileName = "leaderboard.dat";
    private Storage<Leaderboard> storage;
    public Leaderboard State { get { return this.storage.State; } }
    public bool IsStateExist { get { return this.State != null; } }

    private void Awake()
    {
        this.storage = new Storage<Leaderboard>(fileName);
    }

    private void Start()
    {
        if (!this.storage.HasSave)
        {
            this.storage.Create();
        }
        else
        {
            this.storage.Load();
        }

        if (this.State.results == null)
        {
            this.State.results = new Dictionary<string, int>();
        }
    }

    private void AddItem(string name, int score)
    {
        if (this.State.results.ContainsKey(name))
        {
            this.State.results[name] = score;
        }
        else
        {
            this.State.results.Add(name, score);
        }

        this.storage.Save();
    }
}
