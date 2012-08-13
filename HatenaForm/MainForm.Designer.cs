namespace HatenaForm
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.uiBrowser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// uiBrowser
			// 
			this.uiBrowser.Location = new System.Drawing.Point(59, 115);
			this.uiBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.uiBrowser.Name = "uiBrowser";
			this.uiBrowser.Size = new System.Drawing.Size(341, 162);
			this.uiBrowser.TabIndex = 2;
			this.uiBrowser.Visible = false;
			this.uiBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.uiBrowser_Navigating);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 376);
			this.Controls.Add(this.uiBrowser);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser uiBrowser;
	}
}

