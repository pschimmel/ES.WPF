﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ES.Tools.Adorners;
using ES.Tools.TestApp.ViewModels;

namespace ES.Tools.TestApp.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private DataTemplateAdorner dataTemplateAdorner;
    private ControlAdorner controlAdorner;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void ShowDataTemplateAdornerButton_Click(object sender, RoutedEventArgs e)
    {
      if (dataTemplateAdorner != null)
      {
        dataTemplateAdorner.Dispose();
        dataTemplateAdorner = null;
      }
      else
      {
        var vm = new DataTemplateAdornerViewModel { Text = "Test" };
        var template = (DataTemplate)TryFindResource("YellowCircleText");
        dataTemplateAdorner = new DataTemplateAdorner(vm, template, ShowDataTemplateAdornerButton);
      }
    }

    private void ShowControlAdornerButton_Click(object sender, RoutedEventArgs e)
    {
      if (controlAdorner == null)
      {
        var progressBar = new ProgressBar{ Value = 20, Width = ShowControlAdornerButton.ActualWidth, Height = 10 };
        controlAdorner = new ControlAdorner(ShowControlAdornerButton, progressBar);
      }
      else
      {
        controlAdorner.Dispose();
        controlAdorner = null;
      }
    }

    private void AdornersWrapPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if (dataTemplateAdorner != null)
      {
        var point = Mouse.GetPosition(ShowDataTemplateAdornerButton);
        dataTemplateAdorner.UpdatePosition(point.X - dataTemplateAdorner.ActualWidth / 2, point.Y - dataTemplateAdorner.ActualHeight / 2);
      }
    }

    private void AdornersWrapPanel_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (dataTemplateAdorner != null)
      {
        dataTemplateAdorner.Dispose();
        dataTemplateAdorner = null;
      }
    }
  }
}
