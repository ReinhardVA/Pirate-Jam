using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody2D _rb;
    public Camera cam;
    private Vector2 _movement;
    private Vector2 _mousePos;

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate(){
        _rb.MovePosition(_rb.position + moveSpeed * Time.fixedDeltaTime * _movement);

        Vector2 lookDir = _mousePos - _rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90.0f;
        _rb.rotation = angle;

    }
}
