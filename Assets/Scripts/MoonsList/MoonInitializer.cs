using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonInitializer : MonoBehaviour {

    #region Variablie

    // Textul care o sa apara in button
    public Text textName;
    // Informatia despre planeta
    public Text info;

    // Informatia despre luna
    public Moon moon;

    #endregion
    
    #region Functions

    // Use this for initialization
    void Start()
    {
        if (moon != null)
            Initializ(moon);
    }

    /// <summary>
    /// Seteaza numele si ...
    /// </summary>
    /// <param name="moonReceved">Luna primita</param>
    public void Initializ(Moon moonReceved)
    {
        moon = moonReceved;
        if (textName != null)
            textName.text = moonReceved.moonName;
        if (info != null)
            info.text = moonReceved.moonInfo;
    }

    /// <summary>
    /// Incarcare informatiei despre luna dorita
    /// </summary>
    public void onClicked()
    {
        string info = moon.moonInfo.Replace("—", ",");
        GameObject.Find("Infor").GetComponent<Text>().text = moon.moonName + "\n\n" + info;
        GameObject.Find("InfoContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, GameObject.Find("Infor").GetComponent<Text>().preferredHeight + 50);
    }

    #endregion
}
