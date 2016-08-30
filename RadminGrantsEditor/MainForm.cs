using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.Win32;
using System.DirectoryServices;
using System.Xml;
using Witchcraft;

namespace RadminGrantsEditor
{
    public partial class MainForm : Form
    {
        public SplashForm splash = null;
        private byte[] _ntusers_data = null;
        private string _remotename = string.Empty;
        private string _login = null;
        private string _password = null;
        public bool _IsBatch = false;
        public string RemoteName
        {
            get { return _remotename; }
            set { 
                _remotename = value;
                tbComputer.Text = value;
                btnConnect_Click(null, null);
            }
        }
        public bool WriteTo(string RemoteName)
        {
            _remotename = RemoteName;
            tbComputer.Text = RemoteName;
            return Connect(false);
        }
        public string LastTextMessage;
        private string _domain;
        private bool _is64bit = false;
        private NTUsers _remoteusers = new NTUsers();
//        private bool _NTAuthEnabled = false;
        private bool _rightschanged;
        private bool _paramschanged;

        //Текущие редактируемые права
        private string _currentsid=null;

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        
        public MainForm()
        {
            InitializeComponent();
        }

        //Проверка доступности ПК
        private int TestConnect(string Name)
        {
            int result = -1;
            Ping ping = new Ping();
            try
            {
                if (ping.Send(Name).Status == IPStatus.Success)
                {
                    result = 0;
                }
            }
            catch { }
            return result;
        }

        //Проверяем доступность к удаленному реестру
        private int OpenRemoteReg()
        {
            int result =-1;
            string _log = _login;
            string _pass = _password;

            RegistryKey _key = null;
            try
            {
                _key = RegistryKey.OpenRemoteBaseKey(
                    RegistryHive.LocalMachine, _remotename).OpenSubKey(
                    "SOFTWARE");
                result = 0;
                _login = _log;
                _password = _pass;
            }
            catch (Exception ee)
            {
                MessageBox.Show(string.Format("(OpenRemoteReg): '{0}' - {1}", _remotename, ee.Message));
            }
            finally
            {
                if (_key != null)
                    _key.Close();
            }
            return result;
        }

        private Int32 ByteArrayToInt32(byte[] Input)
        {
            Int32 result = -1;
            if (Input!=null && Input.Length <= 4)
            {
                result = (Int32)Input[0] +
                    (Input[1] << 8) +
                    (Input[2] << 16) +
                    (Input[3] << 24);
            }
            return result;
        }

        private byte[] BoolToByteArray(bool value)
        {
            byte[] result = new byte[4];
            result[0] = (byte)((value) ? 1 : 0);
            return result;

        }

