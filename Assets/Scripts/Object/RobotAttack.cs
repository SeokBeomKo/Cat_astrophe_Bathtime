using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttack : MonoBehaviour
{
    //public ChaseCenter chaseCenter;

    public delegate void RobotHandle();
    public event RobotHandle onRobotAttack;
    public event RobotHandle onPlay;
    public event RobotHandle onShoot;

    private Vector3 targetPos;

    public GameObject Block; // 프로젝타일 프리팹

    // Start is called before the first frame update
    void Start()
    {
        onRobotAttack?.Invoke();
        Invoke("PlayStart", 3f);

        InvokeRepeating("SpawnProjectile", 0f, 3f);
    }

    private void SpawnProjectile()
    {
        onShoot?.Invoke();
        if (Block != null)
        {
            // 새로운 프로젝타일 오브젝트 생성
            RobotProjectile projectile = Instantiate(Block, transform.GetChild(0).position, Quaternion.identity).GetComponent<RobotProjectile>();
            projectile.SetEndPos(transform.transform.GetChild(0).position, targetPos);
        }
    }


    public void PlayStart()
    {
        onPlay?.Invoke();
    }

    public void SetEndPos(Vector3 pos)
    {
        targetPos = pos;
    }
}
