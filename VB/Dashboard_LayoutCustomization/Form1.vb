Imports System
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports System.IO

Namespace Dashboard_LayoutCustomization
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            AddHandler dashboardViewer1.CustomizeDashboardTitle, AddressOf DashboardViewer1_CustomizeDashboardTitle
            dashboardViewer1.LoadDashboard("..\..\Data\Dashboard.xml")
        End Sub

        Private Sub ChangeLayout(ByVal args As DashboardToolbarItemClickEventArgs)
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboard.BeginUpdate()

            ' Create layout items used to display dashboard items.
            Dim item0 As New DashboardLayoutItem(dashboard.Items(0), 35)
            Dim item1 As New DashboardLayoutItem(dashboard.Items(1), 65)
            Dim item2 As New DashboardLayoutItem(dashboard.Items(2), 20)
            ' Create a layout group that contains two layout items.
            Dim group1 As New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Horizontal, 80, item0, item1)
            ' Create a root layout group that contains the previously created group and 
            ' another layout item. 
            Dim rootGroup As New DashboardLayoutGroup(DashboardLayoutGroupOrientation.Vertical, 1, group1, item2)
            ' Applies the layout to the dashboard.
            dashboard.LayoutRoot = rootGroup

            dashboard.EndUpdate()
            dashboardViewer1.Dashboard = dashboard
        End Sub

        Private Sub RepositionItems(ByVal args As DashboardToolbarItemClickEventArgs)
            Dim dashboard As Dashboard = dashboardViewer1.Dashboard
            Dim rootGroup As DashboardLayoutGroup = TryCast(dashboard.LayoutRoot.ChildNodes(0), DashboardLayoutGroup)
            If (rootGroup IsNot Nothing) AndAlso (rootGroup.ChildNodes.Count > 1) Then
                rootGroup.ChildNodes(0).MoveRight(rootGroup.ChildNodes(1))
            End If
        End Sub

        Private Sub SaveLayoutToFile(ByVal args As DashboardToolbarItemClickEventArgs)
            dashboardViewer1.SaveDashboardLayout("DashboardLayout.xml")
        End Sub

        Private Sub LoadLayoutFromFile(ByVal obj As DashboardToolbarItemClickEventArgs)
            If File.Exists("DashboardLayout.xml") Then
                dashboardViewer1.LoadDashboardLayout("DashboardLayout.xml")
            End If
        End Sub

        Private Sub DashboardViewer1_CustomizeDashboardTitle(ByVal sender As Object, ByVal e As CustomizeDashboardTitleEventArgs)
            Dim exportItem = e.Items.FirstOrDefault(Function(i) i.ButtonType = DashboardButtonType.Export)
            If exportItem IsNot Nothing Then
                e.Items.Remove(exportItem)
            End If
            Dim btnChangeLayout As New DashboardToolbarItem()
            btnChangeLayout.Caption = "Change Layout"
            btnChangeLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf ChangeLayout)
            e.Items.Add(btnChangeLayout)
            Dim btnRepositionItems As New DashboardToolbarItem()
            btnRepositionItems.Caption = "Reposition Items"
            btnRepositionItems.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf RepositionItems)
            e.Items.Add(btnRepositionItems)
            Dim btnSaveLayout As New DashboardToolbarItem()
            btnSaveLayout.Caption = "Save Layout to File"
            btnSaveLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf SaveLayoutToFile)
            e.Items.Add(btnSaveLayout)
            Dim btnLoadLayout As New DashboardToolbarItem()
            btnLoadLayout.Caption = "Load Layout from File"
            btnLoadLayout.ClickAction = New Action(Of DashboardToolbarItemClickEventArgs)(AddressOf LoadLayoutFromFile)
            e.Items.Add(btnLoadLayout)
        End Sub
    End Class
End Namespace
