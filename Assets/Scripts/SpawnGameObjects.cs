using UnityEngine;
using Framework.Template;

public class SpawnGameObjects : BaseSpawnGameObjects {
[SerializeField] private GameObject spawnPrefab;

	[SerializeField] private float minSecondsBetweenSpawning = 3.0f;
	[SerializeField] private float maxSecondsBetweenSpawning = 6.0f;
	
	[SerializeField] private Transform chaseTarget;
    
    protected override void MakeThingToSpawn() {
        GameObject clone = SpawnClone(spawnPrefab, transform.position, transform.rotation);

		var chaser = clone.gameObject.GetComponent<Chaser>();
		if (chaseTarget != null && chaser != null) {
			chaser.SetTarget(chaseTarget);
		}
    }
    
    protected override float HandleNextSpawn() {
        return Time.time + Random.Range(minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }
}
