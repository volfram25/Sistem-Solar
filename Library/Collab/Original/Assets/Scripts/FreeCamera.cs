using UnityEngine;
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

    public bool locked = false;
    public bool clicked = false;
    RaycastHit hit;

    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.03F;
    public float maxSpeed;

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
            //if (Input.GetAxis("Horizontal") != 0)
            //    transform.Translate(Input.GetAxis("Horizontal") * sensitivityX, 0, 0);
            //if (Input.GetAxis("Vertical") != 0)
            //    transform.Translate(0, 0, Input.GetAxis("Vertical") * sensitivityZ);
            Vector3 newPosition = new Vector3(sensitivityX * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, sensitivityZ * Input.GetAxis("Vertical") * Time.deltaTime);
            transform.Translate(Vector3.SmoothDamp(transform.position,newPosition,ref velocity,smoothTime));   

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
