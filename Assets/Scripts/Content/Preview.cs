using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour
{
    public static Preview Instance;

    private Properties properties;

    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Date;
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private GameObject DateAndTimeHolder;
    [SerializeField] private PopUp deleteWindow;
    [SerializeField] private CheckMarkManager checkMarkManager;
    [SerializeField] private PhotoesManager photoesManager;
    public void Init(Properties props)
    {
        properties = props;

        Name.text = props.Name;
        Description.text = props.Description;

        if(props.Date != "")
        {
            Date.text = props.Date;
            Time.text = props.Time;
        }
        else
            DateAndTimeHolder.SetActive(false);

        deleteWindow.Init(DeleteProject);
        SetFavoriteStatus(props.favorite);

        if (props.CheckList.Count > 0)
            checkMarkManager.Init(props.CheckList);
        else
            checkMarkManager.gameObject.SetActive(false);

        if (props.Photoes.Count > 0)
            photoesManager.Init(props.Photoes);
        else
            photoesManager.gameObject.SetActive(false);
    }

    public void DeleteProject()
    {
        DataProcessor.Instance.DeletePlate(properties);
        Destroy(gameObject);
    }

    private void Awake()
    {
        Instance = this;
        likeButton.onClick.AddListener(() => { SetFavoriteStatus(true); });
        unLikeButton.onClick.AddListener(() => { SetFavoriteStatus(false); });

    }
    public void SaveData()
    {
        properties.CheckList = checkMarkManager.ReturnData();
    }
    public EditPlate editPlateWindow;
    public void OpenEditWindow()
    {
        SaveData();
        var obj = Instantiate(editPlateWindow, transform);
        obj.Init(properties,this);
    }
    [SerializeField] private Button likeButton;
    [SerializeField] private Button unLikeButton;

    public void SetFavoriteStatus(bool status)
    {
        likeButton.gameObject.SetActive(!status);
        unLikeButton.gameObject.SetActive(status);
        properties.favorite = status;
    }
}
