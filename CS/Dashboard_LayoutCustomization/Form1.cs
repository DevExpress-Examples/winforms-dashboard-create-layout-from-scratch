using System;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using System.IO;

namespace Dashboard_LayoutCustomization {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.CustomizeDashboardTitle += DashboardViewer1_CustomizeDashboardTitle;
            dashboardViewer1.LoadDashboard(@"..\..\Data\Dashboard.xml");
        }

        private void ChangeLayout(DashboardToolbarItemClickEventArgs args)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboard.BeginUpdate();

            // Create layout items used to display dashboard items.
            DashboardLayoutItem item0 = new DashboardLayoutItem(dashboard.Items[0], 35);
            DashboardLayoutItem item1 = new DashboardLayoutItem(dashboard.Items[1], 65);
            DashboardLayoutItem item2 = new DashboardLayoutItem(dashboard.Items[2], 20);
            // Create a layout group that contains two layout items.
            DashboardLayoutGroup group1 =
                new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, 80,
                    item0, item1);
            // Create a root layout group that contains the previously created group and 
            // another layout item. 
            DashboardLayoutGroup rootGroup =
                new DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, 1,
                    group1, item2);
            // Applies the layout to the dashboard.
            dashboard.LayoutRoot = rootGroup;

            dashboard.EndUpdate();
            dashboardViewer1.Dashboard = dashboard;
        }

        private void RepositionItems(DashboardToolbarItemClickEventArgs args)
        {
            Dashboard dashboard = dashboardViewer1.Dashboard;
            DashboardLayoutGroup rootGroup = dashboard.LayoutRoot.ChildNodes[0] as DashboardLayoutGroup;
            if ((rootGroup != null) && (rootGroup.ChildNodes.Count > 1))
                rootGroup.ChildNodes[0].MoveRight(rootGroup.ChildNodes[1]);
        }

        private void SaveLayoutToFile(DashboardToolbarItemClickEventArgs args)
        {
            dashboardViewer1.SaveDashboardLayout("DashboardLayout.xml");
        }

        private void LoadLayoutFromFile(DashboardToolbarItemClickEventArgs obj)
        {
            if (File.Exists("DashboardLayout.xml"))
                dashboardViewer1.LoadDashboardLayout("DashboardLayout.xml");
        }

        private void DashboardViewer1_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        {
            var exportItem = e.Items.FirstOrDefault(i => i.ButtonType == DashboardButtonType.Export);
            if (exportItem != null)
                e.Items.Remove(exportItem);
            DashboardToolbarItem btnChangeLayout = new DashboardToolbarItem();
            btnChangeLayout.Caption = "Change Layout";
            btnChangeLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(ChangeLayout);
            e.Items.Add(btnChangeLayout);
            DashboardToolbarItem btnRepositionItems = new DashboardToolbarItem();
            btnRepositionItems.Caption = "Reposition Items";
            btnRepositionItems.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(RepositionItems);
            e.Items.Add(btnRepositionItems);
            DashboardToolbarItem btnSaveLayout = new DashboardToolbarItem();
            btnSaveLayout.Caption = "Save Layout to File";
            btnSaveLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(SaveLayoutToFile);
            e.Items.Add(btnSaveLayout);
            DashboardToolbarItem btnLoadLayout = new DashboardToolbarItem();
            btnLoadLayout.Caption = "Load Layout from File";
            btnLoadLayout.ClickAction = new Action<DashboardToolbarItemClickEventArgs>(LoadLayoutFromFile);
            e.Items.Add(btnLoadLayout);
        }
    }
}
