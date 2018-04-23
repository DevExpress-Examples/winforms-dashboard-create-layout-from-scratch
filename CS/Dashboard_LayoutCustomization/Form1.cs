using System;
using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;

namespace Dashboard_LayoutCustomization {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.LoadDashboard(@"..\..\Data\Dashboard.xml");
        }

        private void btnUpdateLayout_Click(object sender, EventArgs e) {
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            DashboardItem grid = (GridDashboardItem)dashboard.Items[0];
            DashboardItem chart = (ChartDashboardItem)dashboard.Items[1];
            DashboardItem range = (RangeFilterDashboardItem)dashboard.Items[2];

            // Creates layout items used to display dashboard items.
            DashboardLayoutItem gridItem = new DashboardLayoutItem(grid, 35);
            DashboardLayoutItem chartItem = new DashboardLayoutItem(chart, 65);
            DashboardLayoutItem rangeItem = new DashboardLayoutItem(range, 20);

            // Creates a layout group that contains two layout items.
            DashboardLayoutGroup group1 = 
                new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, 80, 
                    gridItem, chartItem);
            // Creates a root layout group that contains the previously created group and 
            // the layout item displaying the Range Filter dashboard item. 
            DashboardLayoutGroup rootGroup = 
                new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, 1, 
                    group1, rangeItem);

            // Specifies the root dashboard layout group.
            dashboard.LayoutRoot = rootGroup;

            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
