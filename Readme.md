<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581052/18.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5206)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to modify dashboard layout in code


The following example demonstrates how to modify <a href="https://docs.devexpress.com/Dashboard/116693/main-features/dashboard-layout">dashboard layout</a> in code.

In this example, the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer">DashboardViewer</a> loads a dashboard containing three dashboard items placed vertically one above the other.
The following steps are taken to create a new layout:
1. Three <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutItem">DashboardLayoutItem</a> objects are created to display the existing dashboard items. The weight parameter specifies the layout item's relative size.
2. A new <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutGroup">layout group</a> is created to display two dashboard items. The orientation parameter specifies how layout items are placed within the group.
3. A **root** layout group is created. This group contains the previously created group and another layout item.
4. The root layout group is assigned to the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.LayoutRoot">Dashboard.LayoutRoot</a> property.

This example also demonstrates how to swap layout items using the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutNode.MoveRight.overloads">MoveRight</a> method, save and restore the layout using the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.SaveDashboardLayout(System.String)">SaveDashboardLayout</a> and <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.LoadDashboardLayout(System.String)">LoadDashboardLayout</a> methods.

![](https://github.com/DevExpress-Examples/how-to-create-a-dashboard-layout-from-scratch-e5206/blob/18.1.4%2B/images/how-to-modify-dashboard-layout.png)


