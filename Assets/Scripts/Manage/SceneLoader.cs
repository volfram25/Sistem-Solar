using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour {

    #region Variabals

    public static SceneLoader Instance;
    public string planetHit;
    public bool pressed = false;

    #endregion

    #region Functions

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Verifica daca sa apasat tasta m
    /// </summary>
    void Update()
    {
        if (pressed && Input.GetKeyDown("m"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    #endregion

}
