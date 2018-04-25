using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;
namespace Sorter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnRun;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        ReadTXT rdr = new ReadTXT();
        List<NameClass> list;
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRun = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(32, 24);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(200, 56);
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "&Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(264, 104);
			this.Controls.Add(this.btnRun);
			this.Name = "Form1";
			this.Text = "Sorter";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRun_Click(object sender, System.EventArgs e)
		{
            //TODO: Insert code here...
            DirectoryInfo dir = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);
            String path=dir.Parent.Parent.FullName.ToString();
            String txtPath = path + @"\input.txt";
            list = rdr.openTxt(txtPath);
            IEnumerable<NameClass> sortedName =
                from NameClass in list
                orderby NameClass.lastName ascending, NameClass.firstName ascending
                select NameClass;
            rdr.saveToTxt(path,sortedName);
        }
	}
}
