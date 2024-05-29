using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditPlate : MonoBehaviour
{
    public Properties properties = new Properties();
    [Header("Base Window")]
    public InputFieldChanger ProjectName;
    public InputFieldChanger ProjectDescription;

    public Button ContinueButton;
    private Preview preview;
    

    [SerializeField] private ToggleMechanic passwordToggle;
    [SerializeField] private ToggleMechanic timeToggle;
    [SerializeField] private ToggleMechanic checkListToggle;

    [SerializeField] private PinCodeManager pinCodeManager;
    [SerializeField] private Calendar calendar;
    [SerializeField] private CheckListInEditor checkList;
    [SerializeField] private TimeGetter timeGetter;
    [SerializeField] private PhotoesManager photoesManager;

    [SerializeField] private TextMeshProUGUI textScreenName;
    [SerializeField] private TextMeshProUGUI textInButton;

    public void Init(Properties props,Preview preview)
    {
        properties = props;
        this.preview = preview;

        ProjectName.ChangeText(props.Name);
        ProjectDescription.ChangeText(props.Description);


        checkList.Init(props.CheckList);
        photoesManager.Init(properties.Photoes);
        ContinueButton.onClick.RemoveAllListeners();
        ContinueButton.onClick.AddListener(() => 
        {
            SavePlateData();
            Destroy(gameObject);
        });
        textScreenName.text = "Editing a note";
        textInButton.text = "Save";
    }
    private void OpenWindow(bool state,GameObject window)
    {
        window.SetActive(state);
    }
    private void Awake()
    {
        ContinueButton.onClick.AddListener(() =>
        {
            CreatePlateData();
            Destroy(gameObject);
        });

        passwordToggle.Init((state) => { OpenWindow(state, pinCodeManager.gameObject); });
        timeToggle.Init((state) => { OpenWindow(state, calendar.gameObject); });
        checkListToggle.Init((state) => { OpenWindow(state, checkList.gameObject); });

        pinCodeManager.Init(ChangePinCode);
        calendar.Init(ChangeDay, 1);
        timeGetter.Init(ChangeTime);
    }
    private void ChangePinCode(string str)
    {
        properties.Password = str;
    }
    private void ChangeDay(Day day)
    {
        properties.Date = day.DateTime.ToString().Remove(10);
        calendar.SetDayStates();
    }
    [SerializeField] private TextMeshProUGUI timeTMP;
    private void ChangeTime(string time)
    {
        timeTMP.text = time;
        properties.Time = time;
    }
    public void SavePlateData()
    {
        FillPlateData();
        DataProcessor.Instance.EditPlate(properties);
        preview.Init(properties);
    }

    public void CreatePlateData()
    {
        FillPlateData();
        DataProcessor.Instance.AddNewPlate(properties);

    }

    private void FillPlateData()
    {
        properties.Name = ProjectName.text;
        properties.Description = ProjectDescription.text;
        if (!passwordToggle.currentState)
            properties.Password = "";
        if (!timeToggle.currentState)
        {
            properties.Date = "";
            properties.Time = "";
        }
        if(checkListToggle.currentState)
            properties.CheckList = checkList.GetAllData();
        else
            properties.CheckList = new List<Check>();
        properties.Photoes = photoesManager.GetAllData();
    }
}
