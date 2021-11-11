using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public enum BumbsExplorer 
    { 
       cube,Sphere, Cylinder, Capsule
    }

    [SerializeField] BumbsExplorer explorer;

    [Header("Movement")]

    [SerializeField] float moveSpeed;
    [SerializeField] CharacterController controller;
    private Vector3 targetDirection;

    [Header("Attack")]

    [SerializeField] Transform grenadePostion;
    [SerializeField] GameObject CubeBumb;
    [SerializeField] GameObject sphereBumb;
    [SerializeField] GameObject CylinderBumb;
    [SerializeField] GameObject CapsuleBumb;
    public float speed=10f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

        targetDirection = new Vector3(horizontal, 0f, vertical);

        if (targetDirection.magnitude >= 0.1f)
        {
            controller.Move(targetDirection * moveSpeed * Time.deltaTime);
        }
    }

    public void FixedUpdate()
    {
        /*
          switch (explorer)
          {
              case BumbsExplorer.cube:

                  if (Input.GetKeyDown(KeyCode.Q))
                  {
                      CubeAttack();
                  }
                  break;
              case BumbsExplorer.Sphere:
                  if (Input.GetKeyDown(KeyCode.X))
                  {
                      SphereAttack();
                  }
                  break;
              case BumbsExplorer.Cylinder:
                  if (Input.GetKeyDown(KeyCode.C))
                  {
                      CylinderAttack();
                  }
                  break;
              case BumbsExplorer.Capsule:
                  if (Input.GetKeyDown(KeyCode.V))
                  {
                     CapsuleAttack();
                  }
                  break;
              default:
                  break;
          }*/

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CubeAttack();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SphereAttack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CylinderAttack();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            CapsuleAttack();
        }
    }
    public void CubeAttack()
    {
        GameObject GrenadeInstance = Instantiate(CubeBumb, grenadePostion.position, grenadePostion.rotation);
        GrenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePostion.forward * speed, ForceMode.Impulse);

    }
    public void SphereAttack()
    {
        GameObject GrenadeInstance = Instantiate(sphereBumb, grenadePostion.position, grenadePostion.rotation);
        GrenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePostion.forward * speed, ForceMode.Impulse);

    }
    public void CylinderAttack()
    {
        GameObject GrenadeInstance = Instantiate(CylinderBumb, grenadePostion.position, grenadePostion.rotation);
        GrenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePostion.forward * speed, ForceMode.Impulse);

    }
    public void CapsuleAttack()
    {
        GameObject GrenadeInstance = Instantiate(CapsuleBumb, grenadePostion.position, grenadePostion.rotation);
        GrenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePostion.forward * speed, ForceMode.Impulse);

    }
}
