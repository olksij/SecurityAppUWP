﻿#pragma checksum "D:\Alex\Visual\Security\Security\Health.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F249E5086CF4FB90DDE98DAC5F411AA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Security
{
    partial class Health : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Health.xaml line 12
                {
                    this.RectangleAcrylic = (global::Windows.UI.Xaml.Shapes.Rectangle)(target);
                }
                break;
            case 3: // Health.xaml line 17
                {
                    this.txtBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.txtBlock).SelectionChanged += this.txtBlock_SelectionChanged;
                }
                break;
            case 4: // Health.xaml line 18
                {
                    this.txtBlockD = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.txtBlockD).SelectionChanged += this.txtBlock_SelectionChanged;
                }
                break;
            case 5: // Health.xaml line 19
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.ToHome1;
                }
                break;
            case 6: // Health.xaml line 22
                {
                    this.CheckButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.CheckButton).Click += this.CheckButton_Click;
                }
                break;
            case 7: // Health.xaml line 24
                {
                    this.progresB = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 8: // Health.xaml line 20
                {
                    this.HomeIcon = (global::Windows.UI.Xaml.Controls.FontIcon)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

