using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtiliti : MonoBehaviour {

    /// <summary>
    /// CLASA NEFOLOSITA
    /// </summary>

    #region Nimic

    public bool locked = false;
    public bool clicked = false;
    public RaycastHit hit;

    public void changeLocked()
    {
        locked = !locked;
        Cursor.visible = locked;
    }

    public void mouseClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            clicked = true;
        else
            clicked = false;
        Debug.Log(clicked);
    } 

    #endregion
}
