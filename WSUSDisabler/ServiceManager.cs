using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace WSUSDisabler
{
    public class ServiceManager
    {
        private ServiceController _serviceController;
        private readonly string _serviceName;

        public ServiceManager(string serviceName)
        {
            _serviceController = new ServiceController();
            this._serviceName = serviceName;
            _serviceController.ServiceName = _serviceName;
        }

        public string CheckStatus()
        {
            _serviceController = new ServiceController {ServiceName = _serviceName};
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