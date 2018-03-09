using System;
using System.Windows;
using System.Windows.Media;
using IceCreamMonitorMVP.Model;

namespace IceCreamMonitorMVP
{
    public class MainPresenter
    {
        private IceCreamMonitor iceCreamMonitor;
        private IMainWiew view;

        public MainPresenter(IMainWiew view, IceCreamMonitor iceCreamMonitor)
        {
            this.view = view;
            this.iceCreamMonitor = iceCreamMonitor;
            this.iceCreamMonitor.newStationId += iceCreamMonitor_newStationId;
            InitializeView();
        }

        void iceCreamMonitor_newStationId(object sender, EventArgs e)
        {
            view.InitMeasurements(iceCreamMonitor.GetStationIds());
        }

        internal void InitializeView()
        {
            view.SetTarget(iceCreamMonitor.Target.ToString());
            view.InitMeasurements(iceCreamMonitor.GetStationIds());
        }

        public void ChangeStation(string id)
        {
            view.SetStation(id);

            foreach (var VARIABLE in iceCreamMonitor.GetMeasurements()) //find the measurement
            {
                if (id == VARIABLE.StationId)
                {
                    
                    view.SetActual(VARIABLE.Actual.ToString());
                    ActualChanged(VARIABLE.Actual.ToString());
                }
            }

        }

        public void NewMeasurement(string station, System.DateTime dateTime, string actual)
        {
            int acctual = int.Parse(actual);
            iceCreamMonitor.AddMeasurement(station,dateTime,acctual);
            view.SetActual(actual);
            view.SetStation(station);
            view.SetDate(dateTime);
        }

        public bool Closing()
        {
            iceCreamMonitor.SaveMeasurements();

            App.Current.Shutdown();
            return true;
        }

        public void ActualChanged(string tbxActualText)
        {
            int actualValue = int.Parse(tbxActualText);
            var varianceRange = VarianceRange.normal;

            string variance = iceCreamMonitor.CalculateVariance(actualValue, out varianceRange).ToString();
            view.SetActual(tbxActualText);
            view.SetVariance(variance);

            if(int.Parse(variance) < 0)
                view.SetVarianceColor(Colors.Red);
            else
            {
                view.SetVarianceColor(Colors.Aquamarine);
            }
        }

        public void DateChanged(string id, DateTime? dpDateSelectedDate)
        {
            DateTime dateTime = dpDateSelectedDate.Value;
            
            if (iceCreamMonitor.ValidateDate(dateTime, out id))
            {
                view.SetDate(dateTime);
                foreach (var VARIABLE in iceCreamMonitor.GetMeasurements())
                {
                    if (id == VARIABLE.StationId) //the measurement exsists
                    {
                        view.SetActual(VARIABLE.Actual.ToString());
                    }
                }
            }

            else
            {
                view.ShowError(id);
            }

        }
    }
}
