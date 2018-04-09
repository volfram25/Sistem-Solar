using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class LoadInfo : MonoBehaviour {

    #region Variabile

    // Planeta la care trebe sa incarce informatia
    public string planet;

    //Infotrmatia despre planeta
    public string infoPlanet;

    #endregion

    #region Functions

    /// <summary>
    /// Apeleaza functia de incarcare
    /// </summary>
    void Awake()
    {
        Cursor.visible = true;
        planet = GameObject.Find("SceneInfoLoader").GetComponent<SceneLoader>().planetHit;
        loadInfo();
    }

    /// <summary>
    /// Incarca informatia despre planeta in contentu scroll view-rului
    /// </summary>
    public void loadInfo()
    {
        IDbConnection con = new SqliteConnection("URI=file:" + Application.dataPath + "/PlanetsInfo.s3db");
        con.Open();

        int idCurrent = 0;
        switch (planet)
        {
            case "Mercury": idCurrent = 1; break;
            case "Venus": idCurrent = 2; break;
            case "Earth": idCurrent = 3; break;
            case "Mars": idCurrent = 4; break;
            case "Jupiter": idCurrent = 5; break;
            case "Saturn": idCurrent = 6; break;
            case "Uranus": idCurrent = 7; break;
            case "Neptune": idCurrent = 8; break;
            case "Pluto": idCurrent = 9; break;
            case "Ceres": idCurrent = 10; break;
            case "Makemake": idCurrent = 11; break;
            case "Haumea": idCurrent = 12; break;
            case "Eris": idCurrent = 13; break;
        }

        IDbCommand com = con.CreateCommand();
        com.CommandText = "select Info from SpaceObjects where id = " + idCurrent + " ";

        IDataReader read = com.ExecuteReader();

        read.Read();

        Text text = GameObject.Find("Name").GetComponent<Text>();
        text.text = planet;
        float nameH = text.preferredHeight;

        text = GameObject.Find("Infor").GetComponent<Text>();
        infoPlanet = read.GetString(0);
        text.text = infoPlanet;
        float infoH = text.preferredHeight;

        GameObject.Find("InfoContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 50 + infoH);
    }

    /// <summary>
    /// Dezactiveaza scena curenta
    /// </summary>
    public void unload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    } 

    /// <summary>
    /// Pune informatia despre planeta in text
    /// </summary>
    public void onCliked()
    {
        Text text = GameObject.Find("Infor").GetComponent<Text>();
        //GameObject.Find("InfoScrollView").GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        text.text = infoPlanet;
        GameObject.Find("InfoContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 50 + text.preferredHeight);

    }

    #endregion

}
