namespace DemoApp
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(65, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Protocol: uri-scheme-demo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(65, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Name: URI_Scheme_Demo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(65, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(248, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Program: {ProgramPath}\\DemoApp.exe";
			// 
			// btnRemove
			// 
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(69, 137);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(154, 30);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "Remove from Registry";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.RemoveRegKey);
			// 
			// btnAdd
			// 
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAdd.Location = new System.Drawing.Point(229, 137);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(117, 30);
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "Add to Registry";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.AddRegkey);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(417, 224);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
	}
}

