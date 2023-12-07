using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<CarController> cars = new List<CarController>();

    void Awake() {
        instance = this;
    }
}
