using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mLookAt;
    public string Camera_tag;
    private Transform localTrans;
    void Start()
    {
        localTrans = GetComponent<Transform>();
        mLookAt = GameObject.FindWithTag(Camera_tag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(mLookAt){
            localTrans.LookAt(2*localTrans.position-mLookAt.position);
        }
    }
}
