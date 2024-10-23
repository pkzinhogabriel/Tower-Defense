using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private GameObject tower;
    private Color startColor;
    // Start is called before the first frame update
  private void Start()
    {
        startColor = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor; 
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void OnMouseDown()
    {
        if (tower != null) return;
        
        GameObject towerToBuild = BuildManager.instance.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
