﻿#pragma checksum "D:\quokka\WDF_homework\Programming_Windows_by_Charls_Petzold\Chaper_10\NonAffineStretch\NonAffineStretch\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B1185362FFA93CAA97F961EE142F59AC4B06ECE71B6F9FC8A5B3168BD27DBA40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NonAffineStretch
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
            case 2: // MainPage.xaml line 29
                {
                    global::Windows.UI.Xaml.Controls.Primitives.Thumb element2 = (global::Windows.UI.Xaml.Controls.Primitives.Thumb)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Thumb)element2).DragDelta += this.OnThumbDragDelta;
                }
                break;
            case 3: // MainPage.xaml line 38
                {
                    global::Windows.UI.Xaml.Controls.Primitives.Thumb element3 = (global::Windows.UI.Xaml.Controls.Primitives.Thumb)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Thumb)element3).DragDelta += this.OnThumbDragDelta;
                }
                break;
            case 4: // MainPage.xaml line 47
                {
                    global::Windows.UI.Xaml.Controls.Primitives.Thumb element4 = (global::Windows.UI.Xaml.Controls.Primitives.Thumb)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Thumb)element4).DragDelta += this.OnThumbDragDelta;
                }
                break;
            case 5: // MainPage.xaml line 56
                {
                    global::Windows.UI.Xaml.Controls.Primitives.Thumb element5 = (global::Windows.UI.Xaml.Controls.Primitives.Thumb)(target);
                    ((global::Windows.UI.Xaml.Controls.Primitives.Thumb)element5).DragDelta += this.OnThumbDragDelta;
                }
                break;
            case 6: // MainPage.xaml line 60
                {
                    this.lrTranslate = (global::Windows.UI.Xaml.Media.TranslateTransform)(target);
                }
                break;
            case 7: // MainPage.xaml line 51
                {
                    this.llTranslate = (global::Windows.UI.Xaml.Media.TranslateTransform)(target);
                }
                break;
            case 8: // MainPage.xaml line 42
                {
                    this.urTranslate = (global::Windows.UI.Xaml.Media.TranslateTransform)(target);
                }
                break;
            case 9: // MainPage.xaml line 33
                {
                    this.ulTranslate = (global::Windows.UI.Xaml.Media.TranslateTransform)(target);
                }
                break;
            case 10: // MainPage.xaml line 25
                {
                    this.matrixProjection = (global::Windows.UI.Xaml.Media.Matrix3DProjection)(target);
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

