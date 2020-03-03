using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject start, end;
    private GameObject wall;
    public GameObject wallFence;
    private static bool creating;
    public Camera camera;

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }
    private void getInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            setStart();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            setEnd();
        }
        else
        {
            if (creating)
            {
                adjust();
            }
        }
    }
    private void setStart()
    {
        creating = true;
        GameObject startPoint = Instantiate(start, getWorldPoint(), Quaternion.Euler(0,0,0));
        startPoint.active = true;

    }
    private void adjust()
    {

    }
    private void setEnd()
    {

        GameObject endPoint = Instantiate(end, getWorldPoint(), Quaternion.Euler(0, 0, 0));
        //end.transform.localScale = new Vector3(0.5f, 5, 0.5f);
        endPoint.active = true;
        //end.transform.position = getWorldPoint();
        creating = false;
    }
    public Vector3 getWorldPoint()
    { 
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }

    }
}
