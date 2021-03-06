﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;

namespace TCC.Converters
{

    public class HarrowholdBossesVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

namespace TCC.Windows
{

    public partial class BossGageWindow : Window, INotifyPropertyChanged
    {
        bool harrowholdMode;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public bool HarrowholdMode
        {
            get
            {
                return harrowholdMode;
            }
            set
            {
                if(harrowholdMode != value)
                {
                    harrowholdMode = value;
                    HarrowholdModeChanged(value);
                    NotifyPropertyChanged("HarrowholdMode");
                }
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public BossGageWindow()
        {
            InitializeComponent();

            Bosses.DataContext = EntitiesManager.CurrentBosses;
            Bosses.ItemsSource = EntitiesManager.CurrentBosses;

            HHBosses.DataContext = this;

            HarrowholdMode = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            FocusManager.MakeUnfocusable(hwnd);
            FocusManager.HideFromToolBar(hwnd);
            Opacity = 0;
            Topmost = true;

            ContextMenu = new ContextMenu();
            var HideButton = new MenuItem() { Header = "Hide" };
            HideButton.Click += (s, ev) =>
            {
                this.Visibility = Visibility.Collapsed;
            };
            ContextMenu.Items.Add(HideButton);


        }

        void HarrowholdModeChanged(bool hh)
        {
            Dispatcher.Invoke(() =>
            {
                if (hh)
                {
                    Bosses.ItemsSource = null;
                }
                else
                {
                    Bosses.ItemsSource = EntitiesManager.CurrentBosses;
                }
            });
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu.IsOpen = true;
        }
    }
}

