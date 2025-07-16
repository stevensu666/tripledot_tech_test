using UnityEngine;
using UnityEngine.UI; // Required for Button

public class OpenWebsite : MonoBehaviour
{
    public string url = "https://www.tripledotstudios.com/";
    public Button targetButton; // Assign this in the Inspector

    void Start()
    {
        if (targetButton != null)
        {
            // Add a listener to the button's click event
            targetButton.onClick.AddListener(OpenURL);
        }
        else
        {
            Debug.LogWarning("No button assigned to OpenWebsite script.");
        }
    }

    public void OpenURL()
    {
        Debug.Log("Opening URL: " + url);
        Application.OpenURL(url);
    }
}