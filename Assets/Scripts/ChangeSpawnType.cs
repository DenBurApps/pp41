using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpawnType : MonoBehaviour
{
    [SerializeField] private string spawnType;
    [SerializeField] private Image mainImage;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Sprite clickedImageSprite;
    [SerializeField] private Sprite notClickedImageSprite;



    private static ChangeSpawnType lastClickedButton;
    private void Start()
    {
        if (spawnType == "all")
            lastClickedButton = this;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        lastClickedButton.GetComponent<Button>().interactable = true;

        lastClickedButton.mainImage.sprite = notClickedImageSprite;
        lastClickedButton.mainImage.pixelsPerUnitMultiplier = 27;

        mainImage.sprite = clickedImageSprite;
        mainImage.pixelsPerUnitMultiplier = 12;

        GetComponent<Button>().interactable = false;
        lastClickedButton = this;

        SpawnManager.Instance.CurrentSpawnType = spawnType;
        SpawnManager.Instance.SpawnAllPlates();
    }
}
