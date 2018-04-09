using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManageForButtons : MonoBehaviour {

    #region Variabals

    public bool pressed = false;
    public Animator anim;

    #endregion

    #region Functions

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    /// <summary>
    /// Verifica daca butonul ii apasat si porneste animatia potrivita
    /// </summary>
    public void activateAnimation()
    {
        if (!pressed)
            anim.GetComponent<Animator>().Play("Activate");
        if (pressed)
            anim.GetComponent<Animator>().Play("Deactivate");
        pressed = !pressed;
    } 

    #endregion

}
