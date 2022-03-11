using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PortalController : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public PortalController reciever;
    [SerializeField] GameObject cameraPrefab;
    private Camera cam;
    Guid id;

    private bool playerIsOverlapping = false;
    private void Start()
    {
        id = Guid.NewGuid();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct > 0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.transform.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff); // problem part for VR

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                positionOffset = new Vector3(-(positionOffset.x+0.1f*MathF.Sign(positionOffset.x)), positionOffset.y, positionOffset.z);
                player.position = reciever.transform.position + positionOffset;

                playerIsOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        if(other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    public void Activate()
    {
        reciever.AddViewRequest(id, this);
    }

    public void AddViewRequest(Guid id, PortalController portal)
    {
        cam = Instantiate(cameraPrefab, transform.position, player.transform.rotation).GetComponent<Camera>();
        cam.gameObject.GetComponent<CameraController>().playerCamera = playerCam;
        cam.gameObject.GetComponent<CameraController>().portal = this.gameObject.transform;
        cam.gameObject.GetComponent<CameraController>().otherPortal = portal.gameObject.transform;
        cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        portal.gameObject.GetComponent<Renderer>().material.mainTexture = cam.targetTexture;
    }
}
