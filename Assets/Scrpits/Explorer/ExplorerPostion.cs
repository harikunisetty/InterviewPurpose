using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerPostion : MonoBehaviour
{
    [SerializeField] Transform grenadePostion;
    [SerializeField] GameObject CubeExplorer;

    public float speed = 30;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CubeAttack();
        }
    }
    // Update is called once per frame
    public void CubeAttack()
    {
        GameObject GrenadeInstance = Instantiate(CubeExplorer, grenadePostion.position, grenadePostion.rotation);
        GrenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePostion.forward * speed, ForceMode.Impulse);

    }
}
