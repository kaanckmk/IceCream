using UnityEngine;
using System.Collections;
using com.flamingo.icecream.managers;

public class ScreenShot : MonoBehaviour 
{
    public int resWidth = 2550; 
    public int resHeight = 3300;
 
    private bool takeHiResShot = false;
    private float _timer=0f;

    [SerializeField] private LevelManager _levelManager;
    
     
    private void OnEnable()
    {
        Actions.OnNewLevelStarted += TakeScreenShot;
    }

    private void OnDisable()
    { 
        Actions.OnNewLevelStarted -= TakeScreenShot;
    }

    public  string ScreenShotName(int width, int height) {
        return string.Format("{0}/Resources/LevelTargetImages/{1}.png", 
            Application.dataPath, 
            _levelManager.currentLevel);
    }

    public void TakeScreenShot()
    {
            StartCoroutine(WaitTillTargetImageFinished());
            
    }

    IEnumerator WaitTillTargetImageFinished()
    {
        yield return new WaitForSeconds(7);
        
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        GetComponent<Camera>().targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        takeHiResShot = false;
        Actions.OnTargetCreated?.Invoke();
    }

}