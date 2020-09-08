using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPhoneCameraImageDemo : MonoBehaviour
{   
    public RawImage rawImage;

    private string deviceName;
    private WebCamTexture webCam;
    
    void Start()
    {
        StartCoroutine(Call());
    }
	
	// Update is called once per frame
	void Update () {
		
	}    

    public IEnumerator Call()
    {
        // Apply for permission
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            // Get camera device
            WebCamDevice[] devices = WebCamTexture.devices;

            // get the first camera name
            deviceName = devices[0].name;

            // create a WebCamTexture
            webCam = new WebCamTexture(deviceName, Screen.width, Screen.height, 60);
            
            // set the texture to rawImage in the scene
            rawImage.texture = webCam;

            // enable camera
            webCam.Play();
        }
    }
}
