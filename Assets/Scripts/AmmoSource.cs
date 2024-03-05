using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSource : MonoBehaviour
{
    [SerializeField] private Camera CameraLink;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float inSkyDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        } else
        {
            targetPoint.position = ray.GetPoint(inSkyDistance);
        }
        transform.LookAt(targetPoint.position);
    }
}
