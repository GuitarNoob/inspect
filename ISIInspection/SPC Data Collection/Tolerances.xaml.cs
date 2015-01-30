using ISIInspection.Models;
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
using System.Windows.Shapes;

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for Tolerances.xaml
    /// </summary>
    public partial class Tolerances : Window
    {

        public Tolerances()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadValues()
        {
            ToleranceMetricX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Metric).ToString("0.0");
            ToleranceMetricX_X.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Metric).ToString("0.0");
            ToleranceMetricX_XX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Metric).ToString("0.00");
            ToleranceMetricX_XXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Metric).ToString("0.000");
            ToleranceMetricX_XXXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Metric).ToString("0.0000");
            ToleranceMetricAngular.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Metric).ToString();

            ToleranceInchX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Inch).ToString("0.0");
            ToleranceInchX_X.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Inch).ToString("0.0");
            ToleranceInchX_XX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Inch).ToString("0.00");
            ToleranceInchX_XXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Inch).ToString("0.000");
            ToleranceInchX_XXXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Inch).ToString("0.0000");
            ToleranceInchAngular.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Inch).ToString();
        }

        void Save()
        {
            decimal toleranceMetricX = Math.Round(Convert.ToDecimal(ToleranceMetricX.Text), 1);
            decimal toleranceMetricX_X = Math.Round(Convert.ToDecimal(ToleranceMetricX_X.Text), 1);
            decimal toleranceMetricX_XX = Math.Round(Convert.ToDecimal(ToleranceMetricX_XX.Text), 2);
            decimal toleranceMetricX_XXX = Math.Round(Convert.ToDecimal(ToleranceMetricX_XXX.Text), 3);
            decimal toleranceMetricX_XXXX = Convert.ToDecimal(ToleranceMetricX_XXXX.Text);
            decimal toleranceMetricAngular = Convert.ToDecimal(ToleranceMetricAngular.Text);

            decimal toleranceInchX = Math.Round(Convert.ToDecimal(ToleranceInchX.Text), 1);
            decimal toleranceInchX_X = Math.Round(Convert.ToDecimal(ToleranceInchX_X.Text), 1);
            decimal toleranceInchX_XX = Math.Round(Convert.ToDecimal(ToleranceInchX_XX.Text), 2);
            decimal toleranceInchX_XXX = Math.Round(Convert.ToDecimal(ToleranceInchX_XXX.Text), 3);
            decimal toleranceInchX_XXXX = Convert.ToDecimal(ToleranceInchX_XXXX.Text);
            decimal toleranceInchAngular = Convert.ToDecimal(ToleranceInchAngular.Text);

            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Metric, toleranceMetricX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Metric, toleranceMetricX_X);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Metric, toleranceMetricX_XX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Metric, toleranceMetricX_XXX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Metric, toleranceMetricX_XXXX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Metric, toleranceMetricAngular);

            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Inch, toleranceInchX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Inch, toleranceInchX_X);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Inch, toleranceInchX_XX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Inch, toleranceInchX_XXX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Inch, toleranceInchX_XXXX);
            App.Engine.DefaultTolerances.WriteTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Inch, toleranceInchAngular);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadValues();
        }
    }
}
