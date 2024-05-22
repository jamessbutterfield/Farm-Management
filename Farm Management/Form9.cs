using Classes.LinkedList;
using System.Data;

namespace Farm_Management
{
    public partial class Form9 : Form
    {
        private LinkedList? GraphData;
        private bool PartsCostMode = false;
        
        public Form9(LinkedList GraphData, string Mode)
        {
            InitializeComponent();
            Icon = new Icon(@"Resources\Farm-Management-Icon.ico");
            this.GraphData = GraphData;
            if (Mode == "PartsCost")
                PartsCostMode = true;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (PartsCostMode == true)
            {
                DataTable data = new DataTable();
                data.Columns.Add("Registration", typeof(string));
                data.Columns.Add("Cost", typeof(double));

                int X = 1;
                int Y = 2;
                for (int i = 1; i <= (GraphData?.Count() - 2) / 2; i++)
                {
                    data.Rows.Add(GraphData?.GetItem(X), Convert.ToDouble(GraphData?.GetItem(Y)));
                    X = X + 2;
                    Y = Y + 2;
                }

                data.DefaultView.Sort = "Cost DESC";
                data = data.DefaultView.ToTable();

                chartStatistics.Titles.Add($"Vehicle Parts Cost between {GraphData?.GetItem(GraphData.Count() - 1)} and {GraphData?.GetItem(GraphData.Count())}");
                chartStatistics.DataSource = data;
                chartStatistics.Series.Add("Cost");
                chartStatistics.Series["Cost"].XValueMember = "Registration";
                chartStatistics.Series["Cost"].YValueMembers = "Cost";
                chartStatistics.ChartAreas[0].AxisX.Title = "Registration";
                chartStatistics.ChartAreas[0].AxisY.Title = "Cost";
            }
            else
            {
                DataTable data = new DataTable();
                data.Columns.Add("Registration", typeof(string));
                data.Columns.Add("Jobs", typeof(int));

                int X = 1;
                int Y = 2;
                for (int i = 1; i <= (GraphData?.Count() / 2); i++)
                {
                    data.Rows.Add(GraphData?.GetItem(X), Convert.ToInt32(GraphData?.GetItem(Y)));
                    X = X + 2;
                    Y = Y + 2;
                }

                data.DefaultView.Sort = "Jobs DESC";
                data = data.DefaultView.ToTable();

                chartStatistics.Titles.Add($"All time Vehicle Jobs");
                chartStatistics.DataSource = data;
                chartStatistics.Series.Add("Jobs");
                chartStatistics.Series["Jobs"].XValueMember = "Registration";
                chartStatistics.Series["Jobs"].YValueMembers = "Jobs";
                chartStatistics.ChartAreas[0].AxisX.Title = "Registration";
                chartStatistics.ChartAreas[0].AxisY.Title = "Number of Jobs";
            }
        }
    }
}
