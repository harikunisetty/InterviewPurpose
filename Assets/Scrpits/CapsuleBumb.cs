using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBumb : MonoBehaviour
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
        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
