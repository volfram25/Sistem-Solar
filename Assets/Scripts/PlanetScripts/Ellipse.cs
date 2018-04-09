using UnityEngine;

public class Ellipse {

    /// <summary>
    /// CLASA NEFOLOSITA
    /// </summary>

    #region Variabile

    //Latimea si inaltimea elipsei
    public float xAxis;
    public float yAxis;

    #endregion

    #region Functii

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="xAxis">Inaltimea</param>
    /// <param name="yAxis">Latime</param>
    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    /// <summary>
    /// Claculeaza punctul in spatiu in functie de unghi
    /// </summary>
    /// <param name="angel">Unghiu</param>
    /// <returns></returns>
    public Vector2 calculatePoint(float angel)
    {
        float currentAngel = angel * Mathf.Deg2Rad * 360;
        float x = Mathf.Sin(currentAngel) * xAxis;
        float y = Mathf.Cos(currentAngel) * yAxis;
        return new Vector2(x, y);
    } 

    #endregion

}
