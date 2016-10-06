namespace ArduinoSQLInterface
{
    partial class frmMain
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
            this.btnAssign = new System.Windows.Forms.Button();
            this.txtCurrPort = new System.Windows.Forms.TextBox();
            this.txtChaPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtxtMessages = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnAny = new System.Windows.Forms.RadioButton();
            this.rbtnIP = new System.Windows.Forms.RadioButton();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Port:";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(20, 126);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Assign Port";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // txtCurrPort
            // 
            this.txtCurrPort.Location = new System.Drawing.Point(13, 41);
            this.txtCurrPort.Name = "txtCurrPort";
            this.txtCurrPort.ReadOnly = true;
            this.txtCurrPort.Size = new System.Drawing.Size(100, 20);
            this.txtCurrPort.TabIndex = 2;
            // 
            // txtChaPort
            // 
            this.txtChaPort.Location = new System.Drawing.Point(13, 89);
            this.txtChaPort.Name = "txtChaPort";
            this.txtChaPort.Size = new System.Drawing.Size(100, 20);
            this.txtChaPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Change Port To:";
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.Location = new System.Drawing.Point(22, 85);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(75, 23);
            this.btnDeactivate.TabIndex = 6;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = true;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAssign);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtChaPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 193);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnActivate);
            this.groupBox2.Controls.Add(this.btnDeactivate);
            this.groupBox2.Location = new System.Drawing.Point(309, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 193);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtxtMessages);
            this.groupBox3.Location = new System.Drawing.Point(12, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 139);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Messages";
            // 
            // rtxtMessages
            // 
            this.rtxtMessages.Location = new System.Drawing.Point(13, 20);
            this.rtxtMessages.Name = "rtxtMessages";
            this.rtxtMessages.ReadOnly = true;
            this.rtxtMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtMessages.Size = new System.Drawing.Size(396, 105);
            this.rtxtMessages.TabIndex = 0;
            this.rtxtMessages.Text = "";
            this.rtxtMessages.TextChanged += new System.EventHandler(this.rtxtMessages_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Recieve From:";
            // 
            // rbtnAny
            // 
            this.rbtnAny.AutoSize = true;
            this.rbtnAny.Location = new System.Drawing.Point(9, 44);
            this.rbtnAny.Name = "rbtnAny";
            this.rbtnAny.Size = new System.Drawing.Size(43, 17);
            this.rbtnAny.TabIndex = 10;
            this.rbtnAny.TabStop = true;
            this.rbtnAny.Text = "Any";
            this.rbtnAny.UseVisualStyleBackColor = true;
            // 
            // rbtnIP
            // 
            this.rbtnIP.AutoSize = true;
            this.rbtnIP.Location = new System.Drawing.Point(9, 66);
            this.rbtnIP.Name = "rbtnIP";
            this.rbtnIP.Size = new System.Drawing.Size(35, 17);
            this.rbtnIP.TabIndex = 11;
            this.rbtnIP.TabStop = true;
            this.rbtnIP.Text = "IP";
            this.rbtnIP.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(6, 89);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtIP);
            this.groupBox4.Controls.Add(this.rbtnAny);
            this.groupBox4.Controls.Add(this.rbtnIP);
            this.groupBox4.Location = new System.Drawing.Point(158, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 193);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source";
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(22, 37);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(75, 23);
            this.btnActivate.TabIndex = 5;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Assign IP";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 375);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Arduino To SQL Interface";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.TextBox txtCurrPort;
        private System.Windows.Forms.TextBox txtChaPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtxtMessages;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnAny;
        private System.Windows.Forms.RadioButton rbtnIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
    }
}

