using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {
    public GameObject iconSpritePrefab;
    public List<GameObject> multipleChoicePanels;

    private GameObject textPanel;
    private Text displayedText;
    private GameObject iconSprite;
    
    void Start()
    {
        iconSprite = Instantiate(iconSpritePrefab);
        iconSprite.transform.SetParent(transform);
        iconSprite.transform.position = new Vector3(Screen.width/2,Screen.height/2+50);
        displayedText = GetComponentInChildren<Text>();
        if (displayedText == null) Debug.LogError("Can't find GUIText");
    }
    public void DisplayMultipleChoiceText(string text,int index)
    {
        multipleChoicePanels[index].GetComponentInChildren<Text>().text = text;
    }
    public void DisplayText(string text)
    {
        displayedText.text = text;
    }
    public void DisplayIcon(bool displayIcon)
    {
        iconSprite.gameObject.SetActive(displayIcon);
    }
}
