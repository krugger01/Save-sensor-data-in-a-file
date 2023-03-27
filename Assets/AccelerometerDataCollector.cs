using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class AccelerometerDataCollector : MonoBehaviour
{
    private bool isCollectingData = false;
    private float startTime;
    private List<Vector3> accelerometerData = new List<Vector3>();

    void Update()
    {
        if (isCollectingData)
        {
            accelerometerData.Add(Input.acceleration);
        }
    }

    public void StartCollectingData()
    {
        isCollectingData = true;
        startTime = Time.time;
        accelerometerData.Clear();
    }

    public void StopCollectingData()
    {
        isCollectingData = false;

        // Save data to CSV file
        string filePath = Application.persistentDataPath + "/accelerometer_data.csv";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Vector3 dataPoint in accelerometerData)
            {
                writer.WriteLine(dataPoint.x.ToString() + "," + dataPoint.y.ToString() + "," + dataPoint.z.ToString());
            }

            writer.Close();
        }
        Debug.Log(filePath);
    }
}

