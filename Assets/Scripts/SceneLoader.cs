using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static Image fadePanel;
    private float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void InitializeSceneFader()
    {
        fadePanel = GameObject.Find("FadePanel").GetComponent<Image>();
        if (fadePanel == null)
        {
            Debug.LogError("Could not find fade panel in the scene.");
        }
        fadePanel.gameObject.SetActive(false);
    }

    public void FadeToScene(int index)
    {
        StartCoroutine(FadeOut(index));
    }

    public void FadeToSceneName(string sceneName)
    {   
        if (SceneManager.GetSceneByName(sceneName) == null)
        {
            Debug.LogError($"Scene {sceneName} does not exist.");
            return;
        }
        StartCoroutine(FadeOutName(sceneName));
    }

    private IEnumerator FadeIn()
    {   
        if (fadePanel == null)
        {
            fadePanel = GameObject.Find("FadePanel").GetComponent<Image>();
        }
        float alpha = 1f;
        Color panelColor = fadePanel.color;
        fadePanel.gameObject.SetActive(true);
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime / fadeDuration;
            fadePanel.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }
        Debug.Log("Fading in complete");
        fadePanel.gameObject.SetActive(false);

        OnSceneLoaded();
    }

    private IEnumerator FadeOutName(string sceneName)
    {
        float alpha = 0f;
        fadePanel.gameObject.SetActive(true);
        Color panelColor = fadePanel.color;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadePanel.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeIn());
    }
    private IEnumerator FadeOut(int sceneIndex)
    {
        float alpha = 0f;
        fadePanel.gameObject.SetActive(true);
        Color panelColor = fadePanel.color;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadePanel.color = new Color(panelColor.r, panelColor.g, panelColor.b, alpha);
            yield return null;
        }
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
        StartCoroutine(FadeIn());
    }

    private void OnSceneLoaded()
    {   
        StartCoroutine(CheckAutoDialogue());
    }

    private IEnumerator CheckAutoDialogue()
    {   
        yield return null;
        string currentLocation = SceneManager.GetActiveScene().name;

        string knotName = GenerateKnotName(currentLocation);
        if (CheckKnotExists(knotName))
        {   
            GameEventsManager.Instance.dialogueEvents.EnterDialogue(knotName);
        }
    }

    private string GenerateKnotName(string location)
    {
        return $"{location}_Day{TimeSystem.CurrentDay}_{TimeSystem.CurrentTimePeriod}";
    }

    private bool CheckKnotExists(string knotName)
    {
        return DialogueManager.Instance.CheckKnotExists(knotName);
    }
}
