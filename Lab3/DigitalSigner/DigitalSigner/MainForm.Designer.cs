namespace DigitalSigner
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.signatureBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.hashBox = new System.Windows.Forms.TextBox();
            this.keysBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nBox = new System.Windows.Forms.TextBox();
            this.decryptHashBox = new System.Windows.Forms.TextBox();
            this.CheckSignature = new System.Windows.Forms.Button();
            this.checkFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signatureBox
            // 
            this.signatureBox.Location = new System.Drawing.Point(121, 12);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(367, 120);
            this.signatureBox.TabIndex = 0;
            this.signatureBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 47);
            this.button2.TabIndex = 2;
            this.button2.Text = "Get Signature";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // hashBox
            // 
            this.hashBox.Location = new System.Drawing.Point(37, 155);
            this.hashBox.Name = "hashBox";
            this.hashBox.Size = new System.Drawing.Size(68, 20);
            this.hashBox.TabIndex = 4;
            // 
            // keysBox
            // 
            this.keysBox.Location = new System.Drawing.Point(121, 148);
            this.keysBox.Name = "keysBox";
            this.keysBox.Size = new System.Drawing.Size(367, 180);
            this.keysBox.TabIndex = 5;
            this.keysBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(514, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "D";
            // 
            // dBox
            // 
            this.dBox.Location = new System.Drawing.Point(565, 24);
            this.dBox.Multiline = true;
            this.dBox.Name = "dBox";
            this.dBox.Size = new System.Drawing.Size(322, 69);
            this.dBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(514, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "N";
            // 
            // nBox
            // 
            this.nBox.Location = new System.Drawing.Point(565, 131);
            this.nBox.Multiline = true;
            this.nBox.Name = "nBox";
            this.nBox.Size = new System.Drawing.Size(322, 69);
            this.nBox.TabIndex = 11;
            // 
            // decryptHashBox
            // 
            this.decryptHashBox.Location = new System.Drawing.Point(565, 247);
            this.decryptHashBox.Name = "decryptHashBox";
            this.decryptHashBox.Size = new System.Drawing.Size(68, 20);
            this.decryptHashBox.TabIndex = 12;
            // 
            // CheckSignature
            // 
            this.CheckSignature.Location = new System.Drawing.Point(717, 220);
            this.CheckSignature.Name = "CheckSignature";
            this.CheckSignature.Size = new System.Drawing.Size(93, 47);
            this.CheckSignature.TabIndex = 13;
            this.CheckSignature.Text = "Check Signature";
            this.CheckSignature.UseVisualStyleBackColor = true;
            this.CheckSignature.Click += new System.EventHandler(this.CheckSignature_Click);
            // 
            // checkFileDialog
            // 
            this.checkFileDialog.FileName = "openFileDialog2";
            // 
            // resultBox
            // 
            this.resultBox.Location = new System.Drawing.Point(665, 308);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(68, 20);
            this.resultBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Is file authentic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hash";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(527, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hash";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 379);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.CheckSignature);
            this.Controls.Add(this.decryptHashBox);
            this.Controls.Add(this.nBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keysBox);
            this.Controls.Add(this.hashBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.signatureBox);
            this.Name = "MainForm";
            this.Text = "DigitalSign";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox signatureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox hashBox;
        private System.Windows.Forms.RichTextBox keysBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nBox;
        private System.Windows.Forms.TextBox decryptHashBox;
        private System.Windows.Forms.Button CheckSignature;
        private System.Windows.Forms.OpenFileDialog checkFileDialog;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

