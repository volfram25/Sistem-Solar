using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonDisplayer : MonoBehaviour {

    #region Variabals

    // Unde sa fie pus butonul
    public Transform target;
    // Butonul care o sa fie creat
    public GameObject buttonPrefab;

    #endregion

    #region Functiosn

    /// <summary>
    /// Creaza un buton nou pentru fiecare luna si o initializeaza
    /// </summary>
    /// <param name="moons">Lista de lunni care trebuie initializata</param>
    public void Initialize(List<Moon> moons)
    {
        foreach (Moon moon in moons)
        {
            GameObject display = (GameObject)Instantiate(Resources.Load("MoonButton"));
            display.transform.SetParent(target.transform, false);
            MoonInitializer init = display.GetComponent<MoonInitializer>();
            init.Initializ(moon);
        }
    }

    #endregion
}
