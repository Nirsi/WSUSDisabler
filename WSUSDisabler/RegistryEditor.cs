using System;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WSUSDisabler
{
    public class RegistryEditor
    {
        private readonly RegistryKey _registryKey;
        private RegistryKey _backupKey;
        private RegistryKey _workKey;

        private const string MasterKey = @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate";
        private const string WorkKey = @"AU";
        private const string BackupName = @"BackUp";

        public RegistryEditor()
        {
            _registryKey = Registry.CurrentUser.OpenSubKey(MasterKey, true);

        }

        public bool IsWsusUp()
        {
            return _registryKey != null;
        }
        
        public int GetKeyValue()
        {
            return Convert.ToInt32(_registryKey.GetValue("UseWUServer"));
        }

        /*    potentially deprecated
         
        public void EnableWsus()
        {
            _registryKey.SetValue("UseWUServer", "1", RegistryValueKind.DWord);
        }

        public void DisableWsus()
        {
            _registryKey.SetValue("UseWUServer", "0", RegistryValueKind.DWord);
        }
        
        

        public void SwitchWsus(int value)
        {
            _registryKey.SetValue("UseWUServer", value.ToString(), RegistryValueKind.DWord);

            _registryKey.Flush();
        }
        
        */

        public void BackupCleanUp()
        {
            if (_backupKey != null)
            {
                _backupKey.Dispose();
                _registryKey.DeleteSubKeyTree(BackupName);
            }
        }

        public void MakeBackup()
        {

            //TODO: Need refactoring!
            _registryKey.CreateSubKey(BackupName);
            _backupKey = _registryKey.OpenSubKey(BackupName, true);
            _workKey = _registryKey.OpenSubKey(WorkKey, true);

            foreach (var valueName in  _registryKey.OpenSubKey(WorkKey).GetValueNames())
            {
                var value = _workKey.GetValue(valueName);
                var valueKind = _workKey.GetValueKind(valueName);
                _backupKey.SetValue(valueName, value, valueKind);
            }
        }

        public void RemoveWorkKey()
        {
            _registryKey.DeleteSubKeyTree(WorkKey);
        }

        public void RestoreWorkKey()
        {
            _registryKey.CreateSubKey(WorkKey);
            var _workKey = _registryKey.OpenSubKey(WorkKey, true);
            foreach (var valueName in _registryKey.OpenSubKey(BackupName).GetValueNames())
            {
                var value = _backupKey.GetValue(valueName);
                var valueKind = _backupKey.GetValueKind(valueName);
                _workKey.SetValue(valueName, value, valueKind);
            }
        }

        public bool WsusCheckState()
        {
            return _registryKey.OpenSubKey(WorkKey) != null;
        }
    }
}