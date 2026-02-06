using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class cameraFeature : MonoBehaviour
{
    public RawImage displayImage;
    int webcamIndex = 0; // 0 = first webcam
    private WebCamTexture webcamTexture;
    private bool isPlaying = false;

    //OPACITY
    [SerializeField] Slider opacitySlider;
    [SerializeField] Material material;

    void Start()
    {
        StartCoroutine(InitializeWebcam());
        opacitySlider.value = PlayerPrefs.GetFloat("opacity");//load opacity
    }

    IEnumerator InitializeWebcam()
    {
        // Request camera permission (NEEDED for mobile or else wouldnt work...bc ofc you need to ask duh)
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.LogError("Camera permission not granted!");
            yield break;
        }

        // Get available webcams
        WebCamDevice[] devices = WebCamTexture.devices;//we're just gonna use the first one so back camera
        
        if (devices.Length == 0)
        {
            Debug.LogError("No webcam found!");
            yield break;
        }

        // Use selected webcam or default to first
        string selectedDevice = devices[Mathf.Min(webcamIndex, devices.Length - 1)].name;
        
        // Create webcam texture
        webcamTexture = new WebCamTexture(selectedDevice, 1920, 1080, 30);
        displayImage.texture = webcamTexture;
        
        // Start the webcam
        webcamTexture.Play();
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying && webcamTexture != null && webcamTexture.didUpdateThisFrame)
        {
            // Fix mirroring if needed (webcams are usually mirrored)
            displayImage.rectTransform.localScale = new Vector3(-1, 1, 1);
        }

        //OPACITY
        material.color = new Color(1, 1, 1, opacitySlider.value);//set opacity
        PlayerPrefs.SetFloat("opacity", opacitySlider.value);//save opacity
    }

    void OnDestroy()//this is just good practice
    {
        StopWebcam();
    }

    public void StopWebcam()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Stop();
            isPlaying = false;
        }
    }
}