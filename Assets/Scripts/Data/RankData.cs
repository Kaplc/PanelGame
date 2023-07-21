using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankData
{
    public List<RankInfo> rankInfos = new List<RankInfo>();
}

public class RankInfo
{
    public string name;
    public int time;

    public RankInfo(string name, int time)
    {
        this.name = name;
        this.time = time;
    }
    
}
