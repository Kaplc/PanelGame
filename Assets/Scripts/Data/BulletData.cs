using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BulletData
{
    public List<BulletInfo> bulletInfos = new List<BulletInfo>();
}

public class BulletInfo
{
    [XmlAttribute]
    public int id;
    [XmlAttribute]
    public int type;
    [XmlAttribute]
    public float forwardSpeed;
    [XmlAttribute]
    public float rightSpeed;
    [XmlAttribute]
    public int lifeTime;
}
