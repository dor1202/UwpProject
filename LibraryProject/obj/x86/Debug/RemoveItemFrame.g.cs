﻿#pragma checksum "C:\SelaCollege\project o-o design & .NET framework\LibraryProject\LibraryProject\RemoveItemFrame.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2B0F69F47B557BC30C9A2AB408451342"
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
    partial class RemoveItemFrame : 
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
            case 2: // RemoveItemFrame.xaml line 12
                {
                    this.backgroundGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // RemoveItemFrame.xaml line 17
                {
                    this.AppName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // RemoveItemFrame.xaml line 22
                {
                    this.ScrollItems = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // RemoveItemFrame.xaml line 13
                {
                    this.background = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 6: // RemoveItemFrame.xaml line 14
                {
                    this.submitBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.submitBtn).Click += this.Submit_Button_Click;
                }
                break;
            case 7: // RemoveItemFrame.xaml line 15
                {
                    this.backBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.backBtn).Click += this.Back_Button_Click;
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
