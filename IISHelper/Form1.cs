using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISHelper
{
    public partial class Form1 : Form
    {
        IISManager _iismngr = null;
        internal IISManager IISmngr
        {
            get
            {
                return _iismngr;
            }

            set
            {
                _iismngr = value;
            }
        }

        string _serverName = string.Empty;
        public Form1()
        {
            InitilizeServer("localhost");
        }

        public Form1(string server)
        {
            InitilizeServer(server);
        }

        private void InitilizeServer(string server)
        {
            InitializeComponent();
            try
            {
                if (server == "localhost")
                {
                    IISmngr = new IISManager();
                    SetSystemInfo(Environment.MachineName);
                }
                else
                {
                    IISmngr = new IISManager(server);
                    SetSystemInfo(server);
                }
                toolStripStatusLabel1.Text = "Connected to " + server;
                statusStrip1.Refresh();
                statusStrip1.ForeColor = Color.Black;
                LoadData();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Disconnected";
                statusStrip1.ForeColor = Color.Red;
                MessageBox.Show(ex.Message);
            }
        }


        private void SetSystemInfo(string machine)
        {
            //this.Title = Environment.MachineName + "(" + Environment.UserName + ")  IIS_ver: " + IISManager.GetIISVersion();
            this.Text = machine + "(" + Environment.UserName + ")";
        }

        public void LoadData()
        {
            LoadIISSites();
            LoadApplications();
            LoadPools();
            LabelSummary();
            LoadTree();
            LoadBindings();
        }

        public void LoadIISSites()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            List<IISSite> sites = IISmngr.GetSiteNames();

            foreach (var site in sites)
            {
                int appCount = site.AppCount - 1;
                string[] row = { site.Id.ToString(), site.Name, site.State, appCount.ToString(), site.BindingCount.ToString() };
                var listViewItem = new ListViewItem(row, site.Name);
                listView1.Items.Add(listViewItem);
            }

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[2].Text == "Stopped")
                    listView1.Items[i].ForeColor = Color.Red;
            }

            runlbl.Text = "Running: Sites(" + sites.Where(x => x.State == "Started").Count().ToString() + ")";
            stoplbl.Text = "Stopped: Sites(" + sites.Where(x => x.State == "Stopped").Count().ToString() + ")";
        }

        public void LoadApplications()
        {
            listView2.Items.Clear();
            List<IISApplication> allApps = new List<IISApplication>();
            List<IISSite> sites = IISmngr.GetSiteNames();
            foreach (var item in sites)
            {
                List<IISApplication> apps = IISmngr.GetApplications(item.Name);

                allApps.AddRange(apps.Where(x => x.Name != "/"));
            }

            foreach (var app in allApps)
            {
                string[] row = { app.Name.TrimStart('/'), app.Site, app.Pool, app.State };
                var listViewItem = new ListViewItem(row);
                listView2.Items.Add(listViewItem);
            }

            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (listView2.Items[i].SubItems[3].Text == "Stopped")
                    listView2.Items[i].ForeColor = Color.Red;
            }

            var pools = allApps.GroupBy(x => x.Pool);
        }

        public void LoadPools()
        {
            listView3.Items.Clear();
            listView3.FullRowSelect = true;
            List<IISPool> allPools = IISmngr.GetPools();

            foreach (var pool in allPools)
            {
                string[] row = { pool.Name, pool.Mode, pool.Version, pool.State };
                var listViewItem = new ListViewItem(row);
                listView3.Items.Add(listViewItem);
            }

            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (listView3.Items[i].SubItems[3].Text == "Stopped")
                    listView3.Items[i].ForeColor = Color.Red;
            }

            runlbl.Text += " Pools(" + allPools.Where(x => x.State == "Started").Count().ToString() + ")";
            stoplbl.Text += " Pools(" + allPools.Where(x => x.State == "Stopped").Count().ToString() + ")";

            totallbl.Text = "All: Sites(" + listView1.Items.Count.ToString() + ") Apps(" + listView2.Items.Count.ToString() + ") Pools(" + listView3.Items.Count.ToString() + ")"; 
        }

        public void LoadTree()
        {
            treeView1.Nodes.Clear();

            foreach (var site in IISmngr.GetSiteNames())
            {
                TreeNode siteNode = new TreeNode(site.Name);
                List<TreeNode> appsItemList = new List<TreeNode>();
                foreach (var app in IISmngr.GetApplications(site.Name))
                {
                    if (app.Name != "/")
                    {
                        TreeNode appNode = new TreeNode(app.Name.TrimStart('/'));
                        appNode.Nodes.Add(IISmngr.GetPool(site.Name, app.Name));
                        appsItemList.Add(appNode);
                    }
                }

                siteNode.Nodes.AddRange(appsItemList.ToArray());

                treeView1.Nodes.Add(siteNode);
            }
        }

        public void LoadBindings()
        {
            foreach (var site in IISmngr.GetSiteNames())
            {
                foreach (var bind in IISmngr.GetBindings(site.Name))
                {
                    string[] row = { site.Name, bind.Binding, bind.Name, bind.Protocol };
                    var listViewItem = new ListViewItem(row, site.Name);
                    bindinglistView.Items.Add(listViewItem);
                }
            }
        }

        public void LabelSummary()
        {

            //string runingSites = _iismngr.GetSiteNames().Where(x => x.State == "Started").Count().ToString();
            //string runingPools = _iismngr.GetPools().Where(x => x.State == "Started").Count().ToString();
            //runlbl.Text = "Running Sites(" + runingSites + ") Pools(" + runingPools + ")";

            //string stoppedSites = _iismngr.GetSiteNames().Where(x => x.State == "Stopped").Count().ToString();
            //string stoppedPools = _iismngr.GetPools().Where(x => x.State == "Stopped").Count().ToString();
            //stoplbl.Text = "Stopped Sites(" + stoppedSites + ") Pools(" + stoppedPools + ")";
        }

        private void startSite_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.ImageKey != null)
                {
                    string siteName = listView1.FocusedItem.ImageKey;
                    bool started = IISmngr.StartSite(siteName);
                    LoadData();
                    if (started)
                        MessageBox.Show("IIS " + siteName + " started.");
                }
            }
            else if (listView3.FocusedItem != null)
            {
                string poolName = listView3.FocusedItem.Text;
                bool started = IISmngr.StartPool(poolName);
                LoadPools();
                if (started)
                    MessageBox.Show("IIS " + poolName + " started.");
            }
            else
                MessageBox.Show("No selection found.");
        }

        private void stopSite_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.ImageKey != null)
                {
                    string siteName = listView1.FocusedItem.ImageKey;
                    bool stopped = IISmngr.StopSite(siteName);
                    LoadData();
                    if (stopped)
                        MessageBox.Show("IIS " + siteName + " stopped.");
                }
            }
            else if (listView3.FocusedItem != null)
            {
                string poolName = listView3.FocusedItem.Text;
                bool stopped = IISmngr.StopPool(poolName);
                LoadPools();
                if (stopped)
                    MessageBox.Show("IIS " + poolName + " stopped.");
            }
            else
            {
                MessageBox.Show("No selection found.");
            }
        }

        private void restartSite_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                if (listView1.FocusedItem.ImageKey != null)
                {
                    string siteName = listView1.FocusedItem.ImageKey;
                    bool restarted = IISmngr.RestartSite(siteName);
                    LoadData();
                    if (restarted)
                        MessageBox.Show("IIS " + siteName + " restarted.");
                }
            }
            else if (listView3.FocusedItem != null)
            {
                string poolName = listView3.FocusedItem.Text;
                bool restarted = IISmngr.RecyclePool(poolName);
                LoadPools();
                if (restarted)
                    MessageBox.Show("IIS " + poolName + " recycled.");
            }
            else
                MessageBox.Show("No selection found.");
        }

        private void remotebtn_Click(object sender, EventArgs e)
        {
            ShowRemote();
        }

        private void ShowRemote()
        {
            if (remotebox.Text != string.Empty)
            {
                Form1 remote = new Form1(remotebox.Text);
                remote.Show();
            }
            else
                MessageBox.Show("No remote server specified.");
        }

        private void remotebox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowRemote();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listView1.Sort();
        }

        private void listView3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView3.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listView3.Sort();
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView2.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listView2.Sort();
        }

        private void expandBtn_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void colBtn_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void expBtn_Click(object sender, EventArgs e)
        {
            string exportPath = @"C:\iistree.xml";
            ExportManager.ExportTreeViewToXmlFile(treeView1, exportPath);
            MessageBox.Show("Tree was saved to " + exportPath);
        }

        private void bindinglistView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.bindinglistView.ListViewItemSorter = new ListViewItemComparer(e.Column);
            bindinglistView.Sort();
        }
    }
}
