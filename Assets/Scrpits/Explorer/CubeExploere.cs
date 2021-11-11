using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploere : MonoBehaviour
{
    public GameObject ExplosionEffect;
    [SerializeField] float delay = 3f;

    [SerializeField] float explosionForce = 10f;
    [SerializeField] float radius = 10f;
    void Start()
    {
        Invoke("Explode", delay);
    }

    // Update is called once per frame
    public void Update()
    {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Destroy(collision.gameObject);
            Explode();
            gameObject.SetActive(false);

        }
    }
    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            if (rig != null)
            {
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }
        }
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        

    }
}
