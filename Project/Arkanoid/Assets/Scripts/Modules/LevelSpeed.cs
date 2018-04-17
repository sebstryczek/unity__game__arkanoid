using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    [SerializeField] private BallMovement ballMovement;
    [SerializeField] private PaddleMovement paddleMovement;

    private bool isActive = false;
    private float duration = 0;

    private void Update()
    {
        if (this.isActive)
        {
            if (this.duration > 0)
            {
                this.duration -= Time.deltaTime;
            }
            else
            {
                this.ballMovement.SetSpeedFactor(1);
                this.paddleMovement.SetSpeedFactor(1);
                this.duration = 0;
                this.isActive = false;
            }
        }
    }

    public void ResetSpeed()
    {
        this.ballMovement.SetSpeedFactor(1);
        this.paddleMovement.SetSpeedFactor(1);
        this.duration = 0;
        this.isActive = false;
    }

    public void SetSpeed(float factor, float duration)
    {
        if (factor != 1 && duration > 0)
        {
            this.duration = duration;
            this.ballMovement.SetSpeedFactor(factor);
            this.paddleMovement.SetSpeedFactor(factor);
            this.isActive = true;
        }
    }
}
