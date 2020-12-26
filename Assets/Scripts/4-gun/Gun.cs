using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    public Camera cam;
    public ParticleSystem flash;
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        flash.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            GunTarget target = hit.transform.GetComponent<GunTarget>();
            if(target != null)
            {
                target.takeDamage(damage);
            }
            
            GameObject g = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(g, 2f);
        }
        
    }
}
