using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColliderEnter : MonoBehaviour
{

    #region Variabile

    // Planeta de care sa lovit camera
    public Transform planet;
    // Sfera unde se pune numele
    public Transform placeHolder;

    // Label-u cu nuemel
    public Text nameLabel;
    // Texul in care se pun datele despre planeta
    public Text basicInfo;
    // Panoul in care e textul cu date
    public RectTransform informationPanel;
    // Butonul de Play/Pause
    public Button button;
    // Scriptu de la play/pause
    UitilityButtons script;
    // Scriptu de la info load
    SceneLoader infoLoader;
    // Scriptul de la camera
    public FreeCamera mainCamera;

    //Animatioa panoului de informatii
    public Animator animPanel;
    //Animatioa numelui 
    public Animator animName;
    // Animatia statusului cameri
    public Animator animStatus;

    // Daca sa arate numele sau nu
    public bool dispaly = false;
    // Daca panou ii deschis
    public bool pressedE = false;

    #endregion

    #region Unity functions

    /// <summary>
    /// Gaseste Text Nume si il seteaza cu nimic
    /// </summary>
    void Start()
    {
        informationPanel = GameObject.Find("InformationPanel").GetComponent<RectTransform>();

        nameLabel = GameObject.Find("Name").GetComponent<Text>();

        button = GameObject.Find("PlayPause").GetComponent<Button>();
        script = GameObject.Find("UtilityButtons").GetComponent<UitilityButtons>();

        basicInfo = GameObject.Find("BasicInfo").GetComponent<Text>();

        infoLoader = GameObject.Find("SceneInfoLoader").GetComponent<SceneLoader>();

        mainCamera = transform.GetComponent<FreeCamera>();
    }

    /// <summary>
    /// Gaseste placeHolder-u si seteaza textul
    /// </summary>
    /// <param name="colliderInfo">Obiectul de care se loveste camera</param>
    void OnTriggerEnter(Collider colliderInfo)
    {
        planet = colliderInfo.GetComponent<Transform>();
        placeHolder = planet.transform.GetChild((planet.transform.childCount - 1));
        nameLabel.text = colliderInfo.gameObject.name + " - Press E or F";
        animName.Play("FadeIn");
        if(script.orbiting)
            button.onClick.Invoke();
        loadData(colliderInfo);
        dispaly = true;
    }

    /// <summary>
    /// Seteaza textul cu nimic
    /// </summary>
    void OnTriggerExit()
    {
        dispaly = false;
        animName.Play("FadeOut");
        if (pressedE)
            animPanel.Play("Close");
        if(!script.orbiting)
            button.onClick.Invoke();
    }

    /// <summary>
    /// Seteaza pozitia numelui
    /// </summary>
    void Update()
    {
        if (dispaly)
        {
            nameLabel.transform.position = Camera.main.WorldToScreenPoint(placeHolder.position);
            if (Input.GetKeyDown("e") && !mainCamera.pressedF)
            {
                mainCamera.locked = !mainCamera.locked;

                if (!pressedE)
                {
                    animPanel.Play("Open");
                    pressedE = true;
                }
                else
                {
                    animPanel.Play("Close");
                    pressedE = false;
                }

                infoLoader.planetHit = planet.transform.name;
                infoLoader.pressed = true;
                transform.LookAt(planet.position + (transform.right * planet.transform.localScale.x/2f));
            }
            if (Input.GetKeyDown("f") && !pressedE)
            {
                mainCamera.pressedF = !mainCamera.pressedF;
                transform.LookAt(planet.position + (transform.right * planet.transform.localScale.x / 2f));
                if (!script.orbiting)
                    button.onClick.Invoke();
            }
        }

        if (mainCamera.locked && pressedE)
            transform.RotateAround(planet.transform.position, new Vector3(0f, 1.0f, 0f), 20 * Time.deltaTime);

        if(mainCamera.pressedF)
            mainCamera.transform.position = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z + planet.transform.localScale.z + planet.transform.localScale.z / 2);

        if (mainCamera.pressedF)
        {
            GameObject.Find("CameraStatus2").GetComponent<Text>().text = "Camera is following " + planet.name + ".";
            GameObject.Find("CameraStatus2").GetComponent<Animator>().Play("FadeIn");
        }

        if (!mainCamera.pressedF)
        {
            GameObject.Find("CameraStatus2").GetComponent<Animator>().Play("FadeOut");
            GameObject.Find("CameraStatus2").GetComponent<Text>().text = "";
        }

    }

    #endregion

    #region Functii

    /// <summary>
    /// Incarca toate datele despre planeta in Inforamtion
    /// </summary>
    /// <param name="colliderInfo">Planeta de care sa lovit camera</param>
    void loadData(Collider colliderInfo)
    {
        ObjectSpace planet = colliderInfo.GetComponent<ObjectSpace>();
        Text txt =  GameObject.Find("NameOfPlanet").GetComponent<Text>();
        txt.text = colliderInfo.name;
        string grav;
        if (planet.gravity == -1)
            grav = "-";
        else
            grav = planet.gravity.ToString();
        basicInfo.text =  "Mass (10^24 kg): " + planet.mass + "\n" + "Diametre (km): " + planet.diameter + "\n" + "Gravity (m/s^2): " + grav + "\n" + "Rotation Period (hours): " + planet.rotationPeriod + "\n" + "Distance from sun (10^6 km): " + planet.distanceSun + "\n" + "Orbit Period (days): " + planet.orbitPeriod + "\n" + "Temperature (C): " + planet.temperature + "\n" + "Surface Pressure (bar): " + planet.pressure;
    } 

    #endregion

}
