using System.Collections;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject monster;
    
    public int numberOfMonsters = 6;
    public int numberOfSecondsToSpawn = 5;

    private void Start()
    {
        StartCoroutine(SpawnNewMonster());
    }

    private void SpawnMonster()
    {
        int side = Random.Range(0f, 1f) > .5f ? 1 : -1;
        Instantiate(monster, new Vector2(26 * side, transform.position.y), transform.rotation);
        numberOfMonsters -= 1;
    }

    private IEnumerator SpawnNewMonster()
    {
        while (true)
        {
            {
                yield return new WaitForSeconds(numberOfSecondsToSpawn);
                if (numberOfMonsters > 0)
                    SpawnMonster();
            }
        }
    }
}
