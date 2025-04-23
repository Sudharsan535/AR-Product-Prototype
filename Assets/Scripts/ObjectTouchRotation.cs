using UnityEngine;

public class ObjectTouchRotation : MonoBehaviour
{
    public float rotationSpeed = 0.2f; // Speed of rotation

    private Touch touch;
    private Vector2 touchDelta;
    private Quaternion rotationY;
    private Quaternion rotationX;

    void Update()
    {
        // Check if the user is touching the screen
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // Check if the touch is moving
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the rotation based on touch movement
                touchDelta = touch.deltaPosition;

                // Rotate the object around its X and Y axes
                rotationY = Quaternion.Euler(0, -touchDelta.x * rotationSpeed, 0); // Horizontal rotation
                rotationX = Quaternion.Euler(touchDelta.y * rotationSpeed, 0, 0);  // Vertical rotation

                // Apply the rotation to the object
                transform.rotation = rotationY * rotationX * transform.rotation;
            }
        }
    }
}
