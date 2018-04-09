using UnityEngine;
using System.Collections;

public class FreeCamera : MonoBehaviour {

    #region Variabile

    /// <summary>
    /// Coordonatele
    /// </summary>
    public float xSpeed = 1, zSpeed = 1;
    public float up = 0.0f;
    public float down = 0.0f;

    public float rotation_speed;
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
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;

    public bool locked = false;
    public bool clicked = false;
    RaycastHit hit;

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
    void FixedUpdate()
    {
        if (Input.GetKeyDown("v"))
        {
            locked = !locked;
            Cursor.visible = locked;
        }
        if (locked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                clicked = !clicked;
                Debug.Log(clicked);
                if (clicked)
                    Physics.Raycast(ray, out hit);
            }
        }
        if (clicked)
            transform.RotateAround(new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), new Vector3(0, hit.transform.position.y, 0), 1);
        if (!locked && !clicked)
        {
            if (Input.GetAxis("Horizontal") != 0)
                transform.Translate(-Input.GetAxis("Horizontal") * xSpeed, 0, 0);
            if (Input.GetAxis("Vertical") != 0)
                transform.Translate(0, 0, -Input.GetAxis("Vertical") * zSpeed);
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityXR;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityYR;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.eulerAngles = new Vector3(rotationY, rotationX, 0);
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
