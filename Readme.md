# ASPxTreeList - How to make a parent node selected if it has at least one selected child node


<p>The ASPxTreeList supports recursive node selection, which is enabled by the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListTreeListSettingsSelection_Recursivetopic"><u>SettingsSelection.Recursive</u></a> property. When this feature is enabled, the control's parent node is selected if all its child nodes are selected; the parent node is not selected if none of its child nodes are  selected. In addition, the control's parent node can have a third, partially-selected state, when some of its child nodes are selected and others are not. This example shows how to avoid the partially-selected state, but save the recursive logic of node selection; i.e., to select a parent node when it contains at least one selected child node.</p>

<br/>


