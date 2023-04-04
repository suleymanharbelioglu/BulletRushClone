using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MyCharacterController
{
    [SerializeField] private ScreenTouchController input;
    [SerializeField] private ShootController shootController;

    public List<Transform> _enemies = new ();
    private bool _isShooting;

    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }

    private void Update()
    {
        if(_enemies.Count >0)
        {
            transform.LookAt(_enemies[0]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");           // player dies when enemy touchs
        if(collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("enemy");

            Dead();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            if(!_enemies.Contains(other.transform))
            _enemies.Add(other.transform);
            AutoShoot();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Enemy"))
        {
            _enemies.Remove(other.transform);
            
        }
    }
    

    private void AutoShoot()
    {
        
        if(!_isShooting)
        {
            _isShooting = true;
            StartCoroutine(Do());
        } 
    }
    IEnumerator Do()
    {
            while(_enemies.Count > 0)
            {
                var enemy = _enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0; 
                direction = direction.normalized;
                shootController.Shoot(direction, transform.position);
                //transform.LookAt(enemy.transform);
                _enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.Delay);
            }
            _isShooting = false;
            
    }
    private void Dead()
    {
        Debug.Log("dead");
        Time.timeScale = 0;
    }
   
}
    
