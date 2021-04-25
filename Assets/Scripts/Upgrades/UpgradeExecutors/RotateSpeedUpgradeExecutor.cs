using UnityEngine;

public class RotateSpeedUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private WormMovement movement;

    public override void Execute(UpgradeStat stat)
    {
        movement.RotateSpeed = stat.statValue;
    }
}