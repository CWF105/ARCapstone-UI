using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to the TMP Input Field
    public Button sendButton;          // Reference to the Send Button

    private void OnEnable()
    {
        // Add listener to the TMP_InputField for when it is selected
        if (inputField != null)
        {
            inputField.onSelect.AddListener(OnInputFieldSelected);
        }
    }

    private void OnDisable()
    {
        // Remove listener when the script is disabled
        if (inputField != null)
        {
            inputField.onSelect.RemoveListener(OnInputFieldSelected);
        }
    }

    private void OnInputFieldSelected(string text)
    {
        // Open the on-screen keyboard when the input field is selected
        ShowOnScreenKeyboard();
    }

    private void ShowOnScreenKeyboard()
    {
        // Open the on-screen keyboard using System.Diagnostics (osk.exe)
        System.Diagnostics.Process.Start("osk.exe");
    }

    // This method is called when the Send button is clicked
    public void onSend() 
    {
        if (inputField != null)
        {
            // Get the text from the input field (use inputField.text)
            string inputText = inputField.text;

            // Check if there is input and log the text, else log "NO TEXT"
            if (!string.IsNullOrEmpty(inputText)) // Checks for both null and empty string
            {
                Debug.Log("Input text: " + inputText);
            }
            else
            {
                Debug.Log("NO TEXT");
            }
        }
        else
        {
            Debug.LogError("Input Field is not assigned in the Inspector.");
        }
    }
}
