using UnityEngine;

public class SpeedUpgradeExecutor : UpgradeExecutor
{
    [SerializeField]
    private WormMovement movement;

    public override void Execute(UpgradeStat stat)
    {
        movement.WormSpeed = stat.statValue;
    }
}
