using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ThemeChanger : MonoBehaviour
{
    [SerializeField] private Image back;
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Image[] images;
    public void ChangeBG(bool theme)
    {
        Color color;

        if (theme)
        {
            ColorUtility.TryParseHtmlString("#4F4F63", out color);
            back.color = color;
            foreach (var text in texts)
            {
                text.color = Color.white;
            }
            foreach (var image in images)
            {
                image.color = Color.white;
            }
        }
        else
        {
            back.color = Color.white;

            ColorUtility.TryParseHtmlString("#522C56", out color);
            foreach (var text in texts)
            {
                if(text.text != "all")
                    text.color = color;
            }
            foreach (var image in images)
            {
                image.color = color;
            }
        }
        //DataProcessor.Instance.allData.theme = theme;
        Parser.StartSave();
    }
}
