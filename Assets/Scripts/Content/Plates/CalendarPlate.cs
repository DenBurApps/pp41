using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarPlate : BasePlate
{
    [SerializeField] private Calendar calendar;
    public override void Init(Properties props, CreatePlateData plateEditor, GameObject editWindowsParent)
    {
        base.Init(props, plateEditor, editWindowsParent);
        DateTime.TryParse(properties.info1, out DateTime choosedDate);
        calendar.Init(null, 1);
        calendar.UpdateCalendar(choosedDate.Year, choosedDate.Month);
        calendar.DisableAllDays();

        foreach(var obj in calendar.days) 
            if(obj.DateTime == choosedDate)
                obj.SetDayChoosedState();

    }
}
