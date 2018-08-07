using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrUnitTilesUIControl : MonoBehaviour {

    public GameObject player;
    public GameObject typeBar; 

    private scrPlayerController playerStats;

	// Use this for initialization
	void Start () {
        playerStats = player.GetComponent<scrPlayerController>(); //getting 
    }

    // Update is called once per frame
    void Update() {
        int unitPanelIndex = typeBar.GetComponent<scrUIUnitTypeBar>().ImageIndex;

        switch (unitPanelIndex)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
        }
    }

    void drawLandUI()
    {

    }

    void drawAirUI()
    {

    }

    void drawTurrentUI()
    {

    }
}
