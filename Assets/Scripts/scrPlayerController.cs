using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerController : MonoBehaviour
{
    private int numLandUnits;
    public int NumLandUnits
    {
        get { return numLandUnits; }
        set { this.numLandUnits = value; }
    }

    private int numAirUnits;
    public int NumAirUnits
    {
        get { return numAirUnits; }
        set { this.numAirUnits = value; }
    }

    private int numTurretUnits;
    public int NumTurretUnits
    {
        get { return numTurretUnits; }
        set { this.numTurretUnits = value; }
    }

    private GameObject[] landUnits
    {
        get; set;
    }
    private GameObject[] airUnits
    {
        get; set;
    }
    private GameObject[] turrets
    {
        get; set;
    }

    // Use this for initialization
    void Start()
    {
        //get units externally
        //temp values
        numLandUnits = 1;
        numAirUnits = 2;
        numLandUnits = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addLandUnit()
    {

    }

    public void addAirUnit()
    {

    }

    public void addTurret()
    {
    }
}
