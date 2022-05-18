using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{

    public turretblueprint standard_turret;
    public turretblueprint misile_turret;
    buildManager buildmanager;

    void Start (){
        buildmanager = buildManager.instance;
    }

    public void SelectStandardTurret(){
        //Debug.Log("standard Turret selected");
        buildmanager.SelectTurretToBuild(standard_turret);
    }

    public void SelectMisilTurret(){
        //Debug.Log("misile Turret selected");
        buildmanager.SelectTurretToBuild(misile_turret);
    }
}
