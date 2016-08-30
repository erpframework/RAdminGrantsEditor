using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Security.Principal;

namespace Witchcraft
{
    public partial class ADUserPicker : Form
    {
        public String ADRoot;
        private static DirectoryEntry rootEntry;
        public String UserName;
        public String UserMail;
        public String UserPath;
        public String UserSid; 
        public int Filter = 3;//Фильтр поиска - 1 - юзеры, 2 - группы, 3 - и юзеры и группы
        public ADUserPicker()
        {

            InitializeComponent();
        }

        private static bool SetADRootEntry()
        {
            if (rootEntry != null) return true;
            bool result = false;
            try
            {
                //Поиск DC к которому подключен ПК
                //http://mrnone.blogspot.ru/2011/05/directoryservices.html
                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://rootDSE");
                string domainContextLDAP = "LDAP://"
                    + rootDSE.Properties["dnsHostName"].Value.ToString() + "/"
                    + rootDSE.Properties["rootDomainNamingContext"].Value;
                //Logger.log(string.Format("[SetADRootEntry] Connected to DC: {0}", domainContextLDAP));

                rootEntry = new DirectoryEntry(domainContextLDAP);
                result = true;
            }
            catch { }
            return result;
        }


        public static DirectoryEntry ADGetObject(string sid)
        {
            DirectoryEntry result = null;
            if (rootEntry == null)
            {
                try
                {
                    SetADRootEntry();
                }
                catch 
                {
                    //Logger.log("MainForm.cs[public DirectoryEntry GetDirectoryEntryBySID(String Sid)]: " + ee.Message);
                    return null;
                }
            }
            DirectorySearcher DirSearch = new DirectorySearcher(rootEntry, string.Format("(objectSid={0})", sid));
            SearchResultCollection SearchResult = DirSearch.FindAll();
            if (SearchResult.Count > 0)
            {
                result = SearchResult[0].GetDirectoryEntry();
            }
            return result;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tsLabel.Text = "Поиск...";
            Application.DoEvents();
            lvUsers.Items.Clear();
            try
            {
                String _strfilter = string.Empty;
                switch (Filter)
                {
                    case 1: _strfilter = string.Format("(&((objectClass=user)(|(name={0}*)(sAMAccountName={0}*)(mail={0}*)))", tbUser.Text); break;
                    case 2: _strfilter = string.Format("(&((objectClass=group)(name={0}*)))", tbUser.Text); break;
                    default: _strfilter = string.Format("(&(|(objectClass=user)(objectClass=group))(|(name={0}*)(sAMAccountName={0}*)(mail={0}*)))", tbUser.Text); break;
                }
                DirectorySearcher DirSearch = new DirectorySearcher(rootEntry, _strfilter);
                SearchResultCollection SearchResult = DirSearch.FindAll();
                //ArrayList PathArr = new ArrayList();
                foreach (SearchResult SearchRes in SearchResult)
                {
                    ListViewItem lvi = new ListViewItem(SearchRes.GetDirectoryEntry().Properties["name"].Value.ToString());
                    try
                    {
                        lvi.Tag = SearchRes.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString(); 
                        lvi.SubItems.Add(SearchRes.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString());
                    }
                    catch { }
                    try
                    {
                        lvi.SubItems.Add(SearchRes.GetDirectoryEntry().Properties["mail"].Value.ToString());
                    }
                    catch
                    {
                        lvi.SubItems.Add("");
                    }
                    try
                    {
                        lvi.SubItems.Add(ConvertSidToString((byte[])SearchRes.GetDirectoryEntry().Properties["objectSid"].Value));
                    }
                    catch {
                        lvi.SubItems.Add("");
                    }
                    //PathArr.Add(SearchRes.GetDirectoryEntry().Path);
                    lvUsers.Items.Add(lvi);
                }
                DirSearch.Dispose();

            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
            tsLabel.Text = string.Format("{0} объекта(ов) найдено",lvUsers.Items.Count);
        }

        private void FindUser_Shown(object sender, EventArgs e)
        {

/*            try
            {
                //            rootEntry = new DirectoryEntry(ADRoot);
                //Поиск DC к которому подключен ПК
                //http://mrnone.blogspot.ru/2011/05/directoryservices.html
                DirectoryEntry rootDSE = new DirectoryEntry("LDAP://rootDSE");
                string domainContextLDAP = "LDAP://"
                    + rootDSE.Properties["dnsHostName"].Value.ToString() + "/"
                    + rootDSE.Properties["rootDomainNamingContext"].Value;
                rootEntry = new DirectoryEntry(domainContextLDAP);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Контроллер домена не доступен!\r\n"+ee.Message);
                this.Close();
            }*/
            if (!SetADRootEntry())
            {
                MessageBox.Show("Контроллер домена не доступен!");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void lvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvUsers.SelectedItems.Count > 0)
            {
                UserName = lvUsers.SelectedItems[0].SubItems[1].Text;
                UserPath = lvUsers.SelectedItems[0].Tag.ToString();
                UserMail = lvUsers.SelectedItems[0].SubItems[2].Text;
                UserSid = lvUsers.SelectedItems[0].SubItems[3].Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private static string ConvertSidToString(byte[] objectSid)
        {
            SecurityIdentifier si = new SecurityIdentifier(objectSid, 0);
            return si.ToString();
        }
    }
}
