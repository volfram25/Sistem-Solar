using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UitilityButtons : MonoBehaviour {

    #region Variabile

    //Vector care are toate obiectele cu scriptul ObjectSpace
    public ObjectSpace[] planets;

    //Daca planeta trebuie sa orbiteze sau nu
    public bool orbiting = true;

    //Viteza de 10 ori mai mare
    public bool multiTen = false;

    //viteza de 100 de ori mai mare
    public bool multiTenTen = false;

    //Animatia panoului cu butoane
    public Animator animButtons;

    //Animatia Butonului de afisare
    public Animator animShow;

    //Animatia butoanele utility
    public Animator animUtiliti;

    //Butoanele 
    Button playPause;
    Button multyTen;
    Button multyTenTen;

    #endregion

    #region Unity Functions

    /// <summary>
    /// Start 
    /// </summary>
    void Awake()
    {
        planets = Object.FindObjectsOfType<ObjectSpace>();
        playPause = GameObject.Find("PlayPause").GetComponent<Button>();
        multyTen = GameObject.Find("Multi10").GetComponent<Button>();
        multyTenTen = GameObject.Find("Multi100").GetComponent<Button>();
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        if (!FindObjectOfType<FreeCamera>().locked)
        {
            if (Input.GetKeyDown("p"))
                Pause_Play();
            if (Input.GetKeyDown("["))
                Multiply_Ten();
            if (Input.GetKeyDown("]"))
                Multiply_TenTen();
        }
    }

    #endregion

    #region Functii ale butoanelor

    /// <summary>
    /// Opreste/Porneste planetele din orbita lor
    /// </summary>
    public void Pause_Play()
    {
        playPause.GetComponent<AnimationManageForButtons>().activateAnimation();
        if (!orbiting)
            GameObject.Find("PlayPause").GetComponentInChildren<Text>().text = "||";
        if (orbiting)
            GameObject.Find("PlayPause").GetComponentInChildren<Text>().text = ">";

        orbiting = !orbiting;
        foreach (ObjectSpace obj in planets)
            obj.isOrbitting = orbiting;
        
    }

    /// <summary>
    /// Marsete viteza de orbitare de 10 ori decat cea normala
    /// </summary>
    public void Multiply_Ten()
    {
        if (!multiTenTen)
        {
            multyTen.GetComponent<AnimationManageForButtons>().activateAnimation();
            foreach (ObjectSpace obj in planets)
            {
                if (!multiTen)
                    obj.currentSpeed *= 10;
                else
                    obj.currentSpeed = obj.speed;
            }
            multiTen = !multiTen;
        }
    }

    /// <summary>
    /// Marezte viteza de orbitare de 100 de ori decat cea normala
    /// </summary>
    public void Multiply_TenTen()
    {
        if (!multiTen)
        {
            multyTenTen.GetComponent<AnimationManageForButtons>().activateAnimation();
            foreach (ObjectSpace obj in planets)
            {
                if (!multiTenTen)
                    obj.currentSpeed *= 100;
                else
                    obj.currentSpeed = obj.speed;
            }
            multiTenTen = !multiTenTen;
        }
    } 

    /// <summary>
    /// Arata meniu cu planete
    /// </summary>
    public void ShowPlanets()
    {
        animShow.Play("Close");
        animButtons.Play("Open");
    }

    #endregion

}
