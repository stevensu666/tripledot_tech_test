using UnityEngine;
using UnityEngine.UI;

public class BottomBarView : MonoBehaviour
{
    public GameObject LockedUI;
    public Toggle toggle;  // Reference to your Toggle

    void Start()
    {
        if (toggle != null)
        {
            toggle.isOn = false;        
            LockedUI.SetActive(true); 
            toggle.onValueChanged.AddListener(OnToggleChanged);
              
        }

        

        else
        {
            Debug.LogWarning("Toggle reference not assigned!");
        }
    }

    // Called when toggle changes state
    public void OnToggleChanged(bool isOn)
    {
        LockedUI.SetActive(!isOn);
    }
}