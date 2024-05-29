using System;
using UnityEngine;
using UnityEngine.UI;

public class ImagePicker : MonoBehaviour
{
	[SerializeField] private Image _image;
    public Button DeleteButton;
    public string CurrentPath;

    private Vector2 standartSize;
    [SerializeField] private PreferedLocale preferedExtension = PreferedLocale.Width;
    public void Init(string path)
    {
        var imgTransform = _image.GetComponent<RectTransform>();
        standartSize = new Vector2(imgTransform.sizeDelta.x, imgTransform.sizeDelta.y);
        Debug.Log(standartSize);
        if (path != "" && path != null)
        {
            GetImageFromGallery.SetImage(path, _image);
            CurrentPath = path;
        }
        else
            Debug.Log("Path is not correct");
        SetNormalSize();
    }

    private void SetNormalSize()
    {
        Texture texture = _image.mainTexture;

        float differenceInImage;

        if (preferedExtension == PreferedLocale.Width) 
        {
            differenceInImage = standartSize.y / texture.width;
        }
        else
        {
            differenceInImage = standartSize.y / texture.height;

        }
        float normalWidth = texture.width * differenceInImage;
        float normalHeight = texture.height * differenceInImage;
        var imgTransform = _image.GetComponent<RectTransform>();

        imgTransform.sizeDelta = new Vector2(normalWidth, normalHeight);
    }
}
[Serializable]
public enum PreferedLocale
{
    Width,
    Height
}