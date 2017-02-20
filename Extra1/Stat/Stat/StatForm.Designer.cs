namespace Stat
{
    partial class StatForm
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
            this.StatPanel = new System.Windows.Forms.Panel();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.GraphButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StatPanel
            // 
            this.StatPanel.AutoScroll = true;
            this.StatPanel.Location = new System.Drawing.Point(13, 13);
            this.StatPanel.Name = "StatPanel";
            this.StatPanel.Size = new System.Drawing.Size(254, 372);
            this.StatPanel.TabIndex = 0;
            // 
            // StyleBox
            // 
            this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StyleBox.FormattingEnabled = true;
            this.StyleBox.Location = new System.Drawing.Point(12, 391);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(176, 21);
            this.StyleBox.TabIndex = 2;
            this.StyleBox.SelectedIndexChanged += new System.EventHandler(this.StyleBox_SelectedIndexChanged);
            // 
            // GraphButton
            // 
            this.GraphButton.Location = new System.Drawing.Point(195, 391);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(75, 23);
            this.GraphButton.TabIndex = 3;
            this.GraphButton.Text = "График";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // StatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 424);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.StatPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatForm";
            this.Text = "Statistics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StatPanel;
        private System.Windows.Forms.ComboBox StyleBox;
        private System.Windows.Forms.Button GraphButton;
    }
}