using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBT : TreeB
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Nodes SetupTree()
    {
        Nodes root = new Selector(new List<Nodes>
        {
            new Sequence(new List<Nodes>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<Nodes>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
