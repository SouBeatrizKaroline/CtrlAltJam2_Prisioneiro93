using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    

    [SerializeField] LayerMask _groundMask;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] GameObject _projectile;
    [SerializeField] Vector3 _attackPoint;

    private Vector3 _direction;
    private Rigidbody _myRigidbody;

    private CombatControls _myInputs;

    private void Awake()
    {
        _myInputs = new CombatControls();
        _myInputs.Enable();    
        _myInputs.CombatMap.Attack.performed += ctx => Shoot();
    }

    void Start()
    {
        _mainCamera = Camera.main;
        _myRigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Aim();
        //Shoot();
    }

    private void Aim()
    {
       var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Debug.DrawLine(transform.position, pointToLook, Color.red);
            _direction = pointToLook;
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject newProjectile = Instantiate(_projectile, _attackPoint, Quaternion.identity);
            newProjectile.transform.forward +=  _direction;

            Debug.Log("tiroooooo");
        }
    }
}
