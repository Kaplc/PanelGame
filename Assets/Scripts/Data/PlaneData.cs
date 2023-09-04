using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlaneData
{
    public List<PlaneInfo> planeInfos = new List<PlaneInfo>();
}

public class PlaneInfo
{
    [XmlAttribute] public int hp;
    [XmlAttribute] public int speed;
    [XmlAttribute] public int volume;
    [XmlAttribute] public string resPath; // 资源路径
    [XmlAttribute] public float scale; // 缩放
}