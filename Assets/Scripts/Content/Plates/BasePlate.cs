using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasePlate : MonoBehaviour
{
    public Properties properties;

    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI descriptionTMP;
    [SerializeField] private TextMeshProUGUI dateAndTimeTMP;

    [SerializeField] private GameObject dateTag;
    [SerializeField] private GameObject checkTag;
    [SerializeField] private GameObject photoTag;

    public GameObject hiddenObj;

    [SerializeField] private Preview preview;
    private Transform previewSpawnPlace;
    private PlatePinCodeController pinCodeController;
    public void Init(Properties props,Transform previewSpawnPlace, PlatePinCodeController platePinCodeController)
    {
        properties = props;
        this.previewSpawnPlace = previewSpawnPlace;
        pinCodeController = platePinCodeController;

        nameTMP.text = props.Name;
        nameTMP.gameObject.GetComponent<TruncateText>().Truncate();

        descriptionTMP.text = props.Description;
        descriptionTMP.gameObject.GetComponent<TruncateText>().Truncate();

        dateAndTimeTMP.text = props.Date + "\n" + props.Time;

        CheckTags();
        var plateButton = GetComponent<Button>();
        if (props.Password != "")
        {
            hiddenObj.SetActive(true);
            plateButton.onClick.AddListener(() => {
                pinCodeController.plate = this;
                pinCodeController.ClearInput();
                pinCodeController.gameObject.SetActive(true);
            });
        }
        else
        {
            hiddenObj.SetActive(false);
            plateButton.onClick.AddListener(OpenPreview);
        }
    }
    [SerializeField] private GameObject tagsHolder;
    private void CheckTags()
    {
        bool DisableTagsHolder = true;
        if(properties.Date != "")
        {
            DisableTagsHolder = false;
            dateTag.SetActive(true);
        }
        else
            dateTag.SetActive(false);

        if(properties.CheckList.Count > 0)
        {
            DisableTagsHolder = false;
            checkTag.SetActive(true);
        }
        else
            checkTag.SetActive(false);

        if(properties.Photoes.Count > 0)
        {
            DisableTagsHolder = false;
            photoTag.SetActive(true);
        }
        else 
            photoTag.SetActive(false);

        if (DisableTagsHolder)
            tagsHolder.SetActive(false);
        else 
            tagsHolder.SetActive(true);
    }
    public void OpenPreview()
    {
        var obj = Instantiate(preview,previewSpawnPlace);
        obj.Init(properties);
    }
}
