using UnityEngine;
using System.Collections;

public class InteractionControl : MonoBehaviour 
{
    public Color hoverColor;
    private Transform lastHitObject;
    private Color initialColor;
    void Update () 
    {
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, transform.forward, out hitInfo, 20f);
        if (hitInfo.transform != null)
        {
            
            Agent hitAgent = hitInfo.transform.GetComponent<Agent>();
            if (hitAgent != null)
            {
                if (lastHitObject != hitInfo.transform)
                {
                    if (lastHitObject != null)
                    {
                        lastHitObject.GetComponent<Renderer>().material.SetColor("_Color", initialColor);
                    }
                    lastHitObject = hitInfo.transform;
                    initialColor = lastHitObject.GetComponent<Renderer>().material.GetColor("_Color");
                    lastHitObject.GetComponent<Renderer>().material.SetColor("_Color", hoverColor);
                }
            }
            else
            {
                if (lastHitObject != null)
                {
                    lastHitObject.GetComponent<Renderer>().material.SetColor("_Color", initialColor);
                    lastHitObject = null;
                }
            }
        }
	}

}
