namespace IISHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.remotebtn = new System.Windows.Forms.Button();
            this.remotebox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Summary = new System.Windows.Forms.TabPage();
            this.restartSite = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.PoolName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PoolState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stopSite = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Application = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppPool = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startSite = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Applications = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bindings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SumTabs = new System.Windows.Forms.TabControl();
            this.treetab = new System.Windows.Forms.TabPage();
            this.expBtn = new System.Windows.Forms.Button();
            this.colBtn = new System.Windows.Forms.Button();
            this.expandBtn = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.BindingsTab = new System.Windows.Forms.TabPage();
            this.bindinglistView = new System.Windows.Forms.ListView();
            this.BindSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Binding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BindName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BindProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stoplbl = new System.Windows.Forms.Label();
            this.runlbl = new System.Windows.Forms.Label();
            this.totallbl = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.Summary.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SumTabs.SuspendLayout();
            this.treetab.SuspendLayout();
            this.BindingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(96, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel1.Text = "Disconnected";
            // 
            // remotebtn
            // 
            this.remotebtn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.remotebtn.Location = new System.Drawing.Point(722, 557);
            this.remotebtn.Name = "remotebtn";
            this.remotebtn.Size = new System.Drawing.Size(61, 23);
            this.remotebtn.TabIndex = 2;
            this.remotebtn.Text = "Connect";
            this.remotebtn.UseVisualStyleBackColor = true;
            this.remotebtn.Click += new System.EventHandler(this.remotebtn_Click);
            // 
            // remotebox
            // 
            this.remotebox.Location = new System.Drawing.Point(614, 559);
            this.remotebox.Name = "remotebox";
            this.remotebox.Size = new System.Drawing.Size(100, 20);
            this.remotebox.TabIndex = 3;
            this.remotebox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.remotebox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(532, 563);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remote server:";
            // 
            // Summary
            // 
            this.Summary.Controls.Add(this.stoplbl);
            this.Summary.Controls.Add(this.runlbl);
            this.Summary.Controls.Add(this.totallbl);
            this.Summary.Controls.Add(this.restartSite);
            this.Summary.Controls.Add(this.groupBox3);
            this.Summary.Controls.Add(this.stopSite);
            this.Summary.Controls.Add(this.groupBox2);
            this.Summary.Controls.Add(this.startSite);
            this.Summary.Controls.Add(this.groupBox1);
            this.Summary.Location = new System.Drawing.Point(4, 22);
            this.Summary.Name = "Summary";
            this.Summary.Padding = new System.Windows.Forms.Padding(3);
            this.Summary.Size = new System.Drawing.Size(787, 519);
            this.Summary.TabIndex = 0;
            this.Summary.Text = "IIS Summary";
            this.Summary.UseVisualStyleBackColor = true;
            // 
            // restartSite
            // 
            this.restartSite.ForeColor = System.Drawing.Color.Black;
            this.restartSite.Location = new System.Drawing.Point(207, 486);
            this.restartSite.Name = "restartSite";
            this.restartSite.Size = new System.Drawing.Size(75, 23);
            this.restartSite.TabIndex = 4;
            this.restartSite.Text = "Restart";
            this.restartSite.UseVisualStyleBackColor = true;
            this.restartSite.Click += new System.EventHandler(this.restartSite_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView3);
            this.groupBox3.Location = new System.Drawing.Point(375, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 192);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pools";
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PoolName,
            this.Mode,
            this.Version,
            this.PoolState});
            this.listView3.Location = new System.Drawing.Point(6, 19);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(378, 167);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView3_ColumnClick);
            // 
            // PoolName
            // 
            this.PoolName.Text = "Name";
            this.PoolName.Width = 120;
            // 
            // Mode
            // 
            this.Mode.Text = "Mode";
            this.Mode.Width = 80;
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 48;
            // 
            // PoolState
            // 
            this.PoolState.Text = "State";
            // 
            // stopSite
            // 
            this.stopSite.ForeColor = System.Drawing.Color.Black;
            this.stopSite.Location = new System.Drawing.Point(117, 486);
            this.stopSite.Name = "stopSite";
            this.stopSite.Size = new System.Drawing.Size(75, 23);
            this.stopSite.TabIndex = 3;
            this.stopSite.Text = "Stop";
            this.stopSite.UseVisualStyleBackColor = true;
            this.stopSite.Click += new System.EventHandler(this.stopSite_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(18, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 265);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Applications";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Application,
            this.AppSite,
            this.AppPool,
            this.AppState});
            this.listView2.Location = new System.Drawing.Point(6, 19);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(735, 240);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            // 
            // Application
            // 
            this.Application.Text = "Application";
            this.Application.Width = 221;
            // 
            // AppSite
            // 
            this.AppSite.Text = "Site";
            this.AppSite.Width = 221;
            // 
            // AppPool
            // 
            this.AppPool.Text = "Pool";
            this.AppPool.Width = 150;
            // 
            // AppState
            // 
            this.AppState.Text = "State";
            this.AppState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AppState.Width = 103;
            // 
            // startSite
            // 
            this.startSite.ForeColor = System.Drawing.Color.Black;
            this.startSite.Location = new System.Drawing.Point(24, 486);
            this.startSite.Name = "startSite";
            this.startSite.Size = new System.Drawing.Size(75, 23);
            this.startSite.TabIndex = 2;
            this.startSite.Text = "Start";
            this.startSite.UseVisualStyleBackColor = true;
            this.startSite.Click += new System.EventHandler(this.startSite_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sites";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Site,
            this.State,
            this.Applications,
            this.Bindings});
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(330, 167);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 22;
            // 
            // Site
            // 
            this.Site.Text = "Site";
            this.Site.Width = 121;
            // 
            // State
            // 
            this.State.Text = "State";
            this.State.Width = 55;
            // 
            // Applications
            // 
            this.Applications.Text = "Applications";
            this.Applications.Width = 69;
            // 
            // Bindings
            // 
            this.Bindings.Text = "Bindings";
            this.Bindings.Width = 55;
            // 
            // SumTabs
            // 
            this.SumTabs.Controls.Add(this.Summary);
            this.SumTabs.Controls.Add(this.treetab);
            this.SumTabs.Controls.Add(this.BindingsTab);
            this.SumTabs.Location = new System.Drawing.Point(12, 12);
            this.SumTabs.Name = "SumTabs";
            this.SumTabs.SelectedIndex = 0;
            this.SumTabs.Size = new System.Drawing.Size(795, 545);
            this.SumTabs.TabIndex = 1;
            // 
            // treetab
            // 
            this.treetab.Controls.Add(this.expBtn);
            this.treetab.Controls.Add(this.colBtn);
            this.treetab.Controls.Add(this.expandBtn);
            this.treetab.Controls.Add(this.treeView1);
            this.treetab.ForeColor = System.Drawing.Color.Black;
            this.treetab.Location = new System.Drawing.Point(4, 22);
            this.treetab.Name = "treetab";
            this.treetab.Padding = new System.Windows.Forms.Padding(3);
            this.treetab.Size = new System.Drawing.Size(787, 519);
            this.treetab.TabIndex = 1;
            this.treetab.Text = "Tree View";
            this.treetab.UseVisualStyleBackColor = true;
            // 
            // expBtn
            // 
            this.expBtn.Location = new System.Drawing.Point(311, 483);
            this.expBtn.Name = "expBtn";
            this.expBtn.Size = new System.Drawing.Size(75, 23);
            this.expBtn.TabIndex = 3;
            this.expBtn.Text = "Export";
            this.expBtn.UseVisualStyleBackColor = true;
            this.expBtn.Click += new System.EventHandler(this.expBtn_Click);
            // 
            // colBtn
            // 
            this.colBtn.Location = new System.Drawing.Point(263, 483);
            this.colBtn.Name = "colBtn";
            this.colBtn.Size = new System.Drawing.Size(36, 23);
            this.colBtn.TabIndex = 2;
            this.colBtn.Text = "-";
            this.colBtn.UseMnemonic = false;
            this.colBtn.UseVisualStyleBackColor = true;
            this.colBtn.Click += new System.EventHandler(this.colBtn_Click);
            // 
            // expandBtn
            // 
            this.expandBtn.Location = new System.Drawing.Point(218, 483);
            this.expandBtn.Name = "expandBtn";
            this.expandBtn.Size = new System.Drawing.Size(39, 23);
            this.expandBtn.TabIndex = 1;
            this.expandBtn.Text = "+";
            this.expandBtn.UseVisualStyleBackColor = true;
            this.expandBtn.Click += new System.EventHandler(this.expandBtn_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(385, 471);
            this.treeView1.TabIndex = 0;
            // 
            // BindingsTab
            // 
            this.BindingsTab.Controls.Add(this.bindinglistView);
            this.BindingsTab.Location = new System.Drawing.Point(4, 22);
            this.BindingsTab.Name = "BindingsTab";
            this.BindingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.BindingsTab.Size = new System.Drawing.Size(787, 519);
            this.BindingsTab.TabIndex = 2;
            this.BindingsTab.Text = "Bindings";
            this.BindingsTab.UseVisualStyleBackColor = true;
            // 
            // bindinglistView
            // 
            this.bindinglistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BindSite,
            this.Binding,
            this.BindName,
            this.BindProtocol});
            this.bindinglistView.Location = new System.Drawing.Point(6, 6);
            this.bindinglistView.Name = "bindinglistView";
            this.bindinglistView.Size = new System.Drawing.Size(773, 507);
            this.bindinglistView.TabIndex = 0;
            this.bindinglistView.UseCompatibleStateImageBehavior = false;
            this.bindinglistView.View = System.Windows.Forms.View.Details;
            this.bindinglistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.bindinglistView_ColumnClick);
            // 
            // BindSite
            // 
            this.BindSite.Text = "Site";
            this.BindSite.Width = 140;
            // 
            // Binding
            // 
            this.Binding.Text = "Binding";
            this.Binding.Width = 220;
            // 
            // BindName
            // 
            this.BindName.Text = "Name";
            this.BindName.Width = 200;
            // 
            // BindProtocol
            // 
            this.BindProtocol.Text = "Protocol";
            // 
            // stoplbl
            // 
            this.stoplbl.AutoSize = true;
            this.stoplbl.Location = new System.Drawing.Point(448, 491);
            this.stoplbl.Name = "stoplbl";
            this.stoplbl.Size = new System.Drawing.Size(35, 13);
            this.stoplbl.TabIndex = 5;
            this.stoplbl.Text = "label2";
            // 
            // runlbl
            // 
            this.runlbl.AutoSize = true;
            this.runlbl.ForeColor = System.Drawing.Color.Green;
            this.runlbl.Location = new System.Drawing.Point(306, 491);
            this.runlbl.Name = "runlbl";
            this.runlbl.Size = new System.Drawing.Size(35, 13);
            this.runlbl.TabIndex = 6;
            this.runlbl.Text = "label2";
            // 
            // totallbl
            // 
            this.totallbl.AutoSize = true;
            this.totallbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totallbl.ForeColor = System.Drawing.Color.Black;
            this.totallbl.Location = new System.Drawing.Point(601, 491);
            this.totallbl.Name = "totallbl";
            this.totallbl.Size = new System.Drawing.Size(34, 13);
            this.totallbl.TabIndex = 5;
            this.totallbl.Text = "Total:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 582);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remotebox);
            this.Controls.Add(this.remotebtn);
            this.Controls.Add(this.SumTabs);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Form1";
            this.Text = "IIS Helper";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Summary.ResumeLayout(false);
            this.Summary.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.SumTabs.ResumeLayout(false);
            this.treetab.ResumeLayout(false);
            this.BindingsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button remotebtn;
        private System.Windows.Forms.TextBox remotebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Summary;
        private System.Windows.Forms.Button restartSite;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader PoolName;
        private System.Windows.Forms.ColumnHeader Mode;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader PoolState;
        private System.Windows.Forms.Button stopSite;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Application;
        private System.Windows.Forms.ColumnHeader AppSite;
        private System.Windows.Forms.ColumnHeader AppPool;
        private System.Windows.Forms.ColumnHeader AppState;
        private System.Windows.Forms.Button startSite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Site;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Applications;
        private System.Windows.Forms.TabControl SumTabs;
        private System.Windows.Forms.TabPage treetab;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button colBtn;
        private System.Windows.Forms.Button expandBtn;
        private System.Windows.Forms.Button expBtn;
        private System.Windows.Forms.Label stoplbl;
        private System.Windows.Forms.Label runlbl;
        private System.Windows.Forms.ColumnHeader Bindings;
        private System.Windows.Forms.TabPage BindingsTab;
        private System.Windows.Forms.ListView bindinglistView;
        private System.Windows.Forms.ColumnHeader BindSite;
        private System.Windows.Forms.ColumnHeader Binding;
        private System.Windows.Forms.ColumnHeader BindName;
        private System.Windows.Forms.ColumnHeader BindProtocol;
        private System.Windows.Forms.Label totallbl;
    }
}

