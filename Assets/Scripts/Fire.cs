using System.Collections;
using UnityEngine;
using EZCameraShake;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 40;
    public LineRenderer lineRenderer;
    public float bulletForce = 20.0f;

    void Start(){
        lineRenderer.enabled = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
            CameraShaker.Instance.ShakeOnce(8f, 5f, 0.1f, 0.5f);
        }
        else if(Input.GetButtonDown("Fire2")){
            Shoot2();
        }
    }

    IEnumerator Shoot(){
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, -firePoint.up);

        if(hitInfo && hitInfo.transform.CompareTag("Enemy")){
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }    
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else{
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + -firePoint.up * 100);
        }
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }

    private void Shoot2(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(bulletForce * -firePoint.up, ForceMode2D.Impulse);
    }
}
