using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpace : OrbitMotion {

    #region Variabile

    // Datele despre planete
    public float mass;
    public float diameter;
    public float density;
    public float gravity;
    public float rotationPeriod;
    public float distanceSun;
    public float temperature;
    public string pressure; 

    #endregion

    #region Functii Unity

    /// <summary>
    /// Preia datale din baza de date si le aplica obiectului
    /// </summary>
    void Awake()
    {
        string path = "URI=file:" + Application.dataPath + "/MilkyWay.s3db";
        IDbConnection con = new SqliteConnection(path);
        con.Open();

        int idCurrent = 0;
        switch (currentObject.name.ToString())
        {
            case "Mercury": idCurrent = 1; break;
            case "Venus": idCurrent = 2; break;
            case "Earth": idCurrent = 3; break;
            case "Moon": idCurrent = 4; break;
            case "Mars": idCurrent = 5; break;
            case "Jupiter": idCurrent = 6; break;
            case "Saturn": idCurrent = 7; break;
            case "Uranus": idCurrent = 8; break;
            case "Neptune": idCurrent = 9; break;
            case "Pluto": idCurrent = 10; break;
            case "Ceres": idCurrent = 11; break;
            case "Makemake": idCurrent = 12; break;
            case "Haumea": idCurrent = 13; break;
            case "Eris": idCurrent = 14; break;
        }

        string comString = "Select * from Planets where id = " + idCurrent + "";
        IDbCommand com = con.CreateCommand();
        com.CommandText = comString;
        IDataReader read = com.ExecuteReader();

        read.Read();

        mass = read.GetFloat(2);
        diameter = read.GetFloat(3);
        density = read.GetFloat(4);
        gravity = read.GetFloat(5);
        rotationPeriod = read.GetFloat(7);
        distanceSun = read.GetFloat(9);
        temperature = read.GetFloat(17);
        if (read.GetFloat(18) == 5)
            pressure = "Unknown";
        else
            pressure = read.GetFloat(18).ToString();

        xAxis = read.GetFloat(10);
        yAxis = read.GetFloat(11);
        zAxis = read.GetFloat(9);

        angleX = read.GetFloat(14)*100;

        orbitPeriod = read.GetFloat(12);
        StartCalc();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        UpdateFrame();
    } 

    #endregion

}
