using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBallLaunchForce : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] bool canRenderLine;
    [SerializeField] float maxLineLength;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (canRenderLine) LineRendererTing();
    }

    void LineRendererTing()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, mousePosition);
        if ((Vector3.Distance(line.GetPosition(0), line.GetPosition(1))) > maxLineLength)
        {            
        }
    }

    public void CanLineRender()
    {
        canRenderLine = true;
        line.enabled = true;
    }

    public void CantLineRender()
    {
        canRenderLine = false;
        line.enabled = false;
    }

}
