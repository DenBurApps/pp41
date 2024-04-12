using System;
using System.Collections.Generic;

[Serializable]
public class Root
{
    public bool onBoarding;
    public List<Properties> properties = new List<Properties>();
}

[Serializable]
public class Properties
{
    public string tag;
    public string name;
    public string info1;
    public string info2;
    public string textColor = "#000000";
    public string plateColor = "#FFFFFF";
    public List<CheckPoint> checkPoints = new List<CheckPoint>();

    public bool favorite;
    public int ID;
}

[Serializable]
public class CheckPoint
{
    public string name;
    public bool activated;
}