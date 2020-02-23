﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using g.FIDO2.CTAP.HID;

namespace xClient
{
    /// <summary>
    /// Page23.xaml の相互作用ロジック
    /// </summary>
    public partial class Page23 : Page
    {
        private static Page31 page = null;

        public Page23()
        {
            InitializeComponent();
        }

        private async void GetAssertion_Click(object sender, RoutedEventArgs e)
        {
            var app = (MainWindow)Application.Current.MainWindow;
            var ass = await app.Authenticate(new HIDAuthenticatorConnector(), app.RPID, app.Challenge, app.CredentialID,this.TextPIN.Text);
            if (ass == null) return;

            if (page == null) page = new Page31(ass);
            this.NavigationService.Navigate(page);
        }
    }
}
