
###  [ `Return` ](https://github.com/PicoSupport/PicoSupport)

## Unity_Demo_GetPhoneCameraImageDemo

## Unity_Versions：
- 2017.1.0f3 Or UP

## Explain：

- Access the front camera of the pico device

Demo Main Code **GetPhoneCameraImageDemo.cs**

```C#
public class GetPhoneCameraImageDemo : MonoBehaviour
{   
    public RawImage rawImage;
    private string deviceName;
    private WebCamTexture webCam;
    void Start()
    {
        StartCoroutine(Call());
    }
    public IEnumerator Call()
    {
        // Apply for permission 
        //UserAuthorization.WebCam 
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

```

## Use：
- DemoScene： Assets -> DemoScene -> GetPhoneCameraImageDemo
- Pack Apk file, open in pico device, can see the camera screen

## Announcements：
- Demo apply to Pico G2 Pro

