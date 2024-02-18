using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float minAngle; 
    [SerializeField] private float maxAngle;
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + (rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X")), 0);

        var _newAngleX = CameraTransform.localEulerAngles.x - (rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y"));
        if (_newAngleX > 180)
            _newAngleX -= 360;
        
        _newAngleX = Mathf.Clamp(_newAngleX, minAngle, maxAngle);
        CameraTransform.localEulerAngles = new Vector3(_newAngleX,0, 0);
    }
}
