using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuiteMenu : MonoBehaviour {

    #region Variabile

    // Daca butonu de ESC a fost apasat
    public bool pressed = false; 

    #endregion

    #region Functii

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pressed)
                this.GetComponent<Animator>().Play("FadeIn");
            if (pressed)
                this.GetComponent<Animator>().Play("FadeOut");
            pressed = !pressed;
            Cursor.visible = !Cursor.visible;
        }

    }

    /// <summary>
    /// Inchidera aplicatiei
    /// </summary>
    public void onClickExit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Introacerea la meniu
    /// </summary>
    public void onClickMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    #endregion

}
