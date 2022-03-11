using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    [SerializeField] GameObject[] portals;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            foreach (GameObject portal in portals)
            {
                portal.GetComponent<PortalController>().Activate();
            }
        }
    }
        

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] cams= GameObject.FindGameObjectsWithTag("portalCam");
            foreach (GameObject cam in cams)
            {
                //portal.GetComponent<PortalController>().Kill();
                Destroy(cam);
            }
        }
    }
}
