using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlateData : MonoBehaviour
{
    public Properties properties;
    [SerializeField] private protected string tagInPlate;

    [SerializeField] private protected InputFieldChanger nameField;
    [SerializeField] private protected InputFieldChanger infoField;

    [SerializeField] private protected FlexibleColorPicker textColorPicker;
    [SerializeField] private protected FlexibleColorPicker plateColorPicker;

    [SerializeField] private Button setTextColorButton;
    [SerializeField] private Button setPlateColorButton;

    [SerializeField] private Button itsReadyButton;
    [SerializeField] private Button deleteButton;

    public virtual void Awake()
    {
        deleteButton.onClick.AddListener(Delete);
    }
    protected virtual void OnEnable()
    {

    }
    public virtual void UpdateWindowState()
    {
        textColorPicker.onColorChange.RemoveAllListeners();
        plateColorPicker.onColorChange.RemoveAllListeners();

        setTextColorButton.onClick.RemoveAllListeners();
        setPlateColorButton.onClick.RemoveAllListeners();

        itsReadyButton.onClick.RemoveAllListeners();



        itsReadyButton.onClick.AddListener(Save);

        setTextColorButton.onClick.AddListener(SetColorChangesText);
        setPlateColorButton.onClick.AddListener(SetColorChangesPlate);

        textColorPicker.onColorChange.AddListener(ChangeColorInText);
        plateColorPicker.onColorChange.AddListener(ChangeColorInPlate);

        properties = new Properties();
        deleteButton.gameObject.SetActive(false);
    }
    public virtual void Save()
    {
        properties.name = nameField.text;
        properties.info1 = infoField.text;
        properties.tag = tagInPlate;
        DataProcessor.Instance.AddNewPlate(properties);
    }
    public virtual void Delete()
    {
        SpawnManager.Instance.editWindowsParent.GetComponent<Animator>().SetTrigger("Open");
        gameObject.GetComponent<Animator>().SetTrigger("Open");
        DataProcessor.Instance.allData.properties.Remove(properties);
        SpawnManager.Instance.SpawnAllPlates();
        Parser.StartSave();
    }
    public virtual void OpenEditWindow(Properties props)
    {
        itsReadyButton.onClick.RemoveAllListeners();
        itsReadyButton.onClick.AddListener(Edit);
        gameObject.GetComponent<Animator>().SetTrigger("Open");

        nameField.gameObject.GetComponent<TMP_InputField>().text = props.name;
        infoField.gameObject.GetComponent<TMP_InputField>().text = props.info1;

        deleteButton.gameObject.SetActive(true);

        properties = props;
    }
    public virtual void Edit()
    {
        properties.name = nameField.text;
        properties.info1 = infoField.text;
        SpawnManager.Instance.SpawnAllPlates();
        gameObject.GetComponent<Animator>().SetTrigger("Open");
        SpawnManager.Instance.SpawnAllPlates();
        Parser.StartSave();

        //DataProcessor.Instance.allData.properties[properties.ID] = properties;
    }
    private string choosedTextColor;
    private string choosedPlateColor;
    public GameObject textColorPickerGM;
    public GameObject plateColorPickerGM;
    public void SetColorChangesText()
    {
        properties.textColor = choosedTextColor;
        textColorPickerGM.SetActive(false);
    }
    public void SetColorChangesPlate()
    {
        properties.plateColor = choosedPlateColor;
        plateColorPickerGM.SetActive(false);
    }
    private void ChangeColorInText(Color color)
    {
        choosedTextColor = "#" + ColorUtility.ToHtmlStringRGB(color);
    }
    private void ChangeColorInPlate(Color color)
    {
        choosedPlateColor = "#" + ColorUtility.ToHtmlStringRGB(color);
    }
}
