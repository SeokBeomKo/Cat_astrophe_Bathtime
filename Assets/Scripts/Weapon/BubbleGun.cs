using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : Weapon
{
    [Header("발사 위치")]
    public Transform shootPosition;

    [Header("발사체 프리팹")]
    public GameObject projectilePrefab; // 발사체 프리팹

    [Header("진행 목표")]
    private Vector3 shootTarget;

    // : 마우스 클릭 시
    public override void EnterShoot()
    {
        if (Time.time - lastShootTime >= shootDelay) 
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    // : 마우스 클릭 중
    public override void ExcuteShoot()
    {
        if (Time.time - lastShootTime >= shootDelay) 
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    public override void ExitShoot()
    {
    }

    public override void InitShoot()
    {
        
    }

    public override void SetTarget(Vector3 target)
    {
        shootTarget = target;
    }
    private float randomScale;

    public override void Shoot()
    {
        if (curBullet < useBullet) return;
        UseBullet();

        randomScale = Random.Range(0.3f,0.5f);
        // 비눗방울을 발사합니다.
        GameObject bullet = Instantiate(projectilePrefab, shootPosition.position, Quaternion.identity);
        SoundManager.Instance.PlaySFX("ShootBubbleGun");
        bullet.transform.localScale = new Vector3(randomScale,randomScale,randomScale);
        bullet.GetComponentInChildren<BubbleProjectile>().SetDirection(shootTarget);
        bullet.GetComponentInChildren<IProjectile>().SetDamage(GetDamage());
    }
}
