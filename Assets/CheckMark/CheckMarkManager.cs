using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMarkManager : MonoBehaviour
{
    private List<CheckMark> marks = new List<CheckMark>();

    [SerializeField] private CheckMark checkMarkPrefab;
    [SerializeField] private Transform checkMarkSpawnPlace;

    public void Init(List<Check> checks)
    {
        ClearMarks();
        foreach (var check in checks) 
        {
            var mark = Instantiate(checkMarkPrefab, checkMarkSpawnPlace);
            mark.Init(check);
            marks.Add(mark);
        }

    }
    public List<Check> ReturnData()
    {
        List<Check> list = new List<Check>();
        foreach (var check in marks)
        {
            list.Add(check.ReturnStatus());
        }
        return list;
    }
    private void ClearMarks()
    {
        foreach (var mark in marks)
        {
            Destroy(mark.gameObject);
        }
        marks.Clear();
    }
}