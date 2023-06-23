using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float shoot_power = 10f;
    int count_contact_wall = 0;

    public Rigidbody2D rb;
    public LineRenderer lineRenderer;

    Vector3 velocity = new Vector3(0,0, 0);

    bool is_hit_enemy = false;

    bool is_hit_ally = false;

    void Start()
    {
        rb.velocity = velocity;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "wall")
        {
            count_contact_wall++;
        }
        if (collision.collider.tag == "Enemy")
        {
            is_hit_enemy = true;
        }
        if (collision.collider.tag == "Ally")
        {
            is_hit_ally = true;
        }
    }

	public void shoot()
    {
        rb.velocity = velocity * shoot_power;

        lineRenderer.SetVertexCount(0);
    }

    public void setVelocity (Vector3 vector3)
	{
        velocity = vector3;
	}

    public void drawAimLine ()
	{
        Vector3 direction = velocity;
        Vector3 lastHitPosition = transform.position;

        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, lastHitPosition + direction);
    }

    public bool isHitEnemy()
	{
        return is_hit_enemy;
	}

    public bool isHitAlly ()
    {
        return is_hit_ally;
    }

    public int countHitWall()
	{
        return count_contact_wall;
	}
    public void stopBall()
	{
        rb.velocity = new Vector3(0,0,0);
	}
}
