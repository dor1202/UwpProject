﻿#pragma checksum "C:\SelaCollege\project o-o design & .NET framework\LibraryProject\LibraryProject\AddItemFrame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "29E7AB03A9F56789A08335A65AD0B73C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject
{
    partial class AddItemFrame : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // AddItemFrame.xaml line 12
                {
                    this.backgroundGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // AddItemFrame.xaml line 21
                {
                    this.submitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.submitBtn).Click += this.submitBtn_Click;
                }
                break;
            case 4: // AddItemFrame.xaml line 22
                {
                    this.cancelBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.cancelBtn).Click += this.cancelBtn_Click;
                }
                break;
            case 5: // AddItemFrame.xaml line 23
                {
                    this.AppName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // AddItemFrame.xaml line 26
                {
                    this.autorOrDate = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // AddItemFrame.xaml line 31
                {
                    this.kindSwitch = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.kindSwitch).Toggled += this.ToggleSwitch_Toggled;
                }
                break;
            case 8: // AddItemFrame.xaml line 32
                {
                    this.caleDate = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.caleDate).DateChanged += this.caleDate_DateChanged;
                }
                break;
            case 9: // AddItemFrame.xaml line 35
                {
                    this.generList = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 10: // AddItemFrame.xaml line 13
                {
                    this.background = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 11: // AddItemFrame.xaml line 14
                {
                    this.priceTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.priceTxt).TextChanged += this.TextBox_TextChanged;
                }
                break;
            case 12: // AddItemFrame.xaml line 15
                {
                    this.editionTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.editionTxt).TextChanged += this.TextBox_TextChanged;
                }
                break;
            case 13: // AddItemFrame.xaml line 16
                {
                    this.imageTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.imageTxt).TextChanged += this.Txt_TextChanged;
                }
                break;
            case 14: // AddItemFrame.xaml line 17
                {
                    this.autorTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.autorTxt).TextChanged += this.Txt_TextChanged;
                }
                break;
            case 15: // AddItemFrame.xaml line 18
                {
                    this.nameTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.nameTxt).TextChanged += this.Txt_TextChanged;
                }
                break;
            case 16: // AddItemFrame.xaml line 19
                {
                    this.publisherTxt = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.publisherTxt).TextChanged += this.Txt_TextChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
