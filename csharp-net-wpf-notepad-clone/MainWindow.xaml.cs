using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace csharp_net_wpf_notepad_clone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool match = true;

        string filePath = "";
        string titleName = "";
        string documentContent = "";
        
        private string DocumentContent
        {
            get => documentContent;
            set => documentContent = value;
        }

        private string TitleName
        {
            get => titleName;
            set => titleName = value;
        }

        private string FilePath
        {
            get => filePath;
            set => filePath = value;
        }

        private bool Match
        {
            get => match;
            set => match = value;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_FileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if(ofd.FileName != null)
            {
                FilePath = ofd.FileName;
                TitleName = ofd.SafeFileName;
                Match = true;

                StreamReader FileReader = new StreamReader(FilePath);
                DocumentContent = FileReader.ReadToEnd();
                TextArea.Text = DocumentContent;
                FileReader.Close();
            }
        }
        
        private void SaveDocument()
        {
            if(FilePath != "")
            {
                StreamWriter SaveFileStream = new StreamWriter(FilePath);

                DocumentContent = TextArea.Text;

                SaveFileStream.Write(DocumentContent);

                SaveFileStream.Close();
            }
            else
            {
                SaveAs();
            }
        }

        private void SaveAs()
        { 
        
        }

        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Open_FileDialog();
        }

        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }
    }
}