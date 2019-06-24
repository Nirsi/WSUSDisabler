using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace WSUSDisabler
{
    public class ServiceManager
    {
        private ServiceController _serviceController;
        private string ServiceName;

        public ServiceManager(string serviceName)
        {
            _serviceController = new ServiceController();
            this.ServiceName = serviceName;
            _serviceController.ServiceName = ServiceName;
        }

        public string CheckStatus()
        {
            _serviceController = new ServiceController();
            _serviceController.ServiceName = ServiceName;
            return _serviceController.Status.ToString();
        }

        public string StartService()
        {
            try
            {
                _serviceController.Start();
                _serviceController.WaitForStatus(ServiceControllerStatus.Running);
                return _serviceController.Status.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public string StopService()
        {
            try
            {
                _serviceController.Stop();
                _serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                return _serviceController.Status.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }
    }
}