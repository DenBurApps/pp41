using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCheckpointPlateData : CreatePlateData
{
    public override void Save()
    {
        string str = infoField.text;

        int i = 0;
        while (str.Contains('\n'))
        {
            CheckPoint chckp = new CheckPoint();

            chckp.name = str.Substring(0, str.IndexOf('\n'));
            chckp.activated = false;
            str = str.Remove(0, str.IndexOf('\n') + 1);
            properties.checkPoints.Add(chckp);
            Debug.Log(chckp.name);
            i++;
            if (i >= 10)
                break;
        }
        if(str.Length > 0)
        {
            CheckPoint chckp = new CheckPoint();

            chckp.name = str;
            properties.checkPoints.Add(chckp);
        }
        base.Save();
    }
    public override void Edit()
    {
        properties.checkPoints.Clear();

        string str = infoField.text;

        int i = 0;
        while (str.Contains('\n'))
        {
            CheckPoint chckp = new CheckPoint();

            chckp.name = str.Substring(0, str.IndexOf('\n'));
            chckp.activated = false;
            str = str.Remove(0, str.IndexOf('\n') + 1);
            properties.checkPoints.Add(chckp);
            Debug.Log(chckp.name);
            i++;
            if (i >= 10)
                break;
        }
        if (str.Length > 0)
        {
            CheckPoint chckp = new CheckPoint();

            chckp.name = str;
            properties.checkPoints.Add(chckp);
        }
        base.Edit();
    }

}