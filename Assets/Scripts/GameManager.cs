using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<CarController> cars = new List<CarController>();

    public float postiionUpdateRate = 0.05f;
    private float lastPositionUpdateTime;

    void Awake() {
        instance = this;
    }

    void Update()
    {
        if(Time.time - lastPositionUpdateTime > postiionUpdateRate) {
            lastPositionUpdateTime = Time.time;
            UpdateCarRacePositions();
        }
    }

    void UpdateCarRacePositions() {
        cars.Sort(SortPosition);

        for(int x = 0; x < cars.Count; x ++) {
            cars[x].racePosition = cars.Count - x;
        }
    }

    int SortPosition(CarController a, CarController b) {
        if(a.zonesPassed > b.zonesPassed) 
            return 1;
        else if(b.zonesPassed > a.zonesPassed)
            return -1;
        
        float aDist = Vector3.Distance(a.transform.position, a.curTrackZone.transform.position);
        float bDist = Vector3.Distance(b.transform.position, b.curTrackZone.transform.position);

        return aDist > bDist ? 1 : -1;
    }
}
