using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Protocol.Common;
using SingleRClient;

namespace XamlVectorGraphicEditor
{
    /// <summary>
    /// Логика взаимодействия для SelectDocument.xaml
    /// </summary>
    public partial class SelectDocument : Window
    {

        private readonly ObservableCollection<DocumentHeader> _docs = new ObservableCollection<DocumentHeader>();

        public SelectDocument()
        {
            InitializeComponent();

            txtDocName.IsEnabled = false;
            btnOk.IsEnabled = false;

            InitDocs();
        }

        public async void InitDocs()
        {
            Title = "Получение списка документов...";
            var items = await Context.DataProvider().GetDocumentsListAsync(Context.UserName);
            foreach (var item in items.Documents) {
                _docs.Add(item);
            }
            Title = "Выбор документа";

            lbDocs.ItemsSource = _docs;
        }

        public DocumentHeader SelectedDoc { get => lbDocs.SelectedItem as DocumentHeader; }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public bool IsNewDoc { get => chNewDoc.IsChecked ?? false;  }
        public string NewDocName { get => txtDocName.Text; }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void chNewDoc_Checked(object sender, RoutedEventArgs e)
        {
            lbDocs.IsEnabled = !(chNewDoc.IsChecked ?? false);
            txtDocName.IsEnabled = chNewDoc.IsChecked ?? false;
            UpdateButtonsEnability();
        }

        private void txtDocName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonsEnability();
        }

        private void UpdateButtonsEnability()
        {
            btnOk.IsEnabled = (lbDocs.IsEnabled && lbDocs.SelectedItem != null)
                || (txtDocName.IsEnabled && !string.IsNullOrEmpty(txtDocName.Text));
        }

        private void lbDocs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonsEnability();
        }
    }
}
