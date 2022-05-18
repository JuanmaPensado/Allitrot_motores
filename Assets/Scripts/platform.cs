using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class platform : MonoBehaviour
{
    private Renderer rend;
    private Color startColor1;
    private Color startColor2;
    public GameObject turret;
    public Color hoverColor;
    buildManager BuildManager;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor1 = rend.materials[1].color;
        startColor2 = rend.materials[2].color;

        BuildManager = buildManager.instance;
    }
    void OnMouseEnter (){
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!BuildManager.CanBuild) return;
        if (turret != null) return;
        if (BuildManager.HasMoney){
            rend.materials[1].color = hoverColor;
            rend.materials[2].color = hoverColor;
        }
        else{
            rend.materials[1].color = Color.red;
            rend.materials[2].color = Color.red;
        }
        

        
    }

    void OnMouseExit(){
        rend.materials[1].color = startColor1;
        rend.materials[2].color = startColor2;
    }

    void OnMouseDown(){
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!BuildManager.CanBuild) return;
        if (turret != null) return; //TODO

        BuildManager.BuildTurretOn(this);
    }
}
