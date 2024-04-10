using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasePlate : MonoBehaviour
{
    public Properties properties;
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private protected TextMeshProUGUI infoTMP;
    [SerializeField] private protected Image plateImage;
    private protected CreatePlateData plateEditor;
    private protected GameObject editWindowsParent;
    public virtual void Init(Properties props,CreatePlateData plateEditor, GameObject editWindowsParent)
    {
        properties = props;
        if (properties.name != "")
            nameTMP.text = properties.name;
        else nameTMP.text = properties.tag;

        infoTMP.text = properties.info1;

        this.editWindowsParent = editWindowsParent;
        this.plateEditor = plateEditor;

        Color color;
        ColorUtility.TryParseHtmlString(properties.textColor, out color);

        nameTMP.color = color;
        ColorUtility.TryParseHtmlString(properties.plateColor, out color);
        plateImage.color = color;

        if(properties.favorite)
        {
            unFavButton.gameObject.SetActive(true);
            favButton.gameObject.SetActive(false);
        }
        unFavButton.onClick.AddListener(() =>
        {
            SetFavorite(false);
        });
        favButton.onClick.AddListener(() =>
        {
            SetFavorite(true);
        });
    }

    public virtual void OpenEditWindow()
    {
        editWindowsParent.SetActive(true);
        plateEditor.gameObject.SetActive(true);

        editWindowsParent.GetComponent<Animator>().SetTrigger("Open");
        plateEditor.OpenEditWindow(properties);
        if(properties.tag =="Secret")
            (plateEditor as CreateSecretPlateData).inEdit = true;
    }
    [SerializeField] private protected Button favButton;
    [SerializeField] private protected Button unFavButton;

    protected virtual void SetFavorite(bool fav)
    {
        favButton.gameObject.SetActive(!fav);
        unFavButton.gameObject.SetActive(fav);

        properties.favorite = fav;

        Parser.StartSave();
    }
}
