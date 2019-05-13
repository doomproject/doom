using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public float reloadTime = 5;
    [Tooltip("The higher the interval the faster the gun will fire.")]
    public float fireInterval = 1;
    public int damage = 1;
    public int clipSize = 5;
    public int currClip;
    public int ammo = 0;

	public GameObject bullet;
	[SerializeField] int bulletSpeed = 100;
	public ParticleSystem muzzleFlash;

	public Animator animator;

    private float nextTimetoFire = 0;

    void Awake()
    {
        if (clipSize > ammo)
        {
            currClip = ammo;
            ammo = 0;
        }
        else
        {
            ammo -= clipSize;
            currClip = clipSize;
        }
    }

	void OnEnable()
	{
		animator.SetBool("Reloading", false);
	}

    public void Fire()
    {
        if (currClip > 0 && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1 / fireInterval;
            currClip -= 1;
			muzzleFlash.Play();

            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100))
            {
				GameObject go = Instantiate(bullet, muzzleFlash.transform.position, muzzleFlash.transform.rotation);
				go.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * bulletSpeed;
				Destroy(go, 5f);

				EnemyHealth EH = hit.transform.GetComponent<EnemyHealth>();
                if (EH != null)
                {
                    EH.TakeDamage(damage);
                }
            }
        }
    }

    public void Reload()
    {
        ammo += currClip;
        currClip = 0;
        StartCoroutine(ReloadingTime());
    }

    IEnumerator ReloadingTime()
    {
		animator.SetBool("Reloading", true);
		yield return new WaitForSeconds(reloadTime - .25f);

		animator.SetBool("Reloading", false);
		yield return new WaitForSeconds(.25f);

		if (clipSize > ammo)
        {
            currClip = ammo;
            ammo = 0;
        }
        else
        {
            ammo -= clipSize;
            currClip = clipSize;
        }
    }
}