        private byte[] Int32ToByteArray(int value)
        {
            byte[] result = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = (byte)(value & 255);
                value = value >> 8;
            }
            return result;
        }
        private int WriteRemoteReg()
        {
            int result = -1;
            RegistryKey _key = null;
            try
            {
                //Попытка чтения из ветки 32 битной системы
                _key = RegistryKey.OpenRemoteBaseKey(
                    RegistryHive.LocalMachine, _remotename).OpenSubKey(@"SOFTWARE\Radmin\v3.0\Server\Parameters");

                //if (ByteArrayToInt32((byte[])_key.GetValue("Port"))==-1)

                //NtUsers = (byte[])_key.GetValue("1", null);
                if ((_key != null) && (ByteArrayToInt32((byte[])_key.GetValue("Port")) != -1))
                {
                    result = 0;
                    _is64bit = false;
                }
            }
            catch { }
            finally
            {
                if (_key != null)
                    _key.Close();
            }
            Application.DoEvents();
            if (result == -1)
            {
                try
                {
                    //Попытка чтения из ветки 64 битной системы
                    _key = RegistryKey.OpenRemoteBaseKey(
                        RegistryHive.LocalMachine, _remotename).OpenSubKey(@"SOFTWARE\Wow6432Node\Radmin\v3.0\Server\Parameters");
                    if ((_key != null) && (ByteArrayToInt32((byte[])_key.GetValue("Port")) != -1))
                    {
                        result = 0;
                        _is64bit = true;
                    }
                }
                catch { }

                finally
                {
                    if (_key != null)
                        _key.Close();
                }
            }
            if (result == -1) return result;
            Application.DoEvents();
            string _regpath = (_is64bit) ? @"SOFTWARE\Wow6432Node\Radmin\v3.0\Server\Parameters" : @"SOFTWARE\Radmin\v3.0\Server\Parameters";
            try
            {
                _key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, _remotename).OpenSubKey(_regpath,true);
                //NTAuthEnabled
                try
                {
                    _key.SetValue("NTAuthEnabled", BoolToByteArray(cbNTAuthEnabled.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableAudio
                try
                {
                    _key.SetValue("DisableAudio", BoolToByteArray(cbDisableAudio.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableChat
                try
                {
                    _key.SetValue("DisableChat", BoolToByteArray(cbDisableChat.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableFile
                try
                {
                    _key.SetValue("DisableFile", BoolToByteArray(cbDisableFile.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableMessage
                try
                {
                    _key.SetValue("DisableMessage", BoolToByteArray(cbDisableMessage.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableRedirect
                try
                {
                    _key.SetValue("DisableRedirect", BoolToByteArray(cbDisableRedirect.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableScreen
                try
                {
                    _key.SetValue("DisableScreen", BoolToByteArray(cbDisableScreen.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableShutdown
                try
                {
                    _key.SetValue("DisableShutdown", BoolToByteArray(cbDisableShutdown.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableTelnet
                try
                {
                    _key.SetValue("DisableTelnet", BoolToByteArray(cbDisableTelnet.Checked));
                }
                catch { }
                Application.DoEvents();
                //DisableView
                try
                {
                    _key.SetValue("DisableView", BoolToByteArray(cbDisableView.Checked));
                }
                catch { }
                Application.DoEvents();
                //EnableEventLog
                try
                {
                    _key.SetValue("EnableEventLog", BoolToByteArray(cbEnableEventLog.Checked));
                }
                catch { }
                Application.DoEvents();
                //EnableLogFile
                try
                {
                    _key.SetValue("EnableLogFile", BoolToByteArray(cbEnableLogFile.Checked));
                }
                catch { }
                Application.DoEvents();
                //Port
                try
                {
                    _key.SetValue("Port", Int32ToByteArray(Convert.ToInt32( tbPort.Text)));
                }
                catch { }
                Application.DoEvents();
                //TrayIconMode
                try
                {
                    _key.SetValue("TrayIconMode", Int32ToByteArray(Convert.ToInt32(tbTrayIconMode.Text)));
                }
                catch { }
                Application.DoEvents();
                //Timeout
                try
                {
                    _key.SetValue("Timeout", Int32ToByteArray(Convert.ToInt32(tbTimeout.Text)));
                }
                catch { }
            }
            catch { }
            Application.DoEvents();

            try
            {
                //Reading NTUsers
                _key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, _remotename).OpenSubKey(_regpath + @"\NtUsers",true);
                _key.SetValue("1", (byte[]) _ntusers_data);
                //_ntusers_data = (byte[])_key.GetValue("1", null);
            }
            catch { }

            return result;
        }

        private int ReadRemoteReg()
        {
            int result = -1;
            _ntusers_data = null;
            RegistryKey _key = null;
            try
            {
                //Попытка чтения из ветки 32 битной системы
                _key = RegistryKey.OpenRemoteBaseKey(
                    RegistryHive.LocalMachine, _remotename).OpenSubKey(@"SOFTWARE\Radmin\v3.0\Server\Parameters");

                //if (ByteArrayToInt32((byte[])_key.GetValue("Port"))==-1)
                
                //NtUsers = (byte[])_key.GetValue("1", null);
                if ((_key != null) && (ByteArrayToInt32((byte[])_key.GetValue("Port")) != -1))
                {
                    result = 0;
                    _is64bit = false;
                }
            }
            catch { }
            finally
            {
                if (_key != null)
                    _key.Close();
            }
            Application.DoEvents();
            if (result == -1)
            {
                try
                {
                    //Попытка чтения из ветки 64 битной системы
                    _key = RegistryKey.OpenRemoteBaseKey(
                        RegistryHive.LocalMachine, _remotename).OpenSubKey(@"SOFTWARE\Wow6432Node\Radmin\v3.0\Server\Parameters");
                    if ((_key != null) && (ByteArrayToInt32((byte[])_key.GetValue("Port")) != -1))
                    {
                        result = 0;
                        _is64bit = true;
                    }
                }
                catch { }

                finally
                {
                    if (_key != null)
                        _key.Close();
                }
            }
            if (result == -1) return result;
            Application.DoEvents();
            string _regpath = (_is64bit) ? @"SOFTWARE\Wow6432Node\Radmin\v3.0\Server\Parameters" : @"SOFTWARE\Radmin\v3.0\Server\Parameters";

            try
            {
                _key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, _remotename).OpenSubKey(_regpath);
                byte[] _bytes = null;
                //Reading NTAuthEnabled
                try
                {
                    _bytes = (byte[])_key.GetValue("NTAuthEnabled");
                }
                catch { }
                finally
                {
                    cbNTAuthEnabled.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableAudio
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableAudio");
                }
                catch { }
                finally
                {
                    cbDisableAudio.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableChat
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableChat");
                }
                catch { }
                finally
                {
                    cbDisableChat.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableFile
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableFile");
                }
                catch { }
                finally
                {
                    cbDisableFile.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableMessage
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableMessage");
                }
                catch { }
                finally
                {
                    cbDisableMessage.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableRedirect
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableRedirect");
                }
                catch { }
                finally
                {
                    cbDisableRedirect.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableScreen
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableScreen");
                }
                catch { }
                finally
                {
                    cbDisableScreen.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableShutdown
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableShutdown");
                }
                catch { }
                finally
                {
                    cbDisableShutdown.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableTelnet
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableTelnet");
                }
                catch { }
                finally
                {
                    cbDisableTelnet.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading DisableView
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("DisableView");
                }
                catch { }
                finally
                {
                    cbDisableView.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading EnableEventLog
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("EnableEventLog");
                }
                catch { }
                finally
                {
                    cbEnableEventLog.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading EnableLogFile
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("EnableLogFile");
                }
                catch { }
                finally
                {
                    cbEnableLogFile.Checked = (ByteArrayToInt32(_bytes) > 0) ? true : false;
                }
                Application.DoEvents();
                //Reading Port
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("Port");
                }
                catch { }
                finally
                {
                    tbPort.Text = Convert.ToString(ByteArrayToInt32(_bytes));
                }
                Application.DoEvents();
                //Reading TrayIconMode
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("TrayIconMode");
                }
                catch { }
                finally
                {
                    tbTrayIconMode.Text = Convert.ToString(ByteArrayToInt32(_bytes));
                }
                Application.DoEvents();
                //Reading Timeout
                _bytes = null;
                try
                {
                    _bytes = (byte[])_key.GetValue("Timeout");
                }
                catch { }
                finally
                {
                    tbTimeout.Text = Convert.ToString(ByteArrayToInt32(_bytes));
                }
            }
            catch { }
            Application.DoEvents();
            try
            {
                //Reading NTUsers
                _key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, _remotename).OpenSubKey(_regpath + @"\NtUsers");
                _ntusers_data = (byte[])_key.GetValue("1", null);
            }
            catch { }

            
            return result;
        }

        public void UpdateUsersList()
        {
            lvUsers.Items.Clear();
            foreach (NTUsersItem ntuser in _remoteusers.Items)
            {
                string _name = ntuser.Sid;
                string _grp = "";
                int icon = 0;
                if (ntuser.Name == _name)
                {
                    try
                    {
                        DirectoryEntry de;
                        if ((de = ADUserPicker.ADGetObject(ntuser.Sid)) != null)
                        {
                            _name = de.Properties["name"].Value.ToString();
                            ntuser.Name = _name;
                            ntuser.IsGroup = (de.SchemaClassName == "group") ? true : false;
                            if (ntuser.IsGroup)
                            {
                                icon = 2;
                                _grp = "Группа";
                            }
                            else
                            {
                                icon = 1;
                                _grp = "Пользователь";
                            }
                        }
                    }
                    catch { }
                }
                else
                {
                    _name = ntuser.Name;
                    if (ntuser.IsGroup)
                    {
                        icon = 2;
                        _grp = "Группа";
                    }
                    else
                    {
                        icon = 1;
                        _grp = "Пользователь";
                    }
                }
                ListViewItem lvi = new ListViewItem(_name, icon);
                lvi.Tag = ntuser.Sid;
                lvi.SubItems.Add(_grp);
                lvUsers.Items.Add(lvi);
                Application.DoEvents();
            }
        }

        /*
         * Выводит текст и в статус-бар и во всплывающее окно
         */
        private void SetStatusText(string text)
        {
            slText.Text = text;
            LastTextMessage = text;
            if (splash != null) splash.SetText(text);
        }


        /*
         * Подключение к ПК и выполнение операции чтения/записи параметров
         */
        private bool Connect(bool read)
        {
            bool result = false;
            btnConnect.Enabled = false;
            tbComputer.Enabled = false;
            SetStatusText("Подключение...");
            //slText.Text = "Подключение...";
            slIcon.Image = Properties.Resources.update;
            Application.DoEvents();
            sl64bit.Text = "";
            //_ntusers_data = null;
            btnSave.Enabled = false;
            tcRadminSettings.Enabled = false;
            if (TestConnect(tbComputer.Text) == 0)
            {
                SetStatusText("Компьютер в сети, подключение...");
                //slText.Text = "Компьютер в сети, подключение...";
                slIcon.Image = Properties.Resources.pc_on;
                _remotename = tbComputer.Text;
                Application.DoEvents();
                if (OpenRemoteReg() == 0)
                {
                    int res = -1;
                    //Читаем или записываем данные
                    if (read)
                    {
                        res = ReadRemoteReg();
                    }
                    else
                    {
                        res = WriteRemoteReg();
                    }
                    result = (res == 0) ? true : false;
                    if (res == 0)
                    {
                        sl64bit.Text = (_is64bit) ? "x64" : "x86";
                        //Было чтение или запись данных?
                        if (read)
                        {
                            if (_ntusers_data != null)
                            {
                                SetStatusText("Чтение информации из AD...");
                                //slText.Text = "Чтение информации из AD...";
                                Application.DoEvents();
                                _remoteusers.Items.Clear();
                                _remoteusers.Parse(_ntusers_data);
                                UpdateUsersList();

                                btnSave.Enabled = true;
                                tcRadminSettings.Enabled = true;
                                SetStatusText("Настройки успешно cчитаны");
                                //result = true;
                                //slText.Text = "Настройки успешно читаны";
                                //MessageBox.Show(string.Format("Успешно считано {0} байт из удаленного реестра!", _ntusers_data.Length));
                            }
                            else
                            {
                                SetStatusText("Не удалось считать настройки RAdmin");
                                //slText.Text = "Не удалось считать настройки RAdmin";
                                slIcon.Image = Properties.Resources.pc_on_truble;
                            }
                        }
                        else
                        {
                            SetStatusText("Настройки успешно записаны");
                            btnSave.Enabled = true;
                            tcRadminSettings.Enabled = true;
                        }
                    }
                    else
                    {
                        SetStatusText("Не удалось считать настройки RAdmin");
                        slIcon.Image = Properties.Resources.pc_on_truble;
                        MessageBox.Show("Настройки RAdmin не найдены в реестре удаленной машины!\r\nУдостоверьтесь, что RemoteAdministrator v.3 установлен.");
                    }
                }
                else
                {
                    SetStatusText("Нет доступа к реестру!");
                    slText.Text = "Нет доступа к реестру!";
                    slIcon.Image = Properties.Resources.pc_on_truble;
                    MessageBox.Show("Нет доступа к реестру удаленной машины!");
                }
            }
            else
            {
                SetStatusText("Компьютер не в сети!");
                slText.Text = "Компьютер не в сети!";
                slIcon.Image = Properties.Resources.pc_off;
                _remotename = string.Empty;
            }
            

            btnConnect.Enabled = true;
            tbComputer.Enabled = true;
            return result;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect(true);
        }

        private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Текущие редактируемые права
            NTUsersItem nu;
            if ((_currentsid!=null) && (_rightschanged))
            {
                BtnToFileEnableCheck();
                nu = _remoteusers.GetItem(_currentsid);
                //Save changes
                UInt16 _allow = (UInt16)((cbControlAllow.Checked) ? 1 : 0);
                _allow += (UInt16)((cbTelnetAllow.Checked) ? 2 : 0);
                _allow += (UInt16)((cbRedirectAllow.Checked) ? 4 : 0);
                _allow += (UInt16)((cbFilesAllow.Checked) ? 8 : 0);
                _allow += (UInt16)((cbViewAllow.Checked) ? 16 : 0);
                _allow += (UInt16)((cbTextChatAllow.Checked) ? 32 : 0);
                _allow += (UInt16)((cbVoiceChatAllow.Checked) ? 64 : 0);
                _allow += (UInt16)((cbMessagesAllow.Checked) ? 128 : 0);
                _allow += (UInt16)((cbShutdownAllow.Checked) ? 256 : 0);
                nu.Allow = _allow;

                UInt16 _deny = (UInt16)((cbControlDeny.Checked) ? 1 : 0);
                _deny += (UInt16)((cbTelnetDeny.Checked) ? 2 : 0);
                _deny += (UInt16)((cbRedirectDeny.Checked) ? 4 : 0);
                _deny += (UInt16)((cbFilesDeny.Checked) ? 8 : 0);
                _deny += (UInt16)((cbViewDeny.Checked) ? 16 : 0);
                _deny += (UInt16)((cbTextChatDeny.Checked) ? 32 : 0);
                _deny += (UInt16)((cbVoiceChatDeny.Checked) ? 64 : 0);
                _deny += (UInt16)((cbMessagesDeny.Checked) ? 128 : 0);
                _deny += (UInt16)((cbShutdownDeny.Checked) ? 256 : 0);
                nu.Deny = _deny;
            }
            _currentsid = null;
            if ((lvUsers.SelectedItems.Count > 0) && ((nu = _remoteusers.GetItem(lvUsers.SelectedItems[0].Tag as string)) != null))
            {
                panel1.Enabled = true;
                _currentsid = nu.Sid;
                //загрузка прав
                //Allow
                cbControlAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Control.GetHashCode()) == 0) ? false : true;
                cbTelnetAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Telnet.GetHashCode()) == 0) ? false : true;
                cbRedirectAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Redirect.GetHashCode()) == 0) ? false : true;
                cbFilesAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Files.GetHashCode()) == 0) ? false : true;
                cbViewAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.View.GetHashCode()) == 0) ? false : true;
                cbTextChatAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.TextChat.GetHashCode()) == 0) ? false : true;
                cbVoiceChatAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.VoiceChat.GetHashCode()) == 0) ? false : true;
                cbMessagesAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Messages.GetHashCode()) == 0) ? false : true;
                cbShutdownAllow.Checked = ((nu.Allow & NTUsersItem.RadminRights.Shutdown.GetHashCode()) == 0) ? false : true;
                //Deny
                cbControlDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Control.GetHashCode()) == 0) ? false : true;
                cbTelnetDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Telnet.GetHashCode()) == 0) ? false : true;
                cbRedirectDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Redirect.GetHashCode()) == 0) ? false : true;
                cbFilesDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Files.GetHashCode()) == 0) ? false : true;
                cbViewDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.View.GetHashCode()) == 0) ? false : true;
                cbTextChatDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.TextChat.GetHashCode()) == 0) ? false : true;
                cbVoiceChatDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.VoiceChat.GetHashCode()) == 0) ? false : true;
                cbMessagesDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Messages.GetHashCode()) == 0) ? false : true;
                cbShutdownDeny.Checked = ((nu.Deny & NTUsersItem.RadminRights.Shutdown.GetHashCode()) == 0) ? false : true;

                _rightschanged = false;
            }
            else
            {
                panel1.Enabled = false;
            }
        }
                
        private void cbControlAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbControlAllow.Checked) cbControlDeny.Checked = false;
            
        }

        private void cbControlDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbControlDeny.Checked) cbControlAllow.Checked = false;
        }

        private void cbTelnetAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbTelnetAllow.Checked) cbTelnetDeny.Checked = false;
        }

        private void cbTelnetDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbTelnetDeny.Checked) cbTelnetAllow.Checked = false;
        }

        private void cbRedirectAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbRedirectAllow.Checked) cbRedirectDeny.Checked = false;
        }

        private void cbRedirectDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbRedirectDeny.Checked) cbRedirectAllow.Checked = false;
        }

        private void cbFilesAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbFilesAllow.Checked) cbFilesDeny.Checked = false;
        }

        private void cbFilesDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbFilesDeny.Checked) cbFilesAllow.Checked = false;
        }

        private void cbViewAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbViewAllow.Checked) cbViewDeny.Checked = false;
        }

        private void cbViewDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbViewDeny.Checked) cbViewAllow.Checked = false;
        }

        private void cbTextChatAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbTextChatAllow.Checked) cbTextChatDeny.Checked = false;

        }

        private void cbTextChatDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbTextChatDeny.Checked) cbTextChatAllow.Checked = false;
        }

        private void cbVoiceChatAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbVoiceChatAllow.Checked) cbVoiceChatDeny.Checked = false;
        }

        private void cbVoiceChatDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbVoiceChatDeny.Checked) cbVoiceChatAllow.Checked = false;
        }

        private void cbMessagesAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbMessagesAllow.Checked) cbMessagesDeny.Checked = false;
        }

        private void cbMessagesDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbMessagesDeny.Checked) cbMessagesAllow.Checked = false;
        }

        private void cbShutdownAllow_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbShutdownAllow.Checked) cbShutdownDeny.Checked = false;
        }

        private void cbShutdownDeny_CheckedChanged(object sender, EventArgs e)
        {
            _rightschanged = true;
            if (cbShutdownDeny.Checked) cbShutdownAllow.Checked = false;
        }

        private bool IsCipher(string value)
        {
            bool result = false;
            if (value.Length == 0) return false;
            try
            {
                int i = Convert.ToInt32(value);
                result = true;
            }
            catch { }
            return result;
        }

        private string CheckParams()
        {
            string result = null;
            if (!IsCipher(tbPort.Text))
            {
                tbPort.BackColor = Color.Bisque;
                result = "Не указан порт";
            }
            else
            {
                tbPort.BackColor = Color.White;
            }

            if (!IsCipher(tbTrayIconMode.Text))
            {
                tbTrayIconMode.BackColor = Color.Bisque;

                result += ((result == null) ? "" : "\r\n") + "Не указан режим иконки в трее";
            }
            else
            {
                tbTrayIconMode.BackColor = Color.White;
            }
            if (!IsCipher(tbTimeout.Text))
            {
                tbTimeout.BackColor = Color.Bisque;
                result += ((result == null) ? "" : "\r\n") + "Не указан таймаут";
            }
            else
            {
                tbTimeout.BackColor = Color.White;
            }
            if (_remoteusers.Items.Count == 0)
            {
                result += ((result == null) ? "" : "\r\n") + "Список пользователей пуст";
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("This feature is not supported yet!");
            if (_rightschanged)
            {
                //Если отредактированы права, но не сохранены - сохраняем
                lvUsers_SelectedIndexChanged(null,null);
            }
            _ntusers_data = _remoteusers.GetData();
            string Error = CheckParams();
            if (Error == null)
            {
                if ((cbNTAuthEnabled.Checked) || (MessageBox.Show("В настройках отключена NT авторизация, Вы действительно хотите ее отключить на удаленном ПК?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                {
                    Connect(false);
                }
                else
                {
                    slText.Text = "Операция отменена пользователем";
                    slIcon.Image = Properties.Resources.warning1;
                }
            }
            else
            {
                MessageBox.Show(Error,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_rightschanged)
            {
                //Если отредактированы права, но не сохранены - сохраняем
                lvUsers_SelectedIndexChanged(null, null);
            }
            ADUserPicker au = new ADUserPicker();
            au.Filter = 3;
            if (au.ShowDialog() == DialogResult.OK)
            {
                if (_remoteusers.GetItem(au.UserSid) != null)
                {
                    MessageBox.Show("Указанный пользователь уже имеется в списке");
                }
                else
                {
                    NTUsersItem nu = new NTUsersItem();
                    nu.Sid = au.UserSid;
                    //nu.Name = au.UserName;
                    nu.Allow = 0x01ff; //Allow all
                    _remoteusers.Items.Add(nu);
                }
            }
            au.Dispose();
            UpdateUsersList();
        }

        private void MainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            
#if DEBUG
            DateTime dt = DateTime.ParseExact(Properties.Resources.dates, "dd.MM.yyyy", null);
            string _debug = "(debug)\r\nДата компиляции: "+dt.ToShortDateString();
#else
            string _debug = "";
#endif
            MessageBox.Show(AssemblyDescription + " v." + AssemblyVersion + _debug + "\r\n\r\nАвтор: Михальченков Д.А. / Witchcraft Creative Lab\r\nE-Mail: mikhaltchenkov@gmail.com","О программе...",MessageBoxButtons.OK,MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                NTUsersItem nu = _remoteusers.GetItem(lvUsers.SelectedItems[0].Tag.ToString());
                _remoteusers.Items.Remove(nu);
                UpdateUsersList();
            }
        }

        private void btnConnect_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip((System.Windows.Forms.Control)sender,
                            ((System.Windows.Forms.Control)sender).AccessibleDescription);
        }

        private void btnToFile_Click(object sender, EventArgs e)
        {
            if (_rightschanged)
            {
                //Если отредактированы права, но не сохранены - сохраняем
                lvUsers_SelectedIndexChanged(null, null);
            }
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.DefaultExt = ".rage";
            sfd.Filter = "Rage files|*.rage";
            sfd.Title = "Сохранить";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter writer=null;
                try
                {
                    writer = new XmlTextWriter(sfd.FileName, System.Text.Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Rage");
                    writer.WriteElementString("Version", "1"); //Версия документа
                    writer.WriteElementString("Computer", tbComputer.Text);
                    writer.WriteElementString("NTAuthEnabled", Convert.ToString(cbNTAuthEnabled.Checked));
                    writer.WriteElementString("DisableAudio", Convert.ToString(cbDisableAudio.Checked));
                    writer.WriteElementString("DisableChat", Convert.ToString(cbDisableChat.Checked));
                    writer.WriteElementString("DisableFile", Convert.ToString(cbDisableFile.Checked));
                    writer.WriteElementString("DisableMessage", Convert.ToString(cbDisableMessage.Checked));
                    writer.WriteElementString("DisableRedirect", Convert.ToString(cbDisableRedirect.Checked));
                    writer.WriteElementString("DisableScreen", Convert.ToString(cbDisableScreen.Checked));
                    writer.WriteElementString("DisableShutdown", Convert.ToString(cbDisableShutdown.Checked));
                    writer.WriteElementString("DisableTelnet", Convert.ToString(cbDisableTelnet.Checked));
                    writer.WriteElementString("DisableView", Convert.ToString(cbDisableView.Checked));
                    writer.WriteElementString("EnableEventLog", Convert.ToString(cbEnableEventLog.Checked));
                    writer.WriteElementString("EnableLogFile", Convert.ToString(cbEnableLogFile.Checked));
                    writer.WriteElementString("Port", tbPort.Text);
                    writer.WriteElementString("TrayIconMode", tbTrayIconMode.Text);
                    writer.WriteElementString("Timeout", tbTimeout.Text);
                    try
                    {
                        writer.WriteStartElement("NtUser");
                        foreach (NTUsersItem nu in _remoteusers.Items)
                        {
                            try
                            {
                                writer.WriteStartElement("User");
                                writer.WriteAttributeString("Sid", nu.Sid);
                                writer.WriteAttributeString("Allow", Convert.ToString(nu.Allow));
                                writer.WriteAttributeString("Deny", Convert.ToString(nu.Deny));
                            }
                            catch { }
                            finally
                            {
                                writer.WriteEndElement();
                            }

                        }
                    }
                    catch { }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
                catch { }
                finally 
                {
                    if (writer != null)
                    {
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                    }
                }


            }
        }

        public int OpenFile(string Name)
        {
            _remoteusers.Items.Clear();
            cbNTAuthEnabled.Checked = false;
            cbDisableAudio.Checked = false;
            cbDisableChat.Checked = false;
            cbDisableFile.Checked = false;
            cbDisableMessage.Checked = false;
            cbDisableRedirect.Checked = false;
            cbDisableScreen.Checked = false;
            cbDisableShutdown.Checked = false;
            cbDisableTelnet.Checked = false;
            cbDisableView.Checked = false;
            cbEnableEventLog.Checked = false;
            cbEnableLogFile.Checked = false;
            tbPort.Text = "4899";
            tbTrayIconMode.Text = "2"; 
            tbTimeout.Text = "10";   
            int result = -1;//общая ошибка
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(Name);
                XmlNode node = document.SelectSingleNode("/Rage/Version");
                if (Convert.ToInt32(node.InnerText) != 1)
                {
                    //не поддерживаемая версия
                    return -2;
                }
                node = document.SelectSingleNode("/Rage/NTAuthEnabled");
                cbNTAuthEnabled.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableAudio");
                cbDisableAudio.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableChat");
                cbDisableChat.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableFile");
                cbDisableFile.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableMessage");
                cbDisableMessage.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableRedirect");
                cbDisableRedirect.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableScreen");
                cbDisableScreen.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableShutdown");
                cbDisableShutdown.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableTelnet");
                cbDisableTelnet.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/DisableView");
                cbDisableView.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/EnableEventLog");
                cbEnableEventLog.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/EnableLogFile");
                cbEnableLogFile.Checked = Convert.ToBoolean(node.InnerText);
                node = document.SelectSingleNode("/Rage/Port");
                tbPort.Text = node.InnerText;
                node = document.SelectSingleNode("/Rage/TrayIconMode");
                tbTrayIconMode.Text = node.InnerText;
                node = document.SelectSingleNode("/Rage/Timeout");
                tbTimeout.Text = node.InnerText;
                XmlNodeList nodes = document.SelectNodes("/Rage/NtUser/User");

                foreach (XmlNode nd in nodes)
                {
                    NTUsersItem nu = new NTUsersItem();
                    nu.Sid = nd.Attributes.GetNamedItem("Sid").InnerText;
                    nu.Allow = Convert.ToUInt16(nd.Attributes.GetNamedItem("Allow").InnerText);
                    nu.Deny = Convert.ToUInt16(nd.Attributes.GetNamedItem("Deny").InnerText);
                    _remoteusers.Items.Add(nu);
                }
                result = 0;
            }
            catch { }
            return result;
        }

        private void btnFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.DefaultExt = ".rage";
            ofd.Filter = "Rage files|*.rage";
            ofd.Title = "Открыть";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                slIcon.Image = Properties.Resources.update;
                slText.Text = "Чтение информации из файла...";
                if (OpenFile(ofd.FileName) == 0)
                {
                    UpdateUsersList();
                    slIcon.Image = Properties.Resources.pc_off;
                    slText.Text = "Файл считан";
                }
                else
                {
                    slIcon.Image = Properties.Resources.warning1;
                    slText.Text = "Ошибка при чтении файла";
                }
            }
        }

        private void BtnToFileEnableCheck()
        {
            btnToFile.Enabled = _paramschanged || _rightschanged;
        }

        private void ParamsChanged(object sender, EventArgs e)
        {
            _paramschanged = true;
            BtnToFileEnableCheck();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //считываем домен текущего пользователя
            _domain = Environment.UserDomainName.ToLower();
        }

    }
}
