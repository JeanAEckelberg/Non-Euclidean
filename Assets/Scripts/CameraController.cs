using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Start is called before the first frame update
    void Start()
    {
        // this.GetComponent<Camera>().targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        // otherPortal.gameObject.GetComponent<Material>().mainTexture = this.GetComponent<Camera>().targetTexture;
        //offset = mainCam.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + new Vector3(-playerOffsetFromPortal.x, playerOffsetFromPortal.y,-playerOffsetFromPortal.z);

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        angularDifferenceBetweenPortalRotations += 180;

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up); 

        //transform.position = mainCam.transform.position - offset;
        //transform.rotation = mainCam.transform.rotation;
    }
}
