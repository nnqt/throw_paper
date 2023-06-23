using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState { Win, Lose, Playing}

public class game_manager : MonoBehaviour
{
    [SerializeField]
    private ball ball;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private result_panel panel;

    bool can_shoot = true;

    Vector2 start_mouse_point;
    Vector2 current_mouse_point;

    //GameState game_state = GameState.Playing;

	private void Awake()
	{
        cam = Camera.main;
	}

	private void Update()
	{
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick();
        }
        if (Input.GetMouseButton(0))
        {
            MouseDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseRelease();
        }
        CheckEndCondition();
    }

    void MouseClick()
    {
        if (can_shoot)
        {
            start_mouse_point = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            return;
        }

    }

    void MouseDrag()
    {
        if (can_shoot)
        {

            current_mouse_point = cam.ScreenToWorldPoint(Input.mousePosition);

            var x = (current_mouse_point.x - start_mouse_point.x);
            var y = (current_mouse_point.y - start_mouse_point.y);
            Vector3 vector3 = new Vector3(x, y, 0f);

            vector3.Normalize();
            ball.setVelocity(vector3);

            ball.drawAimLine();

        }
        else
        {
            return;
        }
    }

    void MouseRelease()
    {
        if (can_shoot)
        {
            current_mouse_point = cam.ScreenToWorldPoint(Input.mousePosition);

            var x = (current_mouse_point.x - start_mouse_point.x);
            var y = (current_mouse_point.y - start_mouse_point.y);
            Vector3 vector3 = new Vector3(x, y, 0f);

            vector3.Normalize();
            ball.setVelocity(vector3);

            ball.shoot();

            can_shoot = false;
        }
        else
        {
            return;
        }
    }

    void CheckEndCondition()
	{
        if (ball.isHitAlly() || (ball.countHitWall() > 10))
        {
            //game_state = GameState.Lose;
            panel.showResultLosing();
            pauseGame();
        }
        if (ball.isHitEnemy())
        {
            //game_state = GameState.Win;
            panel.showResultWining();
            pauseGame();
        }
    }

    private void pauseGame()
	{
        ball.stopBall();
	}
}
