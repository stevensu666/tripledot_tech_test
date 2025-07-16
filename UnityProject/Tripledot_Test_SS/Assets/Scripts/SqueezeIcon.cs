using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverSqueezeManualWithClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    public float squeezeAmount = 0.6f;
    public float speed = 10f;

    private bool isHovering = false;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * squeezeAmount;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    private System.Collections.IEnumerator ClickPop()
    {
        transform.localScale = originalScale * 1.1f;
        yield return new WaitForSeconds(0.05f);
        targetScale = originalScale * squeezeAmount;
    }
}