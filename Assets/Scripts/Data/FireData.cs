using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class FireData
{
    public List<FireInfo> fireInfos = new List<FireInfo>();
}

public class FireInfo
{
    [XmlAttribute] public int id;
    [XmlAttribute] public int type;
    [XmlAttribute] public int bulletCount;
    [XmlAttribute] public float bulletCd;
    [XmlAttribute] public float fireCd;
}