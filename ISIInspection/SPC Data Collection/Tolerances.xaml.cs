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
            ToleranceMetricX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Metric).ToString();
            ToleranceMetricX_X.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Metric).ToString();
            ToleranceMetricX_XX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Metric).ToString();
            ToleranceMetricX_XXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Metric).ToString();
            ToleranceMetricX_XXXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Metric).ToString();
            ToleranceMetricAngular.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Metric).ToString();

            ToleranceInchX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X, SPCEngine.ToleranceUnits.Inch).ToString();
            ToleranceInchX_X.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_X, SPCEngine.ToleranceUnits.Inch).ToString();
            ToleranceInchX_XX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XX, SPCEngine.ToleranceUnits.Inch).ToString();
            ToleranceInchX_XXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXX, SPCEngine.ToleranceUnits.Inch).ToString();
            ToleranceInchX_XXXX.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.X_XXXX, SPCEngine.ToleranceUnits.Inch).ToString();
            ToleranceInchAngular.Text = App.Engine.DefaultTolerances.GetDefaultTolerance(SPCEngine.ToleranceType.Angular, SPCEngine.ToleranceUnits.Inch).ToString();
        }

        void Save()
        {
            decimal toleranceMetricX = Convert.ToDecimal(ToleranceMetricX.Text);
            decimal toleranceMetricX_X = Convert.ToDecimal(ToleranceMetricX_X.Text);
            decimal toleranceMetricX_XX = Convert.ToDecimal(ToleranceMetricX_XX.Text);
            decimal toleranceMetricX_XXX = Convert.ToDecimal(ToleranceMetricX_XXX.Text);
            decimal toleranceMetricX_XXXX = Convert.ToDecimal(ToleranceMetricX_XXXX.Text);
            decimal toleranceMetricAngular = Convert.ToDecimal(ToleranceMetricAngular.Text);

            decimal toleranceInchX = Convert.ToDecimal(ToleranceInchX.Text);
            decimal toleranceInchX_X = Convert.ToDecimal(ToleranceInchX_X.Text);
            decimal toleranceInchX_XX = Convert.ToDecimal(ToleranceInchX_XX.Text);
            decimal toleranceInchX_XXX = Convert.ToDecimal(ToleranceInchX_XXX.Text);
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
