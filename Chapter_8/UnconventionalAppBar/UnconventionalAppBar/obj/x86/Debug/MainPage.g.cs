﻿#pragma checksum "D:\quokka\WDF_homework\Programming_Windows_by_Charls_Petzold\Chapter_8\UnconventionalAppBar\UnconventionalAppBar\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5FCB9166657B7B1E132B71183723872E58A364EB8C560DBF21F64762AC36144E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnconventionalAppBar
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 12
                {
                    this.textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MainPage.xaml line 20
                {
                    this.topAppBar = (global::Windows.UI.Xaml.Controls.AppBar)(target);
                }
                break;
            case 4: // MainPage.xaml line 21
                {
                    this.slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                }
                break;
            case 5: // MainPage.xaml line 29
                {
                    this.bottomAppBar = (global::Windows.UI.Xaml.Controls.AppBar)(target);
                }
                break;
            case 6: // MainPage.xaml line 32
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.OnAppBarButtonClick;
                }
                break;
            case 7: // MainPage.xaml line 37
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.OnAppBarButtonClick;
                }
                break;
            case 8: // MainPage.xaml line 42
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.OnAppBarButtonClick;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

