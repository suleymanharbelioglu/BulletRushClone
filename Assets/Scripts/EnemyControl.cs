using UnityEngine;


public class EnemyControl : MyCharacterController
{
    [SerializeField] private PlayerController player;
    public float Delay => delay;
    [SerializeField] private float delay; 
    private void FixedUpdate()
    {
        var delta = -transform.position + player.transform.position;
        delta.y = 0;
        var direction = delta.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }

    }
    
}
