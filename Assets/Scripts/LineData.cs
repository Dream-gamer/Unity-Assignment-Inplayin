using UnityEngine;
using XCharts.Runtime;

public class LineData : MonoBehaviour
{
    public LineChart lineChart;  // Reference to the LineChart component in your scene
    private Serie serie2;
    void Start()
    {
        var ChartJson = gameObject.GetComponent<JSONReaderLineChart>();
        print(ChartJson.myHeartRateList.heartRate[0].y);
        var chart = gameObject.GetComponent<LineChart>();
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
            chart.Init();
        }
        //chart.SetSize(580, 300);
        var title = chart.EnsureChartComponent<Title>();
        title.text = "Heart Rate (bpm)";
        var tooltip = chart.EnsureChartComponent<Tooltip>();
        tooltip.show = true;

        var legend = chart.EnsureChartComponent<Legend>();
        legend.show = true;
       
        var xAxis = chart.EnsureChartComponent<XAxis>();
        xAxis.splitNumber = 10;
        xAxis.boundaryGap = true;
        xAxis.type = Axis.AxisType.Category;

        var yAxis = chart.EnsureChartComponent<YAxis>();
        yAxis.type = Axis.AxisType.Value;
        chart.RemoveData();
        chart.AddSerie<Line>("Heart Beat");
        int avgHB = 0;
        for (int i = 0; i < 10; i++)
        {
            //chart.AddXAxisData("x" + i);
            //chart.AddData(0, Random.Range(10, 20));
            chart.AddXAxisData(ChartJson.myHeartRateList.heartRate[i].x.ToString()+" minutes");
            chart.AddData(0, ChartJson.myHeartRateList.heartRate[i].y);
            avgHB += ChartJson.myHeartRateList.heartRate[i].y/10;
        }
        print(avgHB);
        serie2 = chart.AddSerie<Line>("Average Heart Beat");
        serie2.symbol.show = false;
        for (int i = 0; i < 10; i++)
        {
            chart.AddData(1, avgHB);
        }
    }
}