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

    void Start() {

        turretToBuild = standardTurretPrefab;
    }

    private GameObject turretToBuild;
    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }
}
