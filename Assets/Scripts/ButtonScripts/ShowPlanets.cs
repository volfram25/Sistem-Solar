using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlanets : MonoBehaviour {

    #region Variabals

    //Butonu de play/pause
    Button playPause;

    //Scriput de la play/pause
    UitilityButtons utilButtons;

    //Script de la camera
    FreeCamera freeCamera;

    //Animatia panoului
    public Animator animButtons;

    //Animatia Butonului de afisare
    public Animator animShow;

    #endregion

    #region Functions

    /// <summary>
    /// Rulare inainte de start
    /// </summary>
    void Awake()
    {
        playPause = GameObject.Find("Buttons/UtilityButtons/PlayPause").GetComponent<Button>();
        utilButtons = GameObject.Find("Buttons/UtilityButtons").GetComponent<UitilityButtons>();
        freeCamera = GameObject.Find("/Main Camera").GetComponent<FreeCamera>();
    }

    /// <summary>
    /// Inchide panou cu butoanele planetelor
    /// </summary>
    public void Close()
    {
        animButtons.Play("Close");

        animShow.Play("Open");
    }

    /// <summary>
    /// Functia care se apeleaza la apasarea butonului din panou de butoane al planetelor
    /// </summary>
    /// <param name="obj">Butonul pe care s-a apasat</param>
    public void OnButtonClicked(Button obj)
    {
        ShowPlanetsInWorld(obj.GetComponentInChildren<Text>().text);
    }

    /// <summary>
    /// Mutarea camerei la planeta dorita
    /// </summary>
    /// <param name="obj">Planeta care trebuie aratata</param>
    void ShowPlanetsInWorld(string name)
    {
        if (!freeCamera.locked)
        {
            GameObject planet = GameObject.Find("/" + name);
            if (utilButtons.orbiting)
                playPause.onClick.Invoke();
            Camera.main.transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z + planet.transform.localScale.z + planet.transform.localScale.z / 2);
            Camera.main.transform.LookAt(planet.transform.position + (transform.right * planet.transform.localScale.x / 2f));
            freeCamera.pressLocked = false;
            Cursor.visible = false;
            Close();
        }
    } 

    #endregion

}
