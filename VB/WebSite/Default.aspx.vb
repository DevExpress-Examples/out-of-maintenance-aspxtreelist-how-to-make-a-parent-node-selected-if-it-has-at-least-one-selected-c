Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxTreeList

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private CurrentSelectedKeys As List(Of String)
	Private ChangedSelectionNodeKey As String
	Private afterRecursiveSelectionKeys_Renamed As List(Of String)
	Protected Property AfterRecursiveSelectionKeys() As List(Of String)
		Get
			If afterRecursiveSelectionKeys_Renamed Is Nothing Then
				afterRecursiveSelectionKeys_Renamed = TryCast(Session("after"), List(Of String))
			End If
			Return afterRecursiveSelectionKeys_Renamed
		End Get
		Set(ByVal value As List(Of String))
			afterRecursiveSelectionKeys_Renamed = value
			Session("after") = afterRecursiveSelectionKeys_Renamed
		End Set
	End Property
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			Session.Clear()
		End If
	End Sub
	Protected Sub treeList_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			treeList.ExpandAll()
		End If
	End Sub
	Protected Sub treeList_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
		CurrentSelectedKeys = GetSelectedNodesKeys()
		SetChangedSelectionNodeKey()
		Dim node As TreeListNode = treeList.FindNodeByKeyValue(ChangedSelectionNodeKey)
		SelectParentNodes(node)
		SelectChildNodes(node)
		AfterRecursiveSelectionKeys = GetSelectedNodesKeys()
	End Sub
	Private Function GetSelectedNodesKeys() As List(Of String)
		Return treeList.GetSelectedNodes().Select(Function(node) node.Key).ToList()
	End Function
	Private Sub SetChangedSelectionNodeKey()
		If AfterRecursiveSelectionKeys Is Nothing Then
			ChangedSelectionNodeKey = CurrentSelectedKeys.First()
		Else
			If AfterRecursiveSelectionKeys.Count > CurrentSelectedKeys.Count Then
				ChangedSelectionNodeKey = AfterRecursiveSelectionKeys.Except(CurrentSelectedKeys).First()
			Else
				ChangedSelectionNodeKey = CurrentSelectedKeys.Except(AfterRecursiveSelectionKeys).First()
			End If
		End If
	End Sub
	Private Sub SelectParentNodes(ByVal node As TreeListNode)
		Dim parent As TreeListNode = node.ParentNode
		If parent IsNot Nothing Then
			If node.Key <> ChangedSelectionNodeKey Then
				node.Selected = Not node.Selected
			End If
			If (Not HasSelectedChildren(node, parent)) Then
				SelectParentNodes(parent)
			End If
		End If
	End Sub
	Private Function HasSelectedChildren(ByVal node As TreeListNode, ByVal parent As TreeListNode) As Boolean
		For Each item As TreeListNode In parent.ChildNodes
			If item.Selected AndAlso item.Key <> node.Key Then
				Return True
			End If
		Next item
		Return False
	End Function
	Private Sub SelectChildNodes(ByVal node As TreeListNode)
		If node.Key <> ChangedSelectionNodeKey Then
			If node.ParentNode.Selected Then
				node.Selected = Not node.Selected
			Else
				node.Selected = False
			End If
		End If
		For Each item As TreeListNode In node.ChildNodes
			SelectChildNodes(item)
		Next item
	End Sub
End Class