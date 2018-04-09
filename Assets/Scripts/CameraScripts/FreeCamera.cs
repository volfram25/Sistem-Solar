using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FreeCamera : MonoBehaviour {

    #region Variabile

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    /// <summary>
    ///Rotation Sensitivity 
    /// </summary>
    public float sensitivityXR = 15F;
    public float sensitivityYR = 15F;

    /// <summary>
    ///Movement Sensitivity 
    /// </summary>
    public float sensitivityX = 15F;
    public float sensitivityZ = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    public float smoothTime = 0.03F;
    public float maxSpeed;

    public bool locked = false;
    public bool pressLocked = false;

    public bool pressedF = false;

    public Animator anim;

    #endregion

    #region Functii Unity

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

        if(Input.GetKeyDown("v"))
        {
            pressLocked = !pressLocked;
            Cursor.visible = pressLocked;
        }

        if (pressLocked)
        {
            GameObject.Find("CameraStatus").GetComponent<Text>().text = "Camera is locked.";
            GameObject.Find("CameraStatus").GetComponent<Animator>().Play("FadeIn");
        }

        if (!pressLocked)
        {
            GameObject.Find("CameraStatus").GetComponent<Animator>().Play("FadeOut");
            GameObject.Find("CameraStatus").GetComponent<Text>().text = "";
        } 

        if (!locked && !pressLocked)
        {
            if(!pressedF)
                transform.Translate(sensitivityX * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, sensitivityZ * Input.GetAxis("Vertical") * Time.deltaTime);

            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityXR;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityYR;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityXR, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(Input.GetAxis("Mouse Y") * sensitivityXR, 0, 0);
            }
        }
    }

    #endregion

}
