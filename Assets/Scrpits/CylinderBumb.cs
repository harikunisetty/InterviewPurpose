using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBumb : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;

    private void OnEnable()
    {
        Invoke("Die", lifetime);
    }
    void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cylinder"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
