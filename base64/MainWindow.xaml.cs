﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace base64
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private bool current_mood = false;

      public MainWindow()
      {
         InitializeComponent();
      }

      private void change_mode_Click(object sender, RoutedEventArgs e)
      {
         input_txt.Text = "";
         output_txt.Text = "";
         mode.Content = current_mood ? "Encoding..." : "Decoding...";
         current_mood = !current_mood;
      }

      private void input_txt_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (!current_mood)
         {
            output_txt.Foreground = Brushes.Black;
            byte[] bytes = Encoding.ASCII.GetBytes(input_txt.Text);
            output_txt.Text = Convert.ToBase64String(bytes);
         }

         else if (current_mood)
         {
            try
            {
               output_txt.Foreground = Brushes.Black;
               output_txt.BorderBrush = Brushes.Gray;
               byte[] temp_backToBytes = Convert.FromBase64String(input_txt.Text);
               output_txt.Text = Encoding.UTF8.GetString(temp_backToBytes);
            }
            catch (Exception)
            {
               output_txt.Foreground = Brushes.Red;
               output_txt.BorderBrush = Brushes.Red;
               output_txt.Text = "`Error`";
            }
         }
      }
   }
}
