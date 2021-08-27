<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128548281/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4548)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# ASPxTreeList - How to make a parent node selected if it has at least one selected child node
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4548/)**
<!-- run online end -->


<p>The ASPxTreeList supports recursive node selection, which is enabled by the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListTreeListSettingsSelection_Recursivetopic"><u>SettingsSelection.Recursive</u></a> property. When this feature is enabled, the control's parent node is selected if all its child nodes are selected; the parent node is not selected if none of its child nodes are  selected. In addition, the control's parent node can have a third, partially-selected state, when some of its child nodes are selected and others are not. This example shows how to avoid the partially-selected state, but save the recursive logic of node selection; i.e., to select a parent node when it contains at least one selected child node.</p>

<br/>


