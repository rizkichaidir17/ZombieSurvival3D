//#define CodinganMasAd
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Zombie zombiePrefabs;
    List<Zombie> zombieList = new List<Zombie>();
    public int sizePool;
    public Transform[] posisiSpawner;
    public float cooldown;
    float currentCoolDown;
    Vector3 posisiZombieSpawn;

    void Start()
    {
        for (int i = 0; i < sizePool; i++)
        {
            Zombie zom = Instantiate(zombiePrefabs, transform);
            zom.gameObject.SetActive(false);
            zombieList.Add(zom);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CooldownReduce();
        
    }

    private void CooldownReduce()
    {
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
        }
        else
        {

        
            SpawnnedZombie();
            currentCoolDown = cooldown;
           
        }
    }

    void SpawnnedZombie()
    {
        Zombie obj = GetZombiePooled();
        if (obj != null)
        {
            obj.transform.position = posisiSpawner[Random.Range(0, posisiSpawner.Length)].position;
            obj.gameObject.SetActive(true);
            obj.enabled = true;
        }
    }

    #region Pooling Object
  

    // Start is called before the first frame update
   
    
    public Zombie GetZombiePooled()
    {
        for (int i = 0; i < zombieList.Count; i++)
        {
            if(!zombieList[i].gameObject.activeInHierarchy)
            {
                return zombieList[i];
            }
        }

        return null;
    }

#if CodinganMasAdi
    public void PoolingZombbie()
    {

        //foreach (var item in posisiSpawner)
        //{
            //check enemy yang sudah mati
           var z = spawnedZombie.Find(x => x.isDead && !x.gameObject.activeInHierarchy);
            if (z != null)
            {
                z.enabled = true;
                z.isDead = false;
                z.transform.position = posisiSpawn.position;
                z.gameObject.SetActive(true);
            }
            else
            {
                var spawned = Instantiate(en);
                spawned.transform.position = posisiSpawn.position;
                spawnedZombie.Add(spawned);
            } 
        //}
    }
#endif 
#endregion
}
