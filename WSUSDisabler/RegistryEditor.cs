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
            _registryKey = Registry.LocalMachine.OpenSubKey(MasterKey, true);

        }

        public bool IsWsusUp()
        {
            return _registryKey != null;
        }
        
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
            
            _registryKey.CreateSubKey(BackupName);
            _backupKey = _registryKey.OpenSubKey(BackupName, true);
            _workKey = _registryKey.OpenSubKey(WorkKey, true);

            foreach (var valueName in  _workKey.GetValueNames())
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
            if (_registryKey == null) return;

            _registryKey.CreateSubKey(WorkKey);
            var _workKey = _registryKey.OpenSubKey(WorkKey, true);
            foreach (var valueName in _backupKey.GetValueNames())
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