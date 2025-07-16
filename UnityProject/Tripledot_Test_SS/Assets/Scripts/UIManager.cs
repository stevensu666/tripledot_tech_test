using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject SettingUI;
    public GameObject BackgroundOverlay;

    private CanvasGroup settingCanvasGroup;
    private CanvasGroup bgCanvasGroup;
    private RectTransform settingRect;

    private Coroutine currentRoutine;

    private Vector3 targetScale = new Vector3(0.45f, 0.45f, 0.45f);

    void Start()
    {
        settingRect = SettingUI.GetComponent<RectTransform>();

        // Setup CanvasGroups
        settingCanvasGroup = SettingUI.GetComponent<CanvasGroup>();
        if (settingCanvasGroup == null)
            settingCanvasGroup = SettingUI.AddComponent<CanvasGroup>();

        bgCanvasGroup = BackgroundOverlay.GetComponent<CanvasGroup>();
        if (bgCanvasGroup == null)
            bgCanvasGroup = BackgroundOverlay.AddComponent<CanvasGroup>();

        // Initialize hidden
        SettingUI.SetActive(false);
        BackgroundOverlay.SetActive(false);

        settingCanvasGroup.alpha = 0f;
        settingRect.localScale = Vector3.zero;

        bgCanvasGroup.alpha = 0f;
    }

    public void OnSettingPress()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        BackgroundOverlay.SetActive(true);
        SettingUI.SetActive(true);

        currentRoutine = StartCoroutine(OpenAnimation());
    }

    public void OnXPress()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(CloseAnimation());
    }

    private IEnumerator OpenAnimation()
    {
        float duration = 0.3f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);

            bgCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            settingCanvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            settingRect.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);

            yield return null;
        }

        bgCanvasGroup.alpha = 1f;
        settingCanvasGroup.alpha = 1f;
        settingRect.localScale = targetScale;
    }

    private IEnumerator CloseAnimation()
    {
        float duration = 0.3f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);

            bgCanvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            settingCanvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            settingRect.localScale = Vector3.Lerp(targetScale, Vector3.zero, t);

            yield return null;
        }

        bgCanvasGroup.alpha = 0f;
        settingCanvasGroup.alpha = 0f;
        settingRect.localScale = Vector3.zero;

        SettingUI.SetActive(false);
        BackgroundOverlay.SetActive(false);
    }
}