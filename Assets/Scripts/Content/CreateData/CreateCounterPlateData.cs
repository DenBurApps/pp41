using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCounterPlateData : CreatePlateData
{
    public override void Save()
    {
        properties.tag = "Counter";
        properties.name = nameField.text;
        properties.info1 = DateTime.Now.ToString();
        DataProcessor.Instance.AddNewPlate(properties);

    }
}
