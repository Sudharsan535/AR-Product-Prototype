using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject parentObject; // The parent object containing child objects.
    public string targetObjectName; // Name of the child object to make visible.
    public Button toggleButton; // Reference to the UI Button.

    private bool isShowingSpecific = false; // Track the current state.

    private void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleVisibility);
        }
        else
        {
            Debug.LogError("Toggle Button is not assigned.");
        }
    }

    private void ToggleVisibility()
    {
        if (parentObject == null)
        {
            Debug.LogError("Parent Object is not assigned.");
            return;
        }

        if (isShowingSpecific)
        {
            // Show all child objects
            foreach (Transform child in parentObject.transform)
            {
                child.gameObject.SetActive(true);
            }
            isShowingSpecific = false;
        }
        else
        {
            // Show only the target object
            foreach (Transform child in parentObject.transform)
            {
                if (child.name == targetObjectName)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
            isShowingSpecific = true;
        }
    }
}
