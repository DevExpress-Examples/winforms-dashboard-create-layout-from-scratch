# How to modify dashboard layout in code


The following example demonstrates how to modify <a href="https://docs.devexpress.com/Dashboard/116693/main-features/dashboard-layout">dashboard layout</a> in code.

In this example, the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer">DashboardViewer</a> loads a dashboard containing three dashboard items placed vertically one above the other.
The following steps are taken to create a new layout:
- Three <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutItem"DashboardLayoutItem</a> objects are created to display the existing dashboard items. The weight parameter specifies the layout item's relative size.
- A new <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutGroup">layout group</a> is created to display two dashboard items. The orientation parameter specifies how layout items are placed within the group.
- A **root** layout group is created. This group contains the previously created group and another layout item.
- The root layout group is assigned to the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.LayoutRoot">Dashboard.LayoutRoot</a> property.

This example also demonstrates how to swap layout items using the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardLayoutNode.MoveRight.overloads">MoveRight</a> method, save and restore the layout using the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.SaveDashboardLayout(System.String)">SaveDashboardLayout</a> and <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.RestoreDashboardLayout(System.String)">RestoreDashboardLayout</a> methods.

![]()


