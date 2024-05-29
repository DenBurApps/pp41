using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private List<BasePlate> AllPlates = new List<BasePlate>();

    [SerializeField] private BasePlate plate;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Transform spawnPreviewPoint;
    [SerializeField] private GameObject emptyObject;
    [SerializeField] private GameObject favoriteEmptyObject;

    [SerializeField] private EditPlate CreateDataWindow;
    [SerializeField] private Transform CreateDataSpawnPlace;
    [SerializeField] private PlatePinCodeController pinCodeController;

    public void SpawnCreateDataWindow()
    {
        Instantiate(CreateDataWindow, CreateDataSpawnPlace);
    }
    public void Start()
    {
        if (DataProcessor.Instance != null)
            SpawnAllPlates();
    }

    private void Awake()
    {
        Instance = this;
    }
    public void SpawnAllPlates()
    {
        ClearPlates();
        foreach (var item in DataProcessor.Instance.allData.properties)
        {
            if (Filter(item))
            {
                var obj = Instantiate(plate, spawnPoint);
                obj.Init(item, spawnPreviewPoint, pinCodeController);
                AllPlates.Add(obj);
                obj.gameObject.GetComponent<RectTransform>().SetSiblingIndex(0);
            }
        }
        if (SpawnState)
        {
            if (AllPlates.Count == 0) favoriteEmptyObject.SetActive(true); else favoriteEmptyObject.SetActive(false);
            emptyObject.SetActive(false);
        }
        else
        {
            if (AllPlates.Count == 0) emptyObject.SetActive(true); else emptyObject.SetActive(false);
            favoriteEmptyObject.SetActive(false);

        }
    }
    private void ClearPlates()
    {
        foreach (var plate in AllPlates)
            Destroy(plate.gameObject);
        AllPlates.Clear();
    }
    public void ChangeSpawnState(bool state)
    {
        SpawnState = state;
        SpawnAllPlates();
    }
    public bool SpawnState = false;
    [SerializeField] private TMP_InputField searchField;
    private bool Filter(Properties props)
    {
        if(searchField.text != "")
        {
            if (!props.Name.Contains(searchField.text) &&
                !props.Description.Contains(searchField.text))
                return false;
        }

        if (!SpawnState)
            return true;
        if (SpawnState && props.favorite)
            return true;
        return false;
    }
}
