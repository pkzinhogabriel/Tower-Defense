using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [SerializeField] private GameObject[] towerPrefabs;
    private int selectedTower;
    private void Awake()
    {
        instance = this;
    }
    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
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
