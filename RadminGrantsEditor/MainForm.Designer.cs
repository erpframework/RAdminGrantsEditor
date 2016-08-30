namespace RadminGrantsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbComputer = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.slText = new System.Windows.Forms.ToolStripStatusLabel();
            this.sl64bit = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcRadminSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrayIconMode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEnableLogFile = new System.Windows.Forms.CheckBox();
            this.cbEnableEventLog = new System.Windows.Forms.CheckBox();
            this.cbDisableView = new System.Windows.Forms.CheckBox();
            this.cbDisableTelnet = new System.Windows.Forms.CheckBox();
            this.cbDisableShutdown = new System.Windows.Forms.CheckBox();
            this.cbDisableScreen = new System.Windows.Forms.CheckBox();
            this.cbDisableRedirect = new System.Windows.Forms.CheckBox();
            this.cbDisableMessage = new System.Windows.Forms.CheckBox();
            this.cbDisableFile = new System.Windows.Forms.CheckBox();
            this.cbDisableChat = new System.Windows.Forms.CheckBox();
            this.cbDisableAudio = new System.Windows.Forms.CheckBox();
            this.cbNTAuthEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbShutdownDeny = new System.Windows.Forms.CheckBox();
            this.cbMessagesDeny = new System.Windows.Forms.CheckBox();
            this.cbVoiceChatDeny = new System.Windows.Forms.CheckBox();
            this.cbTextChatDeny = new System.Windows.Forms.CheckBox();
            this.cbViewDeny = new System.Windows.Forms.CheckBox();
            this.cbFilesDeny = new System.Windows.Forms.CheckBox();
            this.cbRedirectDeny = new System.Windows.Forms.CheckBox();
            this.cbTelnetDeny = new System.Windows.Forms.CheckBox();
            this.cbControlDeny = new System.Windows.Forms.CheckBox();
            this.cbShutdownAllow = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbMessagesAllow = new System.Windows.Forms.CheckBox();
            this.cbVoiceChatAllow = new System.Windows.Forms.CheckBox();
            this.cbTextChatAllow = new System.Windows.Forms.CheckBox();
            this.cbViewAllow = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFilesAllow = new System.Windows.Forms.CheckBox();
            this.cbRedirectAllow = new System.Windows.Forms.CheckBox();
            this.cbTelnetAllow = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbControlAllow = new System.Windows.Forms.CheckBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnToFile = new System.Windows.Forms.Button();
            this.btnFromFile = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tcRadminSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя ПК:";
            // 
            // tbComputer
            // 
            this.tbComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComputer.Location = new System.Drawing.Point(68, 12);
            this.tbComputer.Name = "tbComputer";
            this.tbComputer.Size = new System.Drawing.Size(153, 20);
            this.tbComputer.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slIcon,
            this.slText,
            this.sl64bit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(398, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slIcon
            // 
            this.slIcon.Image = global::RadminGrantsEditor.Properties.Resources.warning1;
            this.slIcon.Name = "slIcon";
            this.slIcon.Size = new System.Drawing.Size(16, 17);
            // 
            // slText
            // 
            this.slText.AutoSize = false;
            this.slText.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.slText.Name = "slText";
            this.slText.Size = new System.Drawing.Size(250, 17);
            this.slText.Text = "Не подключено";
            this.slText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sl64bit
            // 
            this.sl64bit.AutoSize = false;
            this.sl64bit.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sl64bit.Name = "sl64bit";
            this.sl64bit.Size = new System.Drawing.Size(32, 17);
            // 
            // tcRadminSettings
            // 
            this.tcRadminSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcRadminSettings.Controls.Add(this.tabPage1);
            this.tcRadminSettings.Controls.Add(this.tabPage2);
            this.tcRadminSettings.Location = new System.Drawing.Point(12, 39);
            this.tcRadminSettings.Name = "tcRadminSettings";
            this.tcRadminSettings.SelectedIndex = 0;
            this.tcRadminSettings.Size = new System.Drawing.Size(374, 381);
            this.tcRadminSettings.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbTimeout);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbTrayIconMode);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbEnableLogFile);
            this.tabPage1.Controls.Add(this.cbEnableEventLog);
            this.tabPage1.Controls.Add(this.cbDisableView);
            this.tabPage1.Controls.Add(this.cbDisableTelnet);
            this.tabPage1.Controls.Add(this.cbDisableShutdown);
            this.tabPage1.Controls.Add(this.cbDisableScreen);
            this.tabPage1.Controls.Add(this.cbDisableRedirect);
            this.tabPage1.Controls.Add(this.cbDisableMessage);
            this.tabPage1.Controls.Add(this.cbDisableFile);
            this.tabPage1.Controls.Add(this.cbDisableChat);
            this.tabPage1.Controls.Add(this.cbDisableAudio);
            this.tabPage1.Controls.Add(this.cbNTAuthEnabled);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 355);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Общие настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbTimeout
            // 
            this.tbTimeout.Location = new System.Drawing.Point(258, 151);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(67, 20);
            this.tbTimeout.TabIndex = 16;
            this.tbTimeout.TextChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Timeout";
            // 
            // tbTrayIconMode
            // 
            this.tbTrayIconMode.Location = new System.Drawing.Point(258, 125);
            this.tbTrayIconMode.Name = "tbTrayIconMode";
            this.tbTrayIconMode.Size = new System.Drawing.Size(67, 20);
            this.tbTrayIconMode.TabIndex = 14;
            this.tbTrayIconMode.TextChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TrayIconMode";
            // 
            // tbPort
            // 
            this.tbPort.BackColor = System.Drawing.SystemColors.Window;
            this.tbPort.Location = new System.Drawing.Point(258, 99);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(67, 20);
            this.tbPort.TabIndex = 13;
            this.tbPort.TextChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Port";
            // 
            // cbEnableLogFile
            // 
            this.cbEnableLogFile.AutoSize = true;
            this.cbEnableLogFile.Location = new System.Drawing.Point(179, 75);
            this.cbEnableLogFile.Name = "cbEnableLogFile";
            this.cbEnableLogFile.Size = new System.Drawing.Size(93, 17);
            this.cbEnableLogFile.TabIndex = 11;
            this.cbEnableLogFile.Text = "EnableLogFile";
            this.cbEnableLogFile.UseVisualStyleBackColor = true;
            this.cbEnableLogFile.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbEnableEventLog
            // 
            this.cbEnableEventLog.AutoSize = true;
            this.cbEnableEventLog.Location = new System.Drawing.Point(179, 52);
            this.cbEnableEventLog.Name = "cbEnableEventLog";
            this.cbEnableEventLog.Size = new System.Drawing.Size(105, 17);
            this.cbEnableEventLog.TabIndex = 10;
            this.cbEnableEventLog.Text = "EnableEventLog";
            this.cbEnableEventLog.UseVisualStyleBackColor = true;
            this.cbEnableEventLog.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableView
            // 
            this.cbDisableView.AutoSize = true;
            this.cbDisableView.Location = new System.Drawing.Point(179, 29);
            this.cbDisableView.Name = "cbDisableView";
            this.cbDisableView.Size = new System.Drawing.Size(84, 17);
            this.cbDisableView.TabIndex = 9;
            this.cbDisableView.Text = "DisableView";
            this.cbDisableView.UseVisualStyleBackColor = true;
            this.cbDisableView.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableTelnet
            // 
            this.cbDisableTelnet.AutoSize = true;
            this.cbDisableTelnet.Location = new System.Drawing.Point(179, 6);
            this.cbDisableTelnet.Name = "cbDisableTelnet";
            this.cbDisableTelnet.Size = new System.Drawing.Size(91, 17);
            this.cbDisableTelnet.TabIndex = 8;
            this.cbDisableTelnet.Text = "DisableTelnet";
            this.cbDisableTelnet.UseVisualStyleBackColor = true;
            this.cbDisableTelnet.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableShutdown
            // 
            this.cbDisableShutdown.AutoSize = true;
            this.cbDisableShutdown.Location = new System.Drawing.Point(6, 167);
            this.cbDisableShutdown.Name = "cbDisableShutdown";
            this.cbDisableShutdown.Size = new System.Drawing.Size(109, 17);
            this.cbDisableShutdown.TabIndex = 7;
            this.cbDisableShutdown.Text = "DisableShutdown";
            this.cbDisableShutdown.UseVisualStyleBackColor = true;
            this.cbDisableShutdown.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableScreen
            // 
            this.cbDisableScreen.AutoSize = true;
            this.cbDisableScreen.Location = new System.Drawing.Point(6, 144);
            this.cbDisableScreen.Name = "cbDisableScreen";
            this.cbDisableScreen.Size = new System.Drawing.Size(95, 17);
            this.cbDisableScreen.TabIndex = 6;
            this.cbDisableScreen.Text = "DisableScreen";
            this.cbDisableScreen.UseVisualStyleBackColor = true;
            this.cbDisableScreen.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableRedirect
            // 
            this.cbDisableRedirect.AutoSize = true;
            this.cbDisableRedirect.Location = new System.Drawing.Point(6, 121);
            this.cbDisableRedirect.Name = "cbDisableRedirect";
            this.cbDisableRedirect.Size = new System.Drawing.Size(101, 17);
            this.cbDisableRedirect.TabIndex = 5;
            this.cbDisableRedirect.Text = "DisableRedirect";
            this.cbDisableRedirect.UseVisualStyleBackColor = true;
            this.cbDisableRedirect.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableMessage
            // 
            this.cbDisableMessage.AutoSize = true;
            this.cbDisableMessage.Location = new System.Drawing.Point(6, 98);
            this.cbDisableMessage.Name = "cbDisableMessage";
            this.cbDisableMessage.Size = new System.Drawing.Size(104, 17);
            this.cbDisableMessage.TabIndex = 4;
            this.cbDisableMessage.Text = "DisableMessage";
            this.cbDisableMessage.UseVisualStyleBackColor = true;
            this.cbDisableMessage.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableFile
            // 
            this.cbDisableFile.AutoSize = true;
            this.cbDisableFile.Location = new System.Drawing.Point(6, 75);
            this.cbDisableFile.Name = "cbDisableFile";
            this.cbDisableFile.Size = new System.Drawing.Size(77, 17);
            this.cbDisableFile.TabIndex = 3;
            this.cbDisableFile.Text = "DisableFile";
            this.cbDisableFile.UseVisualStyleBackColor = true;
            this.cbDisableFile.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableChat
            // 
            this.cbDisableChat.AutoSize = true;
            this.cbDisableChat.Location = new System.Drawing.Point(6, 52);
            this.cbDisableChat.Name = "cbDisableChat";
            this.cbDisableChat.Size = new System.Drawing.Size(83, 17);
            this.cbDisableChat.TabIndex = 2;
            this.cbDisableChat.Text = "DisableChat";
            this.cbDisableChat.UseVisualStyleBackColor = true;
            this.cbDisableChat.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbDisableAudio
            // 
            this.cbDisableAudio.AutoSize = true;
            this.cbDisableAudio.Location = new System.Drawing.Point(6, 29);
            this.cbDisableAudio.Name = "cbDisableAudio";
            this.cbDisableAudio.Size = new System.Drawing.Size(88, 17);
            this.cbDisableAudio.TabIndex = 1;
            this.cbDisableAudio.Text = "DisableAudio";
            this.cbDisableAudio.UseVisualStyleBackColor = true;
            this.cbDisableAudio.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // cbNTAuthEnabled
            // 
            this.cbNTAuthEnabled.AutoSize = true;
            this.cbNTAuthEnabled.Location = new System.Drawing.Point(6, 6);
            this.cbNTAuthEnabled.Name = "cbNTAuthEnabled";
            this.cbNTAuthEnabled.Size = new System.Drawing.Size(102, 17);
            this.cbNTAuthEnabled.TabIndex = 0;
            this.cbNTAuthEnabled.Text = "NTAuthEnabled";
            this.cbNTAuthEnabled.UseVisualStyleBackColor = true;
            this.cbNTAuthEnabled.CheckedChanged += new System.EventHandler(this.ParamsChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnDeleteUser);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lvUsers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Windows NT Security";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Разрешить Запретить";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbShutdownDeny);
            this.panel1.Controls.Add(this.cbMessagesDeny);
            this.panel1.Controls.Add(this.cbVoiceChatDeny);
            this.panel1.Controls.Add(this.cbTextChatDeny);
            this.panel1.Controls.Add(this.cbViewDeny);
            this.panel1.Controls.Add(this.cbFilesDeny);
            this.panel1.Controls.Add(this.cbRedirectDeny);
            this.panel1.Controls.Add(this.cbTelnetDeny);
            this.panel1.Controls.Add(this.cbControlDeny);
            this.panel1.Controls.Add(this.cbShutdownAllow);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cbMessagesAllow);
            this.panel1.Controls.Add(this.cbVoiceChatAllow);
            this.panel1.Controls.Add(this.cbTextChatAllow);
            this.panel1.Controls.Add(this.cbViewAllow);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbFilesAllow);
            this.panel1.Controls.Add(this.cbRedirectAllow);
            this.panel1.Controls.Add(this.cbTelnetAllow);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbControlAllow);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 184);
            this.panel1.TabIndex = 3;
            // 
            // cbShutdownDeny
            // 
            this.cbShutdownDeny.AutoSize = true;
            this.cbShutdownDeny.Location = new System.Drawing.Point(302, 163);
            this.cbShutdownDeny.Name = "cbShutdownDeny";
            this.cbShutdownDeny.Size = new System.Drawing.Size(15, 14);
            this.cbShutdownDeny.TabIndex = 26;
            this.cbShutdownDeny.UseVisualStyleBackColor = true;
            this.cbShutdownDeny.CheckedChanged += new System.EventHandler(this.cbShutdownDeny_CheckedChanged);
            // 
            // cbMessagesDeny
            // 
            this.cbMessagesDeny.AutoSize = true;
            this.cbMessagesDeny.Location = new System.Drawing.Point(302, 143);
            this.cbMessagesDeny.Name = "cbMessagesDeny";
            this.cbMessagesDeny.Size = new System.Drawing.Size(15, 14);
            this.cbMessagesDeny.TabIndex = 25;
            this.cbMessagesDeny.UseVisualStyleBackColor = true;
            this.cbMessagesDeny.CheckedChanged += new System.EventHandler(this.cbMessagesDeny_CheckedChanged);
            // 
            // cbVoiceChatDeny
            // 
            this.cbVoiceChatDeny.AutoSize = true;
            this.cbVoiceChatDeny.Location = new System.Drawing.Point(302, 123);
            this.cbVoiceChatDeny.Name = "cbVoiceChatDeny";
            this.cbVoiceChatDeny.Size = new System.Drawing.Size(15, 14);
            this.cbVoiceChatDeny.TabIndex = 24;
            this.cbVoiceChatDeny.UseVisualStyleBackColor = true;
            this.cbVoiceChatDeny.CheckedChanged += new System.EventHandler(this.cbVoiceChatDeny_CheckedChanged);
            // 
            // cbTextChatDeny
            // 
            this.cbTextChatDeny.AutoSize = true;
            this.cbTextChatDeny.Location = new System.Drawing.Point(302, 103);
            this.cbTextChatDeny.Name = "cbTextChatDeny";
            this.cbTextChatDeny.Size = new System.Drawing.Size(15, 14);
            this.cbTextChatDeny.TabIndex = 23;
            this.cbTextChatDeny.UseVisualStyleBackColor = true;
            this.cbTextChatDeny.CheckedChanged += new System.EventHandler(this.cbTextChatDeny_CheckedChanged);
            // 
            // cbViewDeny
            // 
            this.cbViewDeny.AutoSize = true;
            this.cbViewDeny.Location = new System.Drawing.Point(302, 83);
            this.cbViewDeny.Name = "cbViewDeny";
            this.cbViewDeny.Size = new System.Drawing.Size(15, 14);
            this.cbViewDeny.TabIndex = 22;
            this.cbViewDeny.UseVisualStyleBackColor = true;
            this.cbViewDeny.CheckedChanged += new System.EventHandler(this.cbViewDeny_CheckedChanged);
            // 
            // cbFilesDeny
            // 
            this.cbFilesDeny.AutoSize = true;
            this.cbFilesDeny.Location = new System.Drawing.Point(302, 63);
            this.cbFilesDeny.Name = "cbFilesDeny";
            this.cbFilesDeny.Size = new System.Drawing.Size(15, 14);
            this.cbFilesDeny.TabIndex = 21;
            this.cbFilesDeny.UseVisualStyleBackColor = true;
            this.cbFilesDeny.CheckedChanged += new System.EventHandler(this.cbFilesDeny_CheckedChanged);
            // 
            // cbRedirectDeny
            // 
            this.cbRedirectDeny.AutoSize = true;
            this.cbRedirectDeny.Location = new System.Drawing.Point(302, 43);
            this.cbRedirectDeny.Name = "cbRedirectDeny";
            this.cbRedirectDeny.Size = new System.Drawing.Size(15, 14);
            this.cbRedirectDeny.TabIndex = 20;
            this.cbRedirectDeny.UseVisualStyleBackColor = true;
            this.cbRedirectDeny.CheckedChanged += new System.EventHandler(this.cbRedirectDeny_CheckedChanged);
            // 
            // cbTelnetDeny
            // 
            this.cbTelnetDeny.AutoSize = true;
            this.cbTelnetDeny.Location = new System.Drawing.Point(302, 23);
            this.cbTelnetDeny.Name = "cbTelnetDeny";
            this.cbTelnetDeny.Size = new System.Drawing.Size(15, 14);
            this.cbTelnetDeny.TabIndex = 19;
            this.cbTelnetDeny.UseVisualStyleBackColor = true;
            this.cbTelnetDeny.CheckedChanged += new System.EventHandler(this.cbTelnetDeny_CheckedChanged);
            // 
            // cbControlDeny
            // 
            this.cbControlDeny.AutoSize = true;
            this.cbControlDeny.Location = new System.Drawing.Point(302, 3);
            this.cbControlDeny.Name = "cbControlDeny";
            this.cbControlDeny.Size = new System.Drawing.Size(15, 14);
            this.cbControlDeny.TabIndex = 18;
            this.cbControlDeny.UseVisualStyleBackColor = true;
            this.cbControlDeny.CheckedChanged += new System.EventHandler(this.cbControlDeny_CheckedChanged);
            // 
            // cbShutdownAllow
            // 
            this.cbShutdownAllow.AutoSize = true;
            this.cbShutdownAllow.Location = new System.Drawing.Point(244, 163);
            this.cbShutdownAllow.Name = "cbShutdownAllow";
            this.cbShutdownAllow.Size = new System.Drawing.Size(15, 14);
            this.cbShutdownAllow.TabIndex = 17;
            this.cbShutdownAllow.UseVisualStyleBackColor = true;
            this.cbShutdownAllow.CheckedChanged += new System.EventHandler(this.cbShutdownAllow_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Выключение";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Передача текстовых сообщений";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Голосовой чат";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Текстовый чат";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Просмотр";
            // 
            // cbMessagesAllow
            // 
            this.cbMessagesAllow.AutoSize = true;
            this.cbMessagesAllow.Location = new System.Drawing.Point(244, 143);
            this.cbMessagesAllow.Name = "cbMessagesAllow";
            this.cbMessagesAllow.Size = new System.Drawing.Size(15, 14);
            this.cbMessagesAllow.TabIndex = 11;
            this.cbMessagesAllow.UseVisualStyleBackColor = true;
            this.cbMessagesAllow.CheckedChanged += new System.EventHandler(this.cbMessagesAllow_CheckedChanged);
            // 
            // cbVoiceChatAllow
            // 
            this.cbVoiceChatAllow.AutoSize = true;
            this.cbVoiceChatAllow.Location = new System.Drawing.Point(244, 123);
            this.cbVoiceChatAllow.Name = "cbVoiceChatAllow";
            this.cbVoiceChatAllow.Size = new System.Drawing.Size(15, 14);
            this.cbVoiceChatAllow.TabIndex = 10;
            this.cbVoiceChatAllow.UseVisualStyleBackColor = true;
            this.cbVoiceChatAllow.CheckedChanged += new System.EventHandler(this.cbVoiceChatAllow_CheckedChanged);
            // 
            // cbTextChatAllow
            // 
            this.cbTextChatAllow.AutoSize = true;
            this.cbTextChatAllow.Location = new System.Drawing.Point(244, 103);
            this.cbTextChatAllow.Name = "cbTextChatAllow";
            this.cbTextChatAllow.Size = new System.Drawing.Size(15, 14);
            this.cbTextChatAllow.TabIndex = 9;
            this.cbTextChatAllow.UseVisualStyleBackColor = true;
            this.cbTextChatAllow.CheckedChanged += new System.EventHandler(this.cbTextChatAllow_CheckedChanged);
            // 
            // cbViewAllow
            // 
            this.cbViewAllow.AutoSize = true;
            this.cbViewAllow.Location = new System.Drawing.Point(244, 83);
            this.cbViewAllow.Name = "cbViewAllow";
            this.cbViewAllow.Size = new System.Drawing.Size(15, 14);
            this.cbViewAllow.TabIndex = 8;
            this.cbViewAllow.UseVisualStyleBackColor = true;
            this.cbViewAllow.CheckedChanged += new System.EventHandler(this.cbViewAllow_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Передача файлов";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Перенаправление";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Telnet";
            // 
            // cbFilesAllow
            // 
            this.cbFilesAllow.AutoSize = true;
            this.cbFilesAllow.Location = new System.Drawing.Point(244, 63);
            this.cbFilesAllow.Name = "cbFilesAllow";
            this.cbFilesAllow.Size = new System.Drawing.Size(15, 14);
            this.cbFilesAllow.TabIndex = 4;
            this.cbFilesAllow.UseVisualStyleBackColor = true;
            this.cbFilesAllow.CheckedChanged += new System.EventHandler(this.cbFilesAllow_CheckedChanged);
            // 
            // cbRedirectAllow
            // 
            this.cbRedirectAllow.AutoSize = true;
            this.cbRedirectAllow.Location = new System.Drawing.Point(244, 43);
            this.cbRedirectAllow.Name = "cbRedirectAllow";
            this.cbRedirectAllow.Size = new System.Drawing.Size(15, 14);
            this.cbRedirectAllow.TabIndex = 3;
            this.cbRedirectAllow.UseVisualStyleBackColor = true;
            this.cbRedirectAllow.CheckedChanged += new System.EventHandler(this.cbRedirectAllow_CheckedChanged);
            // 
            // cbTelnetAllow
            // 
            this.cbTelnetAllow.AutoSize = true;
            this.cbTelnetAllow.Location = new System.Drawing.Point(244, 23);
            this.cbTelnetAllow.Name = "cbTelnetAllow";
            this.cbTelnetAllow.Size = new System.Drawing.Size(15, 14);
            this.cbTelnetAllow.TabIndex = 2;
            this.cbTelnetAllow.UseVisualStyleBackColor = true;
            this.cbTelnetAllow.CheckedChanged += new System.EventHandler(this.cbTelnetAllow_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Управление";
            // 
            // cbControlAllow
            // 
            this.cbControlAllow.AutoSize = true;
            this.cbControlAllow.Location = new System.Drawing.Point(244, 3);
            this.cbControlAllow.Name = "cbControlAllow";
            this.cbControlAllow.Size = new System.Drawing.Size(15, 14);
            this.cbControlAllow.TabIndex = 0;
            this.cbControlAllow.UseVisualStyleBackColor = true;
            this.cbControlAllow.CheckedChanged += new System.EventHandler(this.cbControlAllow_CheckedChanged);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(282, 126);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Удалить";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(201, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(6, 6);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(352, 114);
            this.lvUsers.SmallImageList = this.imageList1;
            this.lvUsers.TabIndex = 0;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Тип";
            this.columnHeader2.Width = 100;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "question.png");
            this.imageList1.Images.SetKeyName(1, "male.png");
            this.imageList1.Images.SetKeyName(2, "users.png");
            // 
            // btnMulti
            // 
            this.btnMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMulti.Enabled = false;
            this.btnMulti.Location = new System.Drawing.Point(358, 10);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(28, 23);
            this.btnMulti.TabIndex = 6;
            this.btnMulti.Text = ">";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Visible = false;
            // 
            // btnConnect
            // 
            this.btnConnect.AccessibleDescription = "Подключение к удаленному ПК и считывание настроек";
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Image = global::RadminGrantsEditor.Properties.Resources.icon_download1;
            this.btnConnect.Location = new System.Drawing.Point(227, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(27, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.btnConnect.MouseHover += new System.EventHandler(this.btnConnect_MouseHover);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = "Сохранение настроек на удаленный ПК";
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::RadminGrantsEditor.Properties.Resources.icon_upload;
            this.btnSave.Location = new System.Drawing.Point(260, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(27, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseHover += new System.EventHandler(this.btnConnect_MouseHover);
            // 
            // btnToFile
            // 
            this.btnToFile.AccessibleDescription = "Сохранение настроек в файл";
            this.btnToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToFile.Enabled = false;
            this.btnToFile.Image = global::RadminGrantsEditor.Properties.Resources.disk;
            this.btnToFile.Location = new System.Drawing.Point(293, 10);
            this.btnToFile.Name = "btnToFile";
            this.btnToFile.Size = new System.Drawing.Size(27, 23);
            this.btnToFile.TabIndex = 7;
            this.btnToFile.UseVisualStyleBackColor = true;
            this.btnToFile.Click += new System.EventHandler(this.btnToFile_Click);
            // 
            // btnFromFile
            // 
            this.btnFromFile.AccessibleDescription = "Считать настройки из файла";
            this.btnFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromFile.Image = global::RadminGrantsEditor.Properties.Resources.folder;
            this.btnFromFile.Location = new System.Drawing.Point(326, 10);
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(27, 23);
            this.btnFromFile.TabIndex = 8;
            this.btnFromFile.UseVisualStyleBackColor = true;
            this.btnFromFile.Click += new System.EventHandler(this.btnFromFile_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 445);
            this.Controls.Add(this.btnFromFile);
            this.Controls.Add(this.btnToFile);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcRadminSettings);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbComputer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "RemoteAdministrator Grants Editor";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tcRadminSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComputer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slText;
        private System.Windows.Forms.ToolStripStatusLabel slIcon;
        private System.Windows.Forms.TabControl tcRadminSettings;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cbNTAuthEnabled;
        private System.Windows.Forms.ToolStripStatusLabel sl64bit;
        private System.Windows.Forms.CheckBox cbDisableFile;
        private System.Windows.Forms.CheckBox cbDisableChat;
        private System.Windows.Forms.CheckBox cbDisableAudio;
        private System.Windows.Forms.TextBox tbTrayIconMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbEnableLogFile;
        private System.Windows.Forms.CheckBox cbEnableEventLog;
        private System.Windows.Forms.CheckBox cbDisableView;
        private System.Windows.Forms.CheckBox cbDisableTelnet;
        private System.Windows.Forms.CheckBox cbDisableShutdown;
        private System.Windows.Forms.CheckBox cbDisableScreen;
        private System.Windows.Forms.CheckBox cbDisableRedirect;
        private System.Windows.Forms.CheckBox cbDisableMessage;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbControlAllow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbFilesAllow;
        private System.Windows.Forms.CheckBox cbRedirectAllow;
        private System.Windows.Forms.CheckBox cbTelnetAllow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbMessagesAllow;
        private System.Windows.Forms.CheckBox cbVoiceChatAllow;
        private System.Windows.Forms.CheckBox cbTextChatAllow;
        private System.Windows.Forms.CheckBox cbViewAllow;
        private System.Windows.Forms.CheckBox cbShutdownAllow;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbShutdownDeny;
        private System.Windows.Forms.CheckBox cbMessagesDeny;
        private System.Windows.Forms.CheckBox cbVoiceChatDeny;
        private System.Windows.Forms.CheckBox cbTextChatDeny;
        private System.Windows.Forms.CheckBox cbViewDeny;
        private System.Windows.Forms.CheckBox cbFilesDeny;
        private System.Windows.Forms.CheckBox cbRedirectDeny;
        private System.Windows.Forms.CheckBox cbTelnetDeny;
        private System.Windows.Forms.CheckBox cbControlDeny;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnToFile;
        private System.Windows.Forms.Button btnFromFile;
    }
}

