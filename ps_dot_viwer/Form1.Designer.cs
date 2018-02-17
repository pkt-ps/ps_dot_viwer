namespace ps_dot_viwer {
	partial class Form1 {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.label_mesagge = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextMenu_loadSubDirectory = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_scaleout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_1sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_2sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_5sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_10sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_15sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_20sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_30sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_60sec = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_border = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_end = new System.Windows.Forms.ToolStripMenuItem();
			this.アンカーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_leftup = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_leftdown = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_rightup = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu_rightdown = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_mesagge
			// 
			this.label_mesagge.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label_mesagge.AutoSize = true;
			this.label_mesagge.BackColor = System.Drawing.Color.Lavender;
			this.label_mesagge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_mesagge.Location = new System.Drawing.Point(44, 100);
			this.label_mesagge.Name = "label_mesagge";
			this.label_mesagge.Size = new System.Drawing.Size(100, 16);
			this.label_mesagge.TabIndex = 0;
			this.label_mesagge.Text = "message_label";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(200, 200);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenu_loadSubDirectory,
            this.contextMenu_scaleout,
            this.toolStripMenuItem1,
            this.contextMenu_border,
            this.アンカーToolStripMenuItem,
            this.contextMenu_end});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(168, 158);
			// 
			// contextMenu_loadSubDirectory
			// 
			this.contextMenu_loadSubDirectory.CheckOnClick = true;
			this.contextMenu_loadSubDirectory.Name = "contextMenu_loadSubDirectory";
			this.contextMenu_loadSubDirectory.Size = new System.Drawing.Size(167, 22);
			this.contextMenu_loadSubDirectory.Text = "サブディレクトリ読込";
			// 
			// contextMenu_scaleout
			// 
			this.contextMenu_scaleout.CheckOnClick = true;
			this.contextMenu_scaleout.Name = "contextMenu_scaleout";
			this.contextMenu_scaleout.Size = new System.Drawing.Size(167, 22);
			this.contextMenu_scaleout.Text = "縮小する";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenu_1sec,
            this.contextMenu_2sec,
            this.contextMenu_5sec,
            this.contextMenu_10sec,
            this.contextMenu_15sec,
            this.contextMenu_20sec,
            this.contextMenu_30sec,
            this.contextMenu_60sec});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
			this.toolStripMenuItem1.Text = "インターバル";
			// 
			// contextMenu_1sec
			// 
			this.contextMenu_1sec.Name = "contextMenu_1sec";
			this.contextMenu_1sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_1sec.Tag = "";
			this.contextMenu_1sec.Text = "1秒";
			// 
			// contextMenu_2sec
			// 
			this.contextMenu_2sec.Name = "contextMenu_2sec";
			this.contextMenu_2sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_2sec.Tag = "";
			this.contextMenu_2sec.Text = "2秒";
			// 
			// contextMenu_5sec
			// 
			this.contextMenu_5sec.Name = "contextMenu_5sec";
			this.contextMenu_5sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_5sec.Tag = "";
			this.contextMenu_5sec.Text = "5秒";
			// 
			// contextMenu_10sec
			// 
			this.contextMenu_10sec.Name = "contextMenu_10sec";
			this.contextMenu_10sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_10sec.Tag = "";
			this.contextMenu_10sec.Text = "10秒";
			// 
			// contextMenu_15sec
			// 
			this.contextMenu_15sec.Name = "contextMenu_15sec";
			this.contextMenu_15sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_15sec.Tag = "";
			this.contextMenu_15sec.Text = "15秒";
			// 
			// contextMenu_20sec
			// 
			this.contextMenu_20sec.Name = "contextMenu_20sec";
			this.contextMenu_20sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_20sec.Text = "20秒";
			// 
			// contextMenu_30sec
			// 
			this.contextMenu_30sec.Name = "contextMenu_30sec";
			this.contextMenu_30sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_30sec.Text = "30秒";
			// 
			// contextMenu_60sec
			// 
			this.contextMenu_60sec.Name = "contextMenu_60sec";
			this.contextMenu_60sec.Size = new System.Drawing.Size(98, 22);
			this.contextMenu_60sec.Text = "60秒";
			// 
			// contextMenu_border
			// 
			this.contextMenu_border.CheckOnClick = true;
			this.contextMenu_border.Name = "contextMenu_border";
			this.contextMenu_border.Size = new System.Drawing.Size(167, 22);
			this.contextMenu_border.Text = "枠表示";
			// 
			// contextMenu_end
			// 
			this.contextMenu_end.Name = "contextMenu_end";
			this.contextMenu_end.Size = new System.Drawing.Size(167, 22);
			this.contextMenu_end.Text = "終了";
			// 
			// アンカーToolStripMenuItem
			// 
			this.アンカーToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenu_leftup,
            this.contextMenu_leftdown,
            this.contextMenu_rightup,
            this.contextMenu_rightdown});
			this.アンカーToolStripMenuItem.Name = "アンカーToolStripMenuItem";
			this.アンカーToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.アンカーToolStripMenuItem.Text = "アンカー";
			// 
			// contextMenu_leftup
			// 
			this.contextMenu_leftup.CheckOnClick = true;
			this.contextMenu_leftup.Name = "contextMenu_leftup";
			this.contextMenu_leftup.Size = new System.Drawing.Size(152, 22);
			this.contextMenu_leftup.Text = "左上";
			// 
			// contextMenu_leftdown
			// 
			this.contextMenu_leftdown.CheckOnClick = true;
			this.contextMenu_leftdown.Name = "contextMenu_leftdown";
			this.contextMenu_leftdown.Size = new System.Drawing.Size(152, 22);
			this.contextMenu_leftdown.Text = "左下";
			// 
			// contextMenu_rightup
			// 
			this.contextMenu_rightup.CheckOnClick = true;
			this.contextMenu_rightup.Name = "contextMenu_rightup";
			this.contextMenu_rightup.Size = new System.Drawing.Size(152, 22);
			this.contextMenu_rightup.Text = "右上";
			// 
			// contextMenu_rightdown
			// 
			this.contextMenu_rightdown.CheckOnClick = true;
			this.contextMenu_rightdown.Name = "contextMenu_rightdown";
			this.contextMenu_rightdown.Size = new System.Drawing.Size(152, 22);
			this.contextMenu_rightdown.Text = "右下";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Lavender;
			this.ClientSize = new System.Drawing.Size(200, 200);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.ControlBox = false;
			this.Controls.Add(this.label_mesagge);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Fuchsia;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_mesagge;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_end;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_loadSubDirectory;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_scaleout;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_1sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_2sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_5sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_10sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_15sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_20sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_30sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_60sec;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_border;
		private System.Windows.Forms.ToolStripMenuItem アンカーToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_leftup;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_leftdown;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_rightup;
		private System.Windows.Forms.ToolStripMenuItem contextMenu_rightdown;
	}
}

