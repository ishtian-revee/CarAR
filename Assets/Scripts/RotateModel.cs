using UnityEngine;
using UnityEngine.UI;

public class RotateModel : MonoBehaviour
{
    public GameObject model;    // care model
    public Slider slider;       // slider ui component
    
    /// <summary>
    /// this method triggers when the slider value changes and based on the slider value the car model rotates
    /// </summary>
    public void OnSlideRotate()
    {
        // this will rotate the car model according to the slider value
        model.transform.rotation = Quaternion.Euler(model.transform.rotation.x, slider.value, model.transform.rotation.z);
    }
}
