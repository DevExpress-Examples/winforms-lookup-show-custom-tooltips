<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128622054/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3040)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Lookup - Display custom tooltips

This example demonstrates how to display custom tooltips for drop-down items in the WinForms LookUpEdit control.

```csharp
void lookUpEditHints1_BeforeShowingTooltip(object sender, EventArgs e) {
    ToolTipControllerShowEventArgs ee = e as ToolTipControllerShowEventArgs;
    ee.ToolTip += " + custom tool tip can be added";
}
```


## Files to Review

* [Form1.cs](./CS/LookUpEditWithHints/Form1.cs) (VB: [Form1.vb](./VB/LookUpEditWithHints/Form1.vb))
* [LookUpEditHints.cs](./CS/LookUpEditWithHints/LookUpEditHints.cs) (VB: [LookUpEditHints.vb](./VB/LookUpEditWithHints/LookUpEditHints.vb))
* [PopupLookUpEditHintsForm.cs](./CS/LookUpEditWithHints/PopupLookUpEditHintsForm.cs) (VB: [PopupLookUpEditHintsForm.vb](./VB/LookUpEditWithHints/PopupLookUpEditHintsForm.vb))
* [RepositoryItemLookUpEditHints.cs](./CS/LookUpEditWithHints/RepositoryItemLookUpEditHints.cs) (VB: [RepositoryItemLookUpEditHints.vb](./VB/LookUpEditWithHints/RepositoryItemLookUpEditHints.vb))


## Documentation

* [Hints and Tooltips](https://docs.devexpress.com/WindowsForms/1818/controls-and-libraries/pivot-grid/miscellaneous/hints-and-tooltips)
