using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int p_population;

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

    public int Health
    {
        get { return p_population; }
        set { p_population = value; }
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
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
