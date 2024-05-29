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
    public string Name;
    public string Description;
    public string Password;
    public string Date;
    public string Time;

    public List<Check> CheckList = new List<Check>();
    public List<string> Photoes = new List<string>();
    public bool favorite;
    public int ID;
}
[Serializable]
public class Check
{
    public string Name;
    public bool Checked = false;
    public int ID;
}
