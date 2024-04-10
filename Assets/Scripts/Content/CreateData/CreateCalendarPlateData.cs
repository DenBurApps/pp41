using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCalendarPlateData : CreatePlateData
{
    [SerializeField] private Calendar calendar;

    public override void Awake()
    {
        base.Awake();
        calendar.Init(SetDate, 1);
    }
    public override void Save()
    {
        properties.name = nameField.text;
        properties.tag = tagInPlate;
        if (properties.info1 == "")
            properties.info1 = DateTime.Now.ToString();
        DataProcessor.Instance.AddNewPlate(properties);
    }

    public override void Edit()
    {
        properties.name = nameField.text;
        SpawnManager.Instance.SpawnAllPlates();
        Parser.StartSave();
    }
    private void SetDate(Day day)
    {
        properties.info1 = day.DateTime.ToString();
        calendar.SetDayStates();
    }
}
