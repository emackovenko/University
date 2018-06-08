using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;
using Processing.Document;

namespace WpfExtensions.Controls
{
    /// <summary>
    /// Логика взаимодействия для ExcelDocumentViewer.xaml
    /// </summary>
    public partial class OpenXmlDocumentViewer : UserControl
    {
        public OpenXmlDocumentViewer()
        {
            InitializeComponent();
        }

        static OpenXmlDocumentViewer()
        {
            DocumentProperty = DependencyProperty.Register("Document", typeof(OpenXmlDocument), typeof(OpenXmlDocumentViewer),
                new PropertyMetadata(new PropertyChangedCallback(OnDocumentChanged)));
        }

        static DependencyProperty DocumentProperty;

        public OpenXmlDocument Document
        {
            get
            {
                return (OpenXmlDocument)GetValue(DocumentProperty);
            }
            set
            {
                SetValue(DocumentProperty, value);
            }
        }

        static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var doc = (OpenXmlDocument)e.NewValue;
            var invoker = (OpenXmlDocumentViewer)d;
            if (doc != null)
            {
                invoker.docViewer.Document = doc.XpsDocument.GetFixedDocumentSequence();
            }
        }

        public void OpenInOutsourceEditor()
        {
            Process.Start(Document.OriginalFileName);
        }

        bool OpenInWordCanExecute
        {
            get
            {
                bool result = false;
                if (Document != null)
                {
                    if (Document.DocumentType == OpenXmlDocumentType.Document)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        bool OpenInExcelCanExecute
        {
            get
            {
                bool result = false;
                if (Document != null)
                {
                    if (Document.DocumentType == OpenXmlDocumentType.Spreadsheet)
                    {
                        result = true;
                    }
                }
                return result;
            }
        }

        private void btnWord_Click(object sender, RoutedEventArgs e)
        {
            OpenInOutsourceEditor();
        }
    }
}
