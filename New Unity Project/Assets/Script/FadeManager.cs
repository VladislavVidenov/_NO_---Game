using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance = null;
    Image whiteFadeImage;
    Image blackFadeImage;
    public float fade_time;

    
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != null)
            Destroy(gameObject);


        GameObject whiteFadeImage_go = GameObject.Find("whiteFadeImage");
        GameObject blackFadeImage_go = GameObject.Find("blackFadeImage");
    
      
        if (whiteFadeImage_go == null)
            Debug.Log("White fade image wrong name !! Please make sure it is \"whiteFadeImage\"");
        else
            whiteFadeImage = whiteFadeImage_go.GetComponent<Image>();

        if (blackFadeImage_go == null)
            Debug.Log("Black fade image wrong name !! Please make sure it is \"blackFadeImage\"");
        else
            blackFadeImage = blackFadeImage_go.GetComponent<Image>();

        
        FadeWhiteScreen(false, 0.1f);
        FadeBlackScreen(false);
    }

    /// <summary>
    /// Function to fade in/out a white screen.
    /// </summary>
    /// <param name="fade"> 'True' fades in , 'False' fades out!! </param>
    /// <param name="fadeSpeed"> Can be used if different than the default fade speed is desired.</param>
    public void FadeWhiteScreen(bool fade, float fadeSpeed = 0)
    {
        if (fade == true)
        { 
            if (fadeSpeed == 0)
            {
                whiteFadeImage.CrossFadeAlpha(1, fade_time, false);
            }
            else
            {
                whiteFadeImage.CrossFadeAlpha(1, fadeSpeed, false);
            }
           
        }
        else if (fade == false)
        {
            if (fadeSpeed == 0)
            {
                whiteFadeImage.CrossFadeAlpha(0, fade_time, false);
            }
            else
            {
                whiteFadeImage.CrossFadeAlpha(0, fadeSpeed, false);
            }
        }
    }

    /// <summary>
    /// Function to fade in/out a black screen.
    /// </summary>
    /// <param name="fade"> 'True' fades in , 'False' fades out!! </param>
    /// <param name="fadeSpeed"> Can be used if different than the default fade speed is desired.</param>
    public void FadeBlackScreen(bool fade, float fadeSpeed = 0)
    {
        if (fade == true)
        {
            if (fadeSpeed == 0)
            {
                blackFadeImage.CrossFadeAlpha(1, fade_time, false);
            }
            else
            {
                blackFadeImage.CrossFadeAlpha(1, fadeSpeed, false);
            }
           
        }
        else if (fade == false)
        {
            if (fadeSpeed == 0)
            {
                blackFadeImage.CrossFadeAlpha(0, fade_time, false);
            }
            else
            {
                blackFadeImage.CrossFadeAlpha(0, fadeSpeed, false);
            }
        }
           
    }
}
