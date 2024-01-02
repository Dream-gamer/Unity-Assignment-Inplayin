using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReaderBarChart : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]
    public class Session
    {

        public int distance;
        public int caloriesBurnt;
        public int duration;
    }
    [System.Serializable]
    public class SessionList
    {
        public Session[] session;
    }
    public SessionList mySessionList = new SessionList();
    void Start()
    {
        mySessionList = JsonUtility.FromJson<SessionList>(textJSON.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
