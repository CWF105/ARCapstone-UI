using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_function : MonoBehaviour
{
    public void LoadSceneByName(string sceneName){SceneManager.LoadScene(sceneName);}
}
