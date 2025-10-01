using UnityEngine;

public class PatrolState : BaseState
{
    // Tracks the waypoints currently targeting.
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {
    }

    public override void Preformed()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
       if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > 3)
            {
                if (waypointIndex < enemy.path.waypoints.Count)
                {
                    waypointIndex++;
                }
                else
                    waypointIndex = 0;
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }    
    }
}
