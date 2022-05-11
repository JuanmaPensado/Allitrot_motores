using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public GameObject hitPart;

    public void spawn (Transform _Target){
        target = _Target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget(){
        GameObject effectinst = (GameObject) Instantiate(hitPart,transform.position , transform.rotation);
        Destroy(effectinst, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
