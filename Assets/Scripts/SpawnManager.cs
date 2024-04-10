using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] private InputFieldChanger searchField;
    private List<BasePlate> AllPlates = new List<BasePlate>();

    [SerializeField] private Transform spawnPlace;

    public string CurrentSpawnType = "all";

    [Header("Plates")]
    [SerializeField] private BasePlate notePlate;
    [SerializeField] private CounterPlate counterPlate;
    [SerializeField] private CheckpointPlate checkpointPlate;
    [SerializeField] private BasePlate secretPlate;
    [SerializeField] private CalendarPlate calendarPlate;

    [Header("Edit Windows")]
    [SerializeField] private CreatePlateData noteEditor;
    [SerializeField] private CreateCounterPlateData counterEditor;
    [SerializeField] private CreateCheckpointPlateData checkpointEditor;
    [SerializeField] private CreateSecretPlateData secretEditor;
    [SerializeField] private CreateCalendarPlateData calendarEditor;
    public GameObject editWindowsParent;
    private bool canSpawnOnlyFavoryte;

    public void ChangeFavoriteSpawn()
    {
        canSpawnOnlyFavoryte = !canSpawnOnlyFavoryte;
        SpawnAllPlates();
    }
    public void Awake()
    {
        Instance = this;

    }
    [SerializeField] private GameObject Empty;
    public void SpawnAllPlates()
    {
        ClearPlates();

        foreach (var item in DataProcessor.Instance.allData.properties)
        {
            if (canSpawnOnlyFavoryte)
            {
                if (item.favorite)
                {
                    if (CurrentSpawnType == "all")
                        Spawn(item);
                    else
                    {
                        if (CurrentSpawnType == item.tag)
                            Spawn(item);
                    }
                }
            }
            else
            {
                if (CurrentSpawnType == "all")
                    Spawn(item);
                else
                {
                    if (CurrentSpawnType == item.tag)
                        Spawn(item);
                }
            }
        }

        if (AllPlates.Count == 0)
            Empty.SetActive(true);
        else
            Empty.SetActive(false);

        void Spawn(Properties item)
        {
            if (searchField.text == "")
                SpawnOnePlate(item);
            else
            {
                bool fieldContains = false;
                if (item.name.Contains(searchField.text))
                    fieldContains = true;
                else if (item.info1.Contains(searchField.text))
                    fieldContains = true;
                else if (item.info2.Contains(searchField.text))
                    fieldContains = true;

                if (fieldContains)
                    SpawnOnePlate(item);
            }

        }
    }
    private void SpawnOnePlate(Properties props)
    {
        BasePlate obj;
        switch(props.tag)
        {
            case "Note":
                {
                    obj = Instantiate(notePlate, spawnPlace);
                    obj.Init(props, noteEditor, editWindowsParent);

                    break;
                }
            case "Counter":
                {
                    obj = Instantiate(counterPlate, spawnPlace);
                    obj.Init(props, counterEditor, editWindowsParent);

                    break;
                }
            case "CheckPoint":
                {
                    obj = Instantiate(checkpointPlate, spawnPlace);
                    obj.Init(props, checkpointEditor, editWindowsParent);

                    break;
                }
            case "Secret":
                {
                    obj = Instantiate(secretPlate, spawnPlace);
                    obj.Init(props, secretEditor, editWindowsParent);

                    break;
                }
            case "Calendar":
                {
                    obj = Instantiate(calendarPlate, spawnPlace);
                    obj.Init(props, calendarEditor, editWindowsParent);

                    break;
                }
            default:
                {
                    obj = Instantiate(notePlate, spawnPlace);
                    obj.Init(props,noteEditor, editWindowsParent);

                    break;
                }
        }

        AllPlates.Add(obj);
    }

    private void ClearPlates()
    {
        foreach (var plate in AllPlates)
            Destroy(plate.gameObject);
        AllPlates.Clear();
    }
}
