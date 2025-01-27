using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 40;
    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.CompareTag("Enemy")){
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy?.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
