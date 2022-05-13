using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float expradious = 0f;
    public int damage = 20;

    public GameObject hitPart;
    public GameObject hitPart2;

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
        transform.LookAt(target);

    }

    void HitTarget(){
        if (expradious > 0f){
            Explode();
        }
        else
        {
            Damage(target.transform);
        }

        GameObject effectinst = (GameObject) Instantiate(hitPart,target.position,transform.rotation);
        Destroy(effectinst, 2f);

        Destroy(gameObject);
    }

    void Damage(Transform enemy){
        
        Enemigo e = enemy.GetComponent<Enemigo>();
        e.TakeDamage(damage);
    
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, expradious);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                GameObject effectinst = (GameObject) Instantiate(hitPart2,collider.transform.position,transform.rotation);
                Destroy(effectinst, 2f);
                
                Damage(collider.transform);
            }
        }
    }

    void OnDrawGizmos(){
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position,expradious);
    }
}
