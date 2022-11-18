/* UserInterface.Designer.cs
 * Author: Ian Flores
 */
namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// The user interface
    /// </summary>
    partial class UserInterface
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
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenRawDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenHashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSaveHashTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenHashTableDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRank.Location = new System.Drawing.Point(99, 176);
            this.uxRank.Margin = new System.Windows.Forms.Padding(4);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(332, 34);
            this.uxRank.TabIndex = 46;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(13, 180);
            this.uxRankLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(74, 29);
            this.uxRankLabel.TabIndex = 45;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(164, 133);
            this.uxFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(267, 34);
            this.uxFrequency.TabIndex = 44;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(13, 137);
            this.uxFrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(133, 29);
            this.uxFrequencyLabel.TabIndex = 43;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookup.Location = new System.Drawing.Point(19, 75);
            this.uxLookup.Margin = new System.Windows.Forms.Padding(4);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(412, 50);
            this.uxLookup.TabIndex = 42;
            this.uxLookup.Text = "Get Statistics";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(109, 32);
            this.uxName.Margin = new System.Windows.Forms.Padding(4);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(321, 34);
            this.uxName.TabIndex = 41;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNameLabel.Location = new System.Drawing.Point(13, 36);
            this.uxNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(84, 29);
            this.uxNameLabel.TabIndex = 40;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Text Files|*.txt|All files|*.*";
            this.uxOpenDialog.Title = "Open Raw Data File";
            // 
            // uxSaveDialog
            // 
            this.uxSaveDialog.Filter = "Hash Tables|*.ht|All files|*.*";
            this.uxSaveDialog.Title = "Open Hash Table";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 28);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenRawDataFileToolStripMenuItem,
            this.uxOpenHashTableToolStripMenuItem,
            this.uxSaveHashTableToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uxOpenRawDataFileToolStripMenuItem
            // 
            this.uxOpenRawDataFileToolStripMenuItem.Name = "uxOpenRawDataFileToolStripMenuItem";
            this.uxOpenRawDataFileToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uxOpenRawDataFileToolStripMenuItem.Text = "Open Raw Data File";
            this.uxOpenRawDataFileToolStripMenuItem.Click += new System.EventHandler(this.openRawDataFileToolStripMenuItem_Click);
            // 
            // uxOpenHashTableToolStripMenuItem
            // 
            this.uxOpenHashTableToolStripMenuItem.Name = "uxOpenHashTableToolStripMenuItem";
            this.uxOpenHashTableToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uxOpenHashTableToolStripMenuItem.Text = "Open Hash Table";
            this.uxOpenHashTableToolStripMenuItem.Click += new System.EventHandler(this.openHashTableToolStripMenuItem_Click);
            // 
            // uxSaveHashTableToolStripMenuItem
            // 
            this.uxSaveHashTableToolStripMenuItem.Enabled = false;
            this.uxSaveHashTableToolStripMenuItem.Name = "uxSaveHashTableToolStripMenuItem";
            this.uxSaveHashTableToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.uxSaveHashTableToolStripMenuItem.Text = "Save Hash Table";
            this.uxSaveHashTableToolStripMenuItem.Click += new System.EventHandler(this.saveHashTableToolStripMenuItem_Click);
            // 
            // uxOpenHashTableDialog
            // 
            this.uxOpenHashTableDialog.Title = "Open Hash Table";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 226);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(465, 273);
            this.MinimumSize = new System.Drawing.Size(465, 273);
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxOpenRawDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxOpenHashTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uxSaveHashTableToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog uxOpenHashTableDialog;
    }
}

