using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private EnemyData _enemyData;

    private GameObject _playerTarget;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _playerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        SetAgentDestination();
        RotateTowardsPath();
    }

    private void SetAgentDestination()
    {
        _agent.SetDestination(_playerTarget.transform.position);
    }

    private void RotateTowardsPath()
    {
        Vector3 agentDestination = _agent.steeringTarget;
        Vector3 direction = agentDestination - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _enemyData.RotationSpeed * Time.deltaTime);
    }
}
