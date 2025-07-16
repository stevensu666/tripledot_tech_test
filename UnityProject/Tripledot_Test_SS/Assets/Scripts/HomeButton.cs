using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public void DisableObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
    
    public void EnableObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }






}