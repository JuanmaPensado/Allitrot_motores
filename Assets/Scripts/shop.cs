using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    buildManager buildmanager;

    void Start (){
        buildmanager = buildManager.instance;
    }

    public void PurchaseStandardTurret(){
        Debug.Log("standard Turret purchased");
        buildmanager.SetTurretToBuild(buildmanager.standardTurretPrefab);
    }

    public void PurchaseMisilTurret(){
        Debug.Log("misile Turret purchased");
        buildmanager.SetTurretToBuild(buildmanager.MisileTurretPrefab);
    }
}
