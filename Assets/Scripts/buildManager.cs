using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildManager : MonoBehaviour
{

    public static buildManager instance;
    void Awake(){
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in Scene!");
            return;
        }
        instance = this;
    }


    public GameObject standardTurretPrefab;
    public GameObject MisileTurretPrefab;
    private turretblueprint turretToBuild;
    public GameObject BuildEffect;
    public bool CanBuild { get {return turretToBuild != null;}}
    public bool HasMoney { get {return playerStats.Currency >= turretToBuild.cost;}}

    public void BuildTurretOn (platform ptfm){
        if (playerStats.Currency < turretToBuild.cost){
            //Debug.Log("no hay dineros");
            return;
        }

        playerStats.Currency -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, ptfm.transform.position, ptfm.transform.rotation);
        ptfm.turret = turret;

        GameObject effect = (GameObject) Instantiate(BuildEffect, ptfm.transform.position, Quaternion.identity);
        Destroy(effect,2f);
        //Debug.Log("Turret Build Currency: "+ playerStats.Currency);
    }


    public void SelectTurretToBuild(turretblueprint turret){
        turretToBuild = turret;
    }
}
