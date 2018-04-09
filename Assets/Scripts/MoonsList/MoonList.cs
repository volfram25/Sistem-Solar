using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class MoonList : MonoBehaviour {

    #region Variabals

    // Lista cu luni
    public List<Moon> moons = new List<Moon>();
    // Aratarea lunii
    public MoonDisplayer displayer; 

    #endregion

    #region Functions

    // Use this for initialization
    void Start () {
        displayer = GameObject.Find("Moons").GetComponent<MoonDisplayer>();
        Load(GameObject.Find("SceneInfoLoader").GetComponent<SceneLoader>().planetHit);
        displayer.Initialize(moons);
	}

    /// <summary>
    /// Incarca lunile planetei alese
    /// </summary>
    /// <param name="planet"></param>
    public void Load(string planet)
    {
        IDbConnection con = new SqliteConnection("URI=file:" + Application.dataPath + "/Moons.s3db");
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
        com.CommandText = "select MoonName, Info from Moons where PlanetId = " + idCurrent + "";

        IDataReader read = com.ExecuteReader();

        while (read.Read())
        {
            GameObject ob = (GameObject)Instantiate(Resources.Load("Moon"));
            Moon moon = ob.GetComponent<Moon>();
            moon.moonName = read.GetString(0);
            moon.moonInfo = read.GetString(1);
            moons.Add(moon);
        }

        if (moons.Count > 0)
        {
            GameObject.Find("MoonContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, moons.Count * 30 + moons.Count * 5);
        }
        else
        {
            GameObject ob = (GameObject)Instantiate(Resources.Load("Warning"));
            ob.transform.SetParent(GameObject.Find("MoonContent").GetComponent<RectTransform>(), false);
            ob.GetComponent<Text>().text = "Planet has no moons";
            GameObject.Find("MoonContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 30);
        }

    } 

    #endregion

}
