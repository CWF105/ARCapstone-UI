using UnityEngine;
using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour
{
    private Button[] buttons; 
    private Vector3 originalScale = Vector3.one; 
    public float scaleFactor = 1.2f;
    public Color selectedColor = Color.green; 
    private Color originalColor;
    public Text displayText; 

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            ColorBlock colorBlock = button.colors;
            originalColor = colorBlock.normalColor;

            button.onClick.AddListener(() => OnButtonClick(button));
        }

        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            button.transform.localScale = originalScale;
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = originalColor;
            button.colors = colorBlock;
        }

        clickedButton.transform.localScale = originalScale * scaleFactor;
        ColorBlock clickedButtonColorBlock = clickedButton.colors;
        clickedButtonColorBlock.normalColor = selectedColor;
        clickedButton.colors = clickedButtonColorBlock;

        if (displayText != null)
        {
            displayText.gameObject.SetActive(true);
            displayText.text = clickedButton.name; 
        }
    }
}
