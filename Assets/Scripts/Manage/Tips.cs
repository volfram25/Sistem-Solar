using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class Tips : MonoBehaviour {

    #region Variabile

    // Conexiunea la baza de date
    public IDbConnection con;
    // Text
    public Text infoText;

    #endregion

    #region Functii

    // Use this for initialization
    void Start()
    {
        con = new SqliteConnection("URI=file:" + Application.dataPath + "/Tips.s3db");
        con.Open();
    }

    /// <summary>
    /// Incarcare informatiilor
    /// </summary>
    /// <param name="text">Numele informatie care trebuie incarcata</param>
    public void onClicked(Text text)
    {
        int idCurrent = 0;
        switch (text.text)
        {
            case "Sun": idCurrent = 1; break;
            case "Kuiper Belt": idCurrent = 2; break;
            case "Oort Cloud": idCurrent = 3; break;
            case "Beyond Our Solar System": idCurrent = 4; break;
            case "Planets": idCurrent = 5; break;
            case "Comets": idCurrent = 6; break;
            case "Meteors & Meteorites": idCurrent = 7; break;
            case "Asteroids": idCurrent = 8; break;
        }

        IDbCommand com = con.CreateCommand();
        com.CommandText = "select Name, Info from Tips where id = " + idCurrent + "";

        IDataReader read = com.ExecuteReader();

        read.Read();

        infoText.text = read.GetString(0) + "\n\n" + read.GetString(1);
        GameObject.Find("InfoContent").GetComponent<RectTransform>().sizeDelta = new Vector2(0, infoText.preferredHeight + 50);
    } 

    #endregion

}
