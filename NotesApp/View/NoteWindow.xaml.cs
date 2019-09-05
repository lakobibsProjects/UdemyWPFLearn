using NotesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace NotesApp.View
{
    /// <summary>
    /// Логика взаимодействия для NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        NotesVM viewModel;

        public NoteWindow()
        {
            InitializeComponent();
      
            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;

            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 28, 48, 72 };
            fontSizeComboBox.ItemsSource = fontSizes;
            viewModel = this.Resources["vm"] as NotesVM;
            container.DataContext = viewModel;
            viewModel.SelectedNotedChanged += ViewModel_SelectionChanged;

        }

        private void ViewModel_SelectionChanged(object sender, EventArgs e)
        {
            contentRichTextBox.Document.Blocks.Clear();
            try
            {
                if (viewModel.SelectedNote != null)
                {
                    if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileLocation))
                    {                                                
                        FileStream fileStream = new FileStream(viewModel.SelectedNote.FileLocation, FileMode.Open);
                        TextRange range = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                        range.Load(fileStream, DataFormats.Rtf);
                    }

                }
            }
            catch (Exception) { } //TODO handle this Exception

        }

        private void ContentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var selectedWeight = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedWeight.Equals(FontWeights.Bold));

            var selectedStyle = contentRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicButton.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));

            var selecteDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = (selecteDecoration != DependencyProperty.UnsetValue) && (selecteDecoration.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();

            int ammountCharacters = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;
            statusTextBlock.Text = $"Document length: {ammountCharacters} characters"; 
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
        }
        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontStyles.Italic);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontStyles.Normal);
        }
        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
            {
                TextDecorationCollection td;
                (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out td);
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, td);
            }
        }

        private void ContentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedWeight = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            boldButton.IsChecked = (selectedWeight != DependencyProperty.UnsetValue) && (selectedWeight.Equals(FontWeights.Bold));

            var selectedStyle = contentRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            italicButton.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));

            var selecteDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            underlineButton.IsChecked = (selecteDecoration != DependencyProperty.UnsetValue) && (selecteDecoration.Equals(TextDecorations.Underline));

            fontFamilyComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }

        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontFamilyComboBox.SelectedItem != null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }

        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (string.IsNullOrEmpty(App.UserId))
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileLocation = rtfFile;

            FileStream fileStream = new FileStream(rtfFile, FileMode.Create);
            TextRange range = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
            range.Save(fileStream, DataFormats.Rtf);
            
            viewModel.UpdateSelectedNote();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
