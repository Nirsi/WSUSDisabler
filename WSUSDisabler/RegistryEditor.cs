using System;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace WSUSDisabler
{
    public class RegistryEditor
    {
        private readonly RegistryKey _registryKey;

        public RegistryEditor()
        {
            _registryKey =
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", true);
        }

        public bool IsWsusUp()
        {
            if (_registryKey != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetKeyValue()
        {
            return Convert.ToInt32(_registryKey.GetValue("UseWUServer"));
        }

        public void EnableWsus()
        {
            _registryKey.SetValue("UseWUServer", "1", RegistryValueKind.DWord);
        }

        public void DisableWsus()
        {
            _registryKey.SetValue("UseWUServer", "0", RegistryValueKind.DWord);
        }
    }
}
