using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class Cam : MonoBehaviour
{
    [SerializeField] private RawImage image = default;
    private WebCamTexture cam;

    private void Start()
    {
        image.color = UnityEngine.Color.white;

        cam = new WebCamTexture(1800, 2646);
        
        if (WebCamTexture.devices.Length > 0)
        {
            cam.deviceName = WebCamTexture.devices[0].name;
            
            cam.Play();

            if (cam.isPlaying)
            {
                Debug.Log("Camera is playing.");
            }
            else
            {
                Debug.LogError("Camera failed to play.");
            }
        }
        else
        {
            Debug.LogError("No webcam found.");
        }

        image.texture = cam;
    }

    private void Update()
    {
        if (cam.isPlaying)
        {
            image.texture = cam;
        }
    }
}
