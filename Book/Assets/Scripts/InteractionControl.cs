using UnityEngine;
using System.Collections;

public class InteractionControl : MonoBehaviour 
{
    public Color hoverColor;
    private Transform lastHitObject;
    private Color initialColor;
    private Agent hitAgent;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () 
    {
        RaycastHit hitInfo;
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Physics.Raycast(ray, out hitInfo, 30f);
      
        if (hitInfo.transform != null)
        {
            
            hitAgent = hitInfo.transform.GetComponent<Agent>();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (HUDManager.Instance.IsShowingUI)
            {
                HUDManager.Instance.HideAllPanels();
            }
            else
            {
                HUDManager.Instance.ShowMenu();
            }
        }
	}

    void FixedUpdate()
    {
        if (hitAgent != null)
        {
            if (Input.GetMouseButtonUp(0) && !HUDManager.Instance.IsShowingUI && !(hitAgent.CurrentState is Dead))
            {
                HUDManager.Instance.ShowActionMenu(hitAgent);
            }
        }
    }

}
