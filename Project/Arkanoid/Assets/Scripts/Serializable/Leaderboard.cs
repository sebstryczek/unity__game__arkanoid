using System;
using System.Collections.Generic;

[Serializable]
public class Leaderboard
{
    public Dictionary<string, int> results;
    
    private static Leaderboard _instance;
    public static Leaderboard Instance 
    { 
        get
        {
            return _instance ?? ( _instance = new Leaderboard());
        }
    }
}
