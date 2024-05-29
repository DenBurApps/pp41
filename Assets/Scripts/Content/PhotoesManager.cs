using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoesManager : MonoBehaviour
{
    [SerializeField] private List<string> photoesLink = new List<string>();

    [SerializeField] private ImagePicker photoPrefab;
    [SerializeField] private List<ImagePicker> photoes = new List<ImagePicker>();
    [SerializeField] private Transform spawnPlace;
    public void Init(List<string> links)
    {
        photoesLink = links;
        foreach (var link in photoesLink)
        {
            SpawnPhoto(link);
        }
        CheckIfPhotoesEmpty();
    }
    public List<string> GetAllData()
    {
        return photoesLink;
    }
    public void TrySpawnPhoto()
    {
        GetImageFromGallery.PickImage(TakePhoto);

    }
    private void DeletePhoto(ImagePicker photo)
    {
        photoesLink.Remove(photo.CurrentPath);
        photoes.Remove(photo);
        CheckIfPhotoesEmpty();
        Destroy(photo.gameObject);
    }
    private void TakePhoto(string str)
    {
        if(str != null && str != "")
        {
            photoesLink.Add(str);
            SpawnPhoto(str);
        }
    }
    private ImagePicker SpawnPhoto(string link)
    {
        var photo = Instantiate(photoPrefab, spawnPlace);
        photo.Init(link);
        photo.DeleteButton.onClick.AddListener(() => DeletePhoto(photo));
        photoes.Add(photo);
        CheckIfPhotoesEmpty();
        return photo;
    }
    [SerializeField] private GameObject empty;
    private void CheckIfPhotoesEmpty()
    {
        if(empty != null)
        {
            if (photoes.Count == 0)
                empty.SetActive(true);
            else
                empty.SetActive(false);
        }
    }
}
