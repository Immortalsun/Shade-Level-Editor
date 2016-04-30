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
using ShadeGameLevelEditor.ViewModel;

namespace ShadeGameLevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EditorViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new EditorViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void DrawCanvas_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DrawCanvas_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _viewModel.Zoom(e.Delta);
        }
    }
}
