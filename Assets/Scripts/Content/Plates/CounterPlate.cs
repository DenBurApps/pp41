using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterPlate : BasePlate
{
    public override void Init(Properties props, CreatePlateData plateEditor, GameObject editWindowsParent)
    {
        base.Init(props, plateEditor, editWindowsParent);

        StartCoroutine(Counter());
    }

    private IEnumerator Counter()
    {
        while (true)
        {
            DateTime.TryParse(properties.info1,out DateTime time);

            string str = (DateTime.Now - time).ToString();

            infoTMP.text = str.Remove(str.Length - 8);
            yield return new WaitForSeconds(1);

        }
    }
}
