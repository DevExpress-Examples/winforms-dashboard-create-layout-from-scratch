Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon

Namespace Dashboard_LayoutCustomization
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")
		End Sub

        Private Sub btnUpdateLayout_Click(ByVal sender As Object, ByVal e As EventArgs) _
                Handles btnUpdateLayout.Click
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            Dim grid As DashboardItem = CType(dashboard.Items(0), GridDashboardItem)
            Dim chart As DashboardItem = CType(dashboard.Items(1), ChartDashboardItem)
            Dim range As DashboardItem = CType(dashboard.Items(2), RangeFilterDashboardItem)

            ' Creates layout items used to display dashboard items.
            Dim gridItem As New DashboardLayoutItem(grid, 35)
            Dim chartItem As New DashboardLayoutItem(chart, 65)
            Dim rangeItem As New DashboardLayoutItem(range, 20)

            ' Creates a layout group that contains two layout items.
            Dim group1 As New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, _
                                                   80, gridItem, chartItem)
            ' Creates a root layout group that contains the previously created group and 
            ' the layout item displaying the Range Filter dashboard item. 
            Dim rootGroup As New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, _
                                                    1, group1, rangeItem)

            ' Specifies the root dashboard layout group.
            dashboard.LayoutRoot = rootGroup

            dashboardViewer1.Dashboard = dashboard
        End Sub
	End Class
End Namespace
