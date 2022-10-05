using System.Collections;
using UnityEngine;

public class BasketballSpawner : MonoBehaviour
{
    [SerializeField] private GameObject basketballPrefab;

    [Space]
    [SerializeField] private Vector3 spawnPosition;

    public void SpawnBasketball()
    {
        StartCoroutine(nameof(SpawnBasketballRoutine));
    }

    IEnumerator SpawnBasketballRoutine()
    {
        yield return new WaitForSeconds(1);

        GameObject go = Instantiate(basketballPrefab, spawnPosition, Quaternion.identity, transform);
        go.GetComponent<TossBall>().basketballSpawner = this;

        yield break;
    }
}
