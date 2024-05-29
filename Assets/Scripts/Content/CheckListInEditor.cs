using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckListInEditor : MonoBehaviour
{
    [SerializeField] private List<InputFieldChanger> checkList = new List<InputFieldChanger>();
    [SerializeField] private InputFieldChanger prefab;

    public void Init(List<Check> checks)
    {
        foreach (var check in checks)
        {
            var obj = SpawnCheck();
            obj.ChangeText(check.Name);
        }
    }
    public InputFieldChanger SpawnCheck()
    {
        var obj = Instantiate(prefab, transform);
        checkList.Add(obj);
        obj.GetComponent<CheckInEditor>().DeleteButton.onClick.AddListener(() => { DeleteCheck(obj); });
        return obj;
    }
    public void AddNewCheck()
    {
        SpawnCheck();
    }
    private void DeleteCheck(InputFieldChanger check)
    {
        Destroy(check.gameObject);
        checkList.Remove(check);
    }
    public List<Check> GetAllData()
    {
        List <Check> list = new List<Check>();
        foreach (var check in checkList)
        {
            Check newCheck = new Check();
            newCheck.Name = check.text;
            list.Add(newCheck);
        }
        return list;
    }
}
