using UnityEngine;

public class DebugerScript : MonoBehaviour
{
    public void onClickDebug(string title) {
        Debug.Log(title + " button is clicked!.");
    }
}
