using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReaderLineChart : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]
    public class HeartRate
    {
        
        public int x;
        public int y;
    }
    [System.Serializable]
    public class HeartRateList
    {
        public HeartRate[] heartRate;
    }
    public HeartRateList myHeartRateList = new HeartRateList();
    void Start()
    {
        myHeartRateList = JsonUtility.FromJson<HeartRateList>(textJSON.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
