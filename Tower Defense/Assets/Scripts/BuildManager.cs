using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
   
    [SerializeField] private Tower[] towers;
    private int selectedTower;
    private void Awake()
    {
        instance = this;
    }
    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
