using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class PlaceOnRotate : MonoBehaviour
{
    private ARSessionOrigin sessionOrigin;
    private ARRaycastManager castManager;
    private List<ARRaycastHit> hits;

    public GameObject model;    // car model
    public GameObject canvas;   // canvas object

    // Start is called before the first frame update
    void Start()
    {
        // objet initalization
        sessionOrigin = GetComponent<ARSessionOrigin>();
        castManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();

        // initially model and canvas will not display in the screen
        model.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if user doesn't tap on the screen then no need to execute the rest of the code in this method
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);    // getting touch value

        // checking for touch ray casts and also checking if the touch is on ui buttons or not
        if(castManager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon) && !IsPointerOverUIObject(touch.position))
        {
            // taking the pose[position and rotation] value of the hit
            Pose pose = hits[0].pose;

            if (!model.activeInHierarchy)
            {
                // activating the model
                model.SetActive(true);
                // setting model pose to the hit pose
                model.transform.position = pose.position;
                model.transform.rotation = pose.rotation;
                // activating the canvas
                canvas.SetActive(true);
            }
            else
            {
                // if the model already exists in the hierarchy the set the model pose to the hit pose
                model.transform.position = pose.position;
            }
        }
    }

    /// <summary>
    /// this method checks if the touch hit position occuring on the ui button or slider or not
    /// </summary>
    /// <param name="pos">taking the touch position</param>
    /// <returns>true -> hit on the ui button or slider</returns>
    /// <returns>false -> doesn't hit on the ui button or slider, instead hit on the plane surface</returns>
    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null) return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
