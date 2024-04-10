using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointInPlate : MonoBehaviour
{
    private bool isChecked;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject checkedImage;
    private CheckpointPlate plate;
    private int ID;
    
    public void Init(string name, bool check, CheckpointPlate plate,int id)
    {
        text.text = name;
        isChecked = check;
        this.plate = plate;
        ID = id;
        ChangeButtonState();
    }

    public void OnClick()
    {
        isChecked = !isChecked;
        plate.properties.checkPoints[ID].activated = isChecked;
        ChangeButtonState();
        Parser.StartSave();
    }
    private void ChangeButtonState()
    {
        checkedImage.SetActive(!isChecked);
    }
}
