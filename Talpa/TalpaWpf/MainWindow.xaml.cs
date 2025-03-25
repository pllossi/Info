﻿using System;
using System.Windows;
using System.Windows.Controls;
using Talpa;

namespace TalpaWpf
{
    public partial class MainWindow : Window
    {
        private CampoDaGioco campoDaGioco;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreaCampo_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DimensioneTextBox.Text, out int dimensione))
            {
                campoDaGioco = new CampoDaGioco(dimensione);
                GeneraCampo(dimensione);
                RigiocaButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Inserisci una dimensione valida.");
            }
        }

        private void GeneraCampo(int dimensione)
        {
            CampoGrid.Children.Clear();
            CampoGrid.RowDefinitions.Clear();
            CampoGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < dimensione; i++)
            {
                CampoGrid.RowDefinitions.Add(new RowDefinition());
                CampoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < dimensione; i++)
            {
                for (int j = 0; j < dimensione; j++)
                {
                    Button button = new Button
                    {
                        Content = "",
                        Tag = (i, j)
                    };
                    button.Click += Button_Click;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    CampoGrid.Children.Add(button);
                }
            }
            Random coord = new Random();
            campoDaGioco.PosizionaTalpa(coord.Next(0, dimensione), coord.Next(0, dimensione));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is (int x, int y))
            {
                bool trovato = campoDaGioco.Tentativo(x, y);
                if (trovato)
                {
                    CampoGrid.Children.Clear();
                    MessageBox.Show($"Hai vinto! Talpa trovata in {x},{y} in {campoDaGioco.GetTentativi()} tentativi!");
                    RigiocaButton.Visibility = Visibility.Visible;
                }
                else
                {
                    button.Content = "X";
                    MessageBox.Show($"Nessuna talpa in {x},{y}. Tentativi: {campoDaGioco.GetTentativi()}");
                }
            }
        }

        private void Rigioca_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DimensioneTextBox.Text, out int dimensione))
            {
                campoDaGioco = new CampoDaGioco(dimensione);
                GeneraCampo(dimensione);
                RigiocaButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Inserisci una dimensione valida.");
            }
        }
    }
}
