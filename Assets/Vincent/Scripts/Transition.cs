using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/*
 * 
 *  autheur : M.ChatGPT
 */
public class Transition : MonoBehaviour
{
    public Image fadeImage;       // Assign your black Image here
    public float fadeDuration = 1.0f; // How fast it fades

    private void Start()
    {
        // Optional: start fully transparent
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 0f;
            fadeImage.color = color;
        }
    }

    public void FadeIn()  // Fade to black
    {
        StartCoroutine(Fade(1));
    }

    public void FadeOut() // Fade back to transparent
    {
        StartCoroutine(Fade(0));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeImage.color.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        // Snap exactly to target alpha
        Color finalColor = fadeImage.color;
        finalColor.a = targetAlpha;
        fadeImage.color = finalColor;
    }
}
