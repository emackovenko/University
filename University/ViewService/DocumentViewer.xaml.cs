﻿using System;
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
using System.Windows.Shapes;
using Processing.Document;

namespace University.ViewService
{
    /// <summary>
    /// Логика взаимодействия для DocumentViewer.xaml
    /// </summary>
    public partial class DocumentViewer : Window
    {
        public DocumentViewer(OpenXmlDocument document)
        {
            InitializeComponent();
            docArea.Document = document;
        }
    }
}
