using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverFloat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    public float floatHeight = 10f;
    public float floatSpeed = 5f;
    private bool isHovering = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition3D;
    }

    void Update()
    {
        if (isHovering)
        {
            Vector3 target = originalPosition + new Vector3(0, floatHeight, 0);
            rectTransform.anchoredPosition3D = Vector3.Lerp(rectTransform.anchoredPosition3D, target, Time.deltaTime * floatSpeed);
        }
        else
        {
            rectTransform.anchoredPosition3D = Vector3.Lerp(rectTransform.anchoredPosition3D, originalPosition, Time.deltaTime * floatSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }



}
