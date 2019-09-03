using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesApp.View.UserControls
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteControl : UserControl
    {


        public Model.Note Note
        {
            get { return (Model.Note)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Model.Note), typeof(NoteControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteControl nc = d as NoteControl;
            if (nc != null)
            {
                nc.titleTextBlock.Text = (e.NewValue as Model.Note).Titel;
                nc.editedTextBlock.Text = (e.NewValue as Model.Note).UpdatedTime.ToShortDateString();
                nc.contentTextBlock.Text = (e.NewValue as Model.Note).Titel;
            }
        }

        public NoteControl()
        {
            InitializeComponent();
        }
    }
}
