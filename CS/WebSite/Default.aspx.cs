using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;

public partial class _Default : System.Web.UI.Page {
    List<string> CurrentSelectedKeys;
    string ChangedSelectionNodeKey;
    List<string> afterRecursiveSelectionKeys;
    protected List<string> AfterRecursiveSelectionKeys {
        get {
            if(afterRecursiveSelectionKeys == null) 
                afterRecursiveSelectionKeys = Session["after"] as List<string>;
            return afterRecursiveSelectionKeys;
        }
        set { Session["after"] = afterRecursiveSelectionKeys = value; }
    }
    protected void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) Session.Clear();
    }
    protected void treeList_DataBound(object sender, EventArgs e) {
        if(!IsPostBack) treeList.ExpandAll();
    }
    protected void treeList_SelectionChanged(object sender, EventArgs e) {
        CurrentSelectedKeys = GetSelectedNodesKeys();
        SetChangedSelectionNodeKey();
        TreeListNode node = treeList.FindNodeByKeyValue(ChangedSelectionNodeKey);
        SelectParentNodes(node);
        SelectChildNodes(node);
        AfterRecursiveSelectionKeys = GetSelectedNodesKeys();
    }
    List<string> GetSelectedNodesKeys() {
        return treeList.GetSelectedNodes().Select(node => node.Key).ToList();
    }
    void SetChangedSelectionNodeKey() {
        if(AfterRecursiveSelectionKeys == null)
            ChangedSelectionNodeKey = CurrentSelectedKeys.First();
        else {
            ChangedSelectionNodeKey = AfterRecursiveSelectionKeys.Count > CurrentSelectedKeys.Count ?
                AfterRecursiveSelectionKeys.Except(CurrentSelectedKeys).First() :
                CurrentSelectedKeys.Except(AfterRecursiveSelectionKeys).First();
        }
    }
    void SelectParentNodes(TreeListNode node) {
        TreeListNode parent = node.ParentNode;
        if(parent != null) {
            if(node.Key != ChangedSelectionNodeKey)
                node.Selected = !node.Selected;
            if(!HasSelectedChildren(node, parent))
                SelectParentNodes(parent);
        }
    }
    bool HasSelectedChildren(TreeListNode node, TreeListNode parent) {
        foreach(TreeListNode item in parent.ChildNodes) {
            if(item.Selected && item.Key != node.Key) return true;
        }
        return false;
    }
    void SelectChildNodes(TreeListNode node) {
        if(node.Key != ChangedSelectionNodeKey)
            node.Selected = node.ParentNode.Selected ? !node.Selected : false;
        foreach(TreeListNode item in node.ChildNodes) {
            SelectChildNodes(item);
        }
    }
}