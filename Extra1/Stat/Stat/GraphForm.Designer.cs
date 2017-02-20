namespace Stat
{
    partial class GraphForm
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
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // GraphPanel
            // 
            this.GraphPanel.AutoScroll = true;
            this.GraphPanel.Location = new System.Drawing.Point(12, 12);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(541, 355);
            this.GraphPanel.TabIndex = 0;
            this.GraphPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GraphPanel_Scroll);
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // StyleBox
            // 
            this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StyleBox.FormattingEnabled = true;
            this.StyleBox.Location = new System.Drawing.Point(12, 397);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(176, 21);
            this.StyleBox.TabIndex = 3;
            this.StyleBox.SelectedIndexChanged += new System.EventHandler(this.StyleBox_SelectedIndexChanged);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 423);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.GraphPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphForm";
            this.Text = "Graphics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GraphPanel;
        private System.Windows.Forms.ComboBox StyleBox;
    }
}