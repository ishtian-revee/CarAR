using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeColor : MonoBehaviour
{
    public MeshRenderer meshModel;  // car model mesh renderer

    /// <summary>
    /// this method triggers when a click event ocur on color buttons, thus change the color of the car model according to the button color
    /// </summary>
    public void OnClickColorChange()
    {
        // this will change the material color of the car model to the selected image button color
        meshModel.material.color = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
    }
}
