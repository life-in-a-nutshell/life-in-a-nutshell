using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    public Text Food_V;
    public Text Wood_V;
    public Text Science_V;
    public Text Population_V;

    public Text Farm_amt;
    public Text Lumber_amt;
    public Text Lab_amt;
    public Text House_amt;

    public Text Log;

    public Player p;
    public Player_Log LogScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UPPER PANEL VALUES
        //Food
        Food_V.GetComponent<Text>();
        Food_V.text = p.FoodResources.ToString();

        //Wood
        Wood_V.GetComponent<Text>();
        Wood_V.text = p.ProductionResources.ToString();

        //Science
        Science_V.GetComponent<Text>();
        Science_V.text = p.Science.ToString();

        //Population
        Population_V.GetComponent<Text>();
        Population_V.text = p.Pop.ToString() + " / " + p.MaxPop.ToString();

        //-------------------------------------------------------------------------------

        //BUILDING VALUES
        //Farm
        Farm_amt.GetComponent<Text>();
        Farm_amt.text = "Farm: " + p.farm.ToString();

        //Lumber
        Lumber_amt.GetComponent<Text>();
        Lumber_amt.text = "Lumber: " + p.lumberyard.ToString();

        //Lab
        Lab_amt.GetComponent<Text>();
        Lab_amt.text = "Lab: " + p.lab.ToString();

        //House
        House_amt.GetComponent<Text>();
        House_amt.text = "House: " + p.house.ToString();

        //------------------------------------------------------------------------------

        //Log
        Log.GetComponent<Text>();
    }

    //Build Lumber
    public void Chop()
    {
        p.lumberyard++;
        LogScript.AddEvent("Lumber has been built!");
    }

    //Build Housing
    public void Build()
    {
        p.house++;
        p.MaxPop += 10;
        LogScript.AddEvent("House has been built!");
    }

    //Build Farm
    public void Cultivate()
    {
        p.farm++;
        LogScript.AddEvent("Farm has been built!");
    }

    //Build Lab
    public void Research()
    {
        p.lab++;
        LogScript.AddEvent("Lab has been built!");
    }
}
