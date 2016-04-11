using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public Keys RequiredItem { get { return requiredItem; } }
    public bool requiresButtonInput;
    public Transform[] attachedButtons;

    [SerializeField]private Keys requiredItem;
    private bool[] buttonCombination;

    void Start()
    {
        buttonCombination = new bool[attachedButtons.Length];
        if (requiresButtonInput) SetupButtonCombination();
    }
    void Update()
    {
        if (!requiresButtonInput) return;
        if (HelpClass.IsArrayEqual(buttonCombination, GetButtonsCondition())) Destroy(gameObject);
    }
    void PrintArrays()
    {
        string buttonCombo = "button combination: ";
        foreach (bool other in buttonCombination)
        {
            buttonCombo += other.ToString()+ " ";
        }
        print(buttonCombo);
        string buttonCondition = "button condition: ";
        foreach (bool other in GetButtonsCondition())
        {
            buttonCondition += other.ToString() + " ";
        }
        print(buttonCondition);
    }
    private bool[] GetButtonsCondition()
    {
        bool[] buttonCondition = new bool[attachedButtons.Length];
        for (int i = 0; i < attachedButtons.Length; i++)
        {
            buttonCondition[i] = attachedButtons[i].GetComponent<ButtonScript>().Selected;
        }
        return buttonCondition;
    }
    void SetupButtonCombination()
    {
        for (int i = 0; i < attachedButtons.Length; i++)
        {
            buttonCombination[i] = attachedButtons[i].GetComponent<ButtonScript>().preferedState;
        }
    }

}
