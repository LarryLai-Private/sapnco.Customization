using System;
using System.Windows;

namespace sapnco.Customization.TestTool
{
    using BAPI_MATERIAL_STOCK_REQ_LIST;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected SAP_RFC_ConnectBase connection=> new Connect();

        class Connect : SAP_RFC_ConnectBase
        {
            protected override string SystemNumber => "";
            protected override string AppServerHost => "";
            protected override string Client => "";
            protected override string User => "";
            protected override string Password => "";
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string materialNO = MaterialNO.Text;
            string plant = Plant.Text;
            string mrp_Area = MRP_Area.Text;

            var result = new BAPI_MATERIAL_STOCK_REQ_LIST(connection).Query_Like_MD04(materialNO, plant, mrp_Area);
            DataGrid_Result.ItemsSource = result.DefaultView;
        }
    }
}
