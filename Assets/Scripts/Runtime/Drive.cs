using System;
using Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public Slider healthBarSlider;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("asteroid"))
        {
            healthBarSlider.value -= 10f;
        }
    }

    void Update()
    {
        ShipMovement();
        FireProjectile();
        HealthBarAllign();
    }

    private void HealthBarAllign()
    {
        Vector3 screenPos = gameObject.GetComponent<SpriteRenderer>().bounds.size;
        screenPos.y -= 65f;
        Vector3 shipPos = Camera.main.WorldToScreenPoint(transform.position) + screenPos;
        healthBarSlider.transform.position = shipPos;
    }

    private void FireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Pool.Instance.Get("bullet");
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    private void ShipMovement()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }
}