using UnityEngine;
using UnityEngine.UI;

public class SplitObject : MonoBehaviour
{
    public GameObject parentObject; // The parent object containing child objects.
    public Button splitButton; // Reference to the UI Button.
    public float splitDistance = 1.5f; // Distance to move parts when splitting.

    private bool isSplit = false; // Track the current state.
    private Vector3[] originalPositions; // Store original positions of child objects.

    private void Start()
    {
        if (splitButton != null)
        {
            splitButton.onClick.AddListener(ToggleSplit);
        }
        else
        {
            Debug.LogError("Split Button is not assigned.");
        }

        if (parentObject != null)
        {
            int childCount = parentObject.transform.childCount;
            originalPositions = new Vector3[childCount];
            for (int i = 0; i < childCount; i++)
            {
                originalPositions[i] = parentObject.transform.GetChild(i).localPosition;
            }
        }
        else
        {
            Debug.LogError("Parent Object is not assigned.");
        }
    }

    private void ToggleSplit()
    {
        if (parentObject == null || originalPositions == null)
        {
            Debug.LogError("Parent Object or Original Positions are not set up correctly.");
            return;
        }

        if (isSplit)
        {
            // Revert to original positions
            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                parentObject.transform.GetChild(i).localPosition = originalPositions[i];
            }
            isSplit = false;
        }
        else
        {
            // Split the parts relative to parent center
            Vector3 parentCenter = parentObject.transform.position;
            for (int i = 0; i < parentObject.transform.childCount; i++)
            {
                Transform child = parentObject.transform.GetChild(i);
                Vector3 direction = (child.position - parentCenter).normalized;
                child.localPosition += direction * splitDistance;
            }
            isSplit = true;
        }
    }
}
