using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodMeniu : MonoBehaviour {

    #region Variabile

    // Slider
    public Slider slider;

    #endregion

    #region Functii

    /// <summary>
    /// Ascunde Slideru
    /// </summary>
    void Start()
    {
        slider.gameObject.SetActive(false);
    }

    /// <summary>
    /// Porneste slideru
    /// </summary>
    public void StartGame()
    {
        slider.gameObject.SetActive(true);
        StartCoroutine(LoadScene());
    }

    /// <summary>
    /// Updataeaza slideru
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!operation.isDone)
        {
            slider.value = Mathf.Clamp01(operation.progress / .9f);

            yield return null;
        }

    }


    /// <summary>
    /// Iesirea din aplicatie
    /// </summary>
    public void quit()
    {
        Application.Quit();
    }

    #endregion
}
