using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine.EventSystems;

public class OpenKeyboard : MonoBehaviour
{
   private InputField inputField;
    private Process keyboardProcess;

    [DllImport("user32.dll")]
    private static extern void SetForegroundWindow(System.IntPtr hWnd);

    void Start()
    {
        inputField = GetComponent<InputField>();

        // Listen for the InputField's end edit event to close the keyboard
        inputField.onEndEdit.AddListener(OnDeselect);
    }

    // Open keyboard when Input Field is selected (clicked on)
    public void OnPointerClick(PointerEventData eventData)
    {
        keyboardProcess = Process.Start("C:\\Program Files\\Common Files\\Microsoft Shared\\ink\\TabTip.exe");
    }

    // Close keyboard when Input Field loses focus (deselected)
    void OnDeselect(string text)
    {
        // Kill the keyboard process (close it)
        if (keyboardProcess != null && !keyboardProcess.HasExited)
        {
            keyboardProcess.Kill();
        }
    }
}
