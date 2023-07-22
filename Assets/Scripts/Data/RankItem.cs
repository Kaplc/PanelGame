using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankItem : MonoBehaviour
{
    public UILabel lbRankIndex;
    public UILabel lbName;
    public UILabel lbTime;

    public void InitInfo(int index, string name, int time)
    {
        lbRankIndex.text = index.ToString();
        lbName.text = name;
        lbTime.text = time + "s";
    }
}