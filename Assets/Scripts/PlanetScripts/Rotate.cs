using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    #region Variables

    //Punctu in jurul caruie orbiteaza
    public GameObject point;

    //Viteza
    public float speed = 3f;

    //Timpu in cat orbiteaza
    public float period;

    #endregion

    #region Unity Functions

    /// <summary>
    /// Cand se porneste
    /// </summary>
    void Start()
    {
        period = point.GetComponent<ObjectSpace>().rotationPeriod;
        speed = 1f / point.GetComponent<ObjectSpace>().rotationPeriod;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    } 

    #endregion

}
