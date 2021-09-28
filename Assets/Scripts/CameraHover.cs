using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHover : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Moon;
    public float RotationSpeed = 1;
    public float ScrollSpeed = 5;
    public float smoothTime = 0.2f;
    public Gravity gravity;

    private Transform target;
    private float rotationX;
    private float rotationY;
    private Vector3 curRotation;
    private float hoverDistance = 5f;

    private Vector3 smoothVelocity = Vector3.zero;
    
    private void Start()
    {
        HoverEarth();
        hoverDistance = 30;
        rotationY = 20;
        rotationX = -90;
    }
    
    public void HoverMoon()
    {
        target = Moon.transform;
        rotationX = 270;
    }
    
    public void HoverEarth()
    {
        target = Earth.transform;
    }
    
    private void LateUpdate()
    {
        float inputScroll = Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Time.deltaTime;

        hoverDistance = Mathf.Clamp(hoverDistance - (inputScroll * (Input.GetKey(KeyCode.LeftShift) ? 10 : 1)), 4, 500);
        
        float inputX = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;
        float inputY = Input.GetAxis("Vertical") * RotationSpeed * Time.deltaTime;

        rotationX += inputX;
        rotationY += inputY;

        float angle = 0;
        if (target.gameObject == Moon)
        {
            Vector3 dir = gravity.DirectionToEarth();
            dir.y = 0;
            dir.Normalize();
            if (dir.z >= 0)
            {
                angle = Mathf.Rad2Deg * Mathf.Acos(dir.x);
            }
            else if (dir.z < 0)
            {
                angle = 360 - (Mathf.Rad2Deg * Mathf.Acos(dir.x));
            }
        }
        Vector3 targetRotation = new Vector3(rotationY, -rotationX - angle);
        // Disabled the smoothing since it caused jitter when passing from 360 deg to 0
        curRotation = Vector3.SmoothDamp(curRotation, targetRotation, ref smoothVelocity, smoothTime);
        curRotation = targetRotation;

        transform.localEulerAngles = curRotation;

        transform.position = target.position - transform.forward * hoverDistance;

        //TODO 
        //Fix when angle goes from 360 to 0 so it doesn't snap weirdly like it does at hight timescales
        //add option to follow moon while hovering earth
    }
}
