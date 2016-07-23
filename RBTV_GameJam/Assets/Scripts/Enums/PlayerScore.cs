using UnityEngine;
using System.Collections;

public class PlayerScore
{
        public int score { get; set; }
    public int hits { get; set; }
    public int kills { get; set; }

    public PlayerScore(int s,int h, int k)
    {
        score = s;
        kills = k;
        hits = h;
    }
}
