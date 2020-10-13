using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int p_currentPopulation;

    [SerializeField]
    private int p_maxPopulation;
    
    [SerializeField]
    private int p_energy;

    [SerializeField]
    private int p_science;

    [SerializeField]
    private int p_production;

    [SerializeField]
    private int p_foodResources;

    [SerializeField]
    private int p_productionResources;

    public int Pop
    {
        get { return p_currentPopulation; }
        set { p_currentPopulation = value; }
    }
    public int MaxPop
    {
        get { return p_maxPopulation; }
        set { p_maxPopulation = value; }
    }

    public int Energy
    {
        get { return p_energy; }
        set { p_energy = value; }
    }
    public int Science
    {
        get { return p_science; }
        set { p_science = value; }
    }
    public int Production
    {
        get { return p_production; }
        set { p_production = value; }
    }
    public int FoodResources
    {
        get { return p_foodResources; }
        set { p_foodResources = value; }
    }
    public int ProductionResources
    {
        get { return p_productionResources; }
        set { p_productionResources = value; }
    }

    public int lumberyard;
    public int house;
    public int farm;
    // Start is called before the first frame update
    void Start()
    {
        p_foodResources = 1000;
        p_currentPopulation = 10;
        p_maxPopulation = 20;

        StartCoroutine(Refresh());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Update stats every 2sec
    IEnumerator Refresh()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);

            //Consume 2 food per person
            p_foodResources -= p_currentPopulation * 2;

            //Gather Wood based on number of lumberyards
            p_productionResources += lumberyard;

            //Gather Food based on number of farms
            p_foodResources += farm;

            //Population must not exceed max population
            if(p_currentPopulation <= p_maxPopulation)
            {
                p_currentPopulation++;
            }
            else
            {
                //Max population reached
            }

            Debug.Log(p_currentPopulation + " / " + p_maxPopulation);
            Debug.Log("Food : " + p_foodResources);
        }
    }

    //ASSIGN TO BUTTONS TO RUN
    //Get Wood
    public void Chop()
    {
        lumberyard++;
    }

    //Build Housing
    public void Build()
    {
        house++;
        p_maxPopulation += 10;
    }

    //Get Food
    public void Cultivate()
    {
        farm++;
    }
}
