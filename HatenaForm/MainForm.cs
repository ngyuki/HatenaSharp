using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.IO;
using System.Diagnostics;

namespace HatenaForm
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			string[] list = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			if (list.Length == 0)
			{
				return;
			}

			RenderSample(list[0]);

			uiBrowser.Dock = DockStyle.Fill;
			uiBrowser.Visible = true;
		}

		private void RenderSample(string fn)
		{
			string input;

			using (var reader = new StreamReader(fn))
			{
				input = reader.ReadToEnd();
			}

			uiBrowser.DocumentText = HatenaSharp.Render(input);
		}

		private void uiBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "file")
			{
				e.Cancel = true;
				RenderSample(e.Url.LocalPath);
			}
			else if (e.Url.Scheme == "about")
			{
			}
			else
			{
				e.Cancel = true;
				Process.Start(e.Url.OriginalString);
			}
		}
	}
}
