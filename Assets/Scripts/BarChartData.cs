using System.Collections;
using UnityEngine;
using XCharts.Runtime;

namespace XCharts.Example
{
    [DisallowMultipleComponent]
    public class BarChartData : MonoBehaviour
    {
        private BarChart chart;
        private Serie serie, serie2, serie3;
        private int m_DataNum = 10;

        //private void OnEnable()
        //{
        //    StartCoroutine(PieDemo());
        //}
        private void Start()
        {
            var BarChartJson = gameObject.GetComponent<JSONReaderBarChart>();
            chart = gameObject.GetComponent<BarChart>();
            if (chart == null) chart = gameObject.AddComponent<BarChart>();
            chart.EnsureChartComponent<Title>().text = "Performance summary";
            chart.EnsureChartComponent<Title>().subText = "Past 10 sessions";

            var yAxis = chart.EnsureChartComponent<YAxis>();
            yAxis.minMaxType = Axis.AxisMinMaxType.Default;
            chart.RemoveData();
            serie = chart.AddSerie<Bar>("Duration (mins)");

            for (int i = 0; i < m_DataNum; i++)
            {
                chart.AddXAxisData("Session " + (i + 1));
                //chart.AddData(0, UnityEngine.Random.Range(10, 60));
                chart.AddData(0, BarChartJson.mySessionList.session[i].duration);
            }


            serie2 = chart.AddSerie<Bar>("Calories burnt");
            serie2.lineType = LineType.Normal;
            serie2.barWidth = 0.35f;
            for (int i = 0; i < m_DataNum; i++)
            {
                chart.AddData(1, BarChartJson.mySessionList.session[i].caloriesBurnt);
            }
            serie3 = chart.AddSerie<Bar>("Distance (km)");
            serie3.lineType = LineType.Normal;
            serie3.barWidth = 0.35f;
            for (int i = 0; i < m_DataNum; i++)
            {
                chart.AddData(2, BarChartJson.mySessionList.session[i].distance);
            }
        }
    }
}