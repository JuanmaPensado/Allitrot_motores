using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class platform : MonoBehaviour
{
    private Renderer rend;
    private Color startColor1;
    private Color startColor2;
    private GameObject turret;
    public Color hoverColor;
    public GameObject BuildEffect;
    buildManager BuildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor1 = rend.materials[1].color;
        startColor2 = rend.materials[2].color;

        BuildManager = buildManager.instance;
    }
    void OnMouseEnter (){
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (BuildManager.GetTurretToBuild() == null) return;
        if (turret != null) return;

        rend.materials[1].color = hoverColor;
        rend.materials[2].color = hoverColor;
    }

    void OnMouseExit(){
        rend.materials[1].color = startColor1;
        rend.materials[2].color = startColor2;
    }

    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (BuildManager.GetTurretToBuild() == null)return;
        if (turret != null) return;

        GameObject turretToBuild = BuildManager.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position , transform.rotation);
        
        GameObject effect = (GameObject) Instantiate(BuildEffect, transform.position, Quaternion.identity);
        Destroy(effect,2f);
    }
}
