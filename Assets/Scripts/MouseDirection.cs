using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDirection : MonoBehaviour
{

   [SerializeField] float zOffset;
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen coordinates to world coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));

        // Calculate the direction from the character to the mouse position
        Vector3 lookDirection = mouseWorldPosition - transform.position;
        lookDirection.Normalize(); // Ensure the direction is normalized

        // Calculate the angle in degrees between the character's forward vector and the look direction
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + zOffset;

        // Rotate the character to face the mouse position around the Z-axis
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}

