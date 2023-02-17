namespace FullExample
{
    partial class FullExampleForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <parameters name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</parameters>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this._simulateButton = new System.Windows.Forms.Button();
            this.newDataButton = new System.Windows.Forms.RadioButton();
            this.updateButton = new System.Windows.Forms.RadioButton();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.apiOverlaysButton = new System.Windows.Forms.RadioButton();
            this.openCVOverlaysButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 122);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "Camera to Skull";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 267);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Camera to Maya";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 55);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 27);
            this.button2.TabIndex = 10;
            this.button2.Text = "Skull WireFrame";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 22);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 27);
            this.button5.TabIndex = 11;
            this.button5.Text = "Skull PointCloud";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 332);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 27);
            this.button6.TabIndex = 13;
            this.button6.Text = "Gauss PointCloud";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(7, 366);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 27);
            this.button7.TabIndex = 12;
            this.button7.Text = "Gauss WireFrame";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(7, 179);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 28);
            this.button8.TabIndex = 14;
            this.button8.Text = "On";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(77, 179);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(58, 28);
            this.button9.TabIndex = 15;
            this.button9.Text = "Off";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Skull Normals";
            // 
            // _mainPanel
            // 
            this._mainPanel.Location = new System.Drawing.Point(187, 13);
            this._mainPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1423, 908);
            this._mainPanel.TabIndex = 17;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(7, 433);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(128, 35);
            this.button10.TabIndex = 18;
            this.button10.Text = "Camera to Gauss";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(7, 89);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(128, 27);
            this.button11.TabIndex = 19;
            this.button11.Text = "Skull Filled";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(7, 399);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(128, 27);
            this.button12.TabIndex = 20;
            this.button12.Text = "Gauss Filled";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 647);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disassemble on move :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 666);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 37);
            this.button3.TabIndex = 0;
            this.button3.Text = "On";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(79, 666);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(46, 37);
            this.button13.TabIndex = 21;
            this.button13.Text = "Off";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // _simulateButton
            // 
            this._simulateButton.BackColor = System.Drawing.Color.Red;
            this._simulateButton.Location = new System.Drawing.Point(7, 472);
            this._simulateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._simulateButton.Name = "_simulateButton";
            this._simulateButton.Size = new System.Drawing.Size(135, 77);
            this._simulateButton.TabIndex = 0;
            this._simulateButton.Text = "Simulate New Gauss";
            this._simulateButton.UseVisualStyleBackColor = false;
            this._simulateButton.Click += new System.EventHandler(this.button14_Click);
            // 
            // newDataButton
            // 
            this.newDataButton.AutoSize = true;
            this.newDataButton.Location = new System.Drawing.Point(7, 22);
            this.newDataButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newDataButton.Name = "newDataButton";
            this.newDataButton.Size = new System.Drawing.Size(113, 19);
            this.newDataButton.TabIndex = 22;
            this.newDataButton.Text = "Create New Data";
            this.newDataButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.AutoSize = true;
            this.updateButton.Checked = true;
            this.updateButton.Location = new System.Drawing.Point(7, 48);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(106, 19);
            this.updateButton.TabIndex = 23;
            this.updateButton.TabStop = true;
            this.updateButton.Text = "Update Vertices";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(7, 225);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(128, 35);
            this.button15.TabIndex = 25;
            this.button15.Text = "Camera to Face";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Red;
            this.button16.Location = new System.Drawing.Point(7, 144);
            this.button16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(135, 32);
            this.button16.TabIndex = 26;
            this.button16.Text = "Simulate 2D camera";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Red;
            this.button17.Location = new System.Drawing.Point(7, 22);
            this.button17.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(132, 35);
            this.button17.TabIndex = 27;
            this.button17.Text = "Capture from camera";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // apiOverlaysButton
            // 
            this.apiOverlaysButton.AutoSize = true;
            this.apiOverlaysButton.Checked = true;
            this.apiOverlaysButton.Location = new System.Drawing.Point(7, 22);
            this.apiOverlaysButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.apiOverlaysButton.Name = "apiOverlaysButton";
            this.apiOverlaysButton.Size = new System.Drawing.Size(130, 19);
            this.apiOverlaysButton.TabIndex = 28;
            this.apiOverlaysButton.TabStop = true;
            this.apiOverlaysButton.Text = "Display API overlays";
            this.apiOverlaysButton.UseVisualStyleBackColor = true;
            // 
            // openCVOverlaysButton
            // 
            this.openCVOverlaysButton.AutoSize = true;
            this.openCVOverlaysButton.Location = new System.Drawing.Point(7, 48);
            this.openCVOverlaysButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openCVOverlaysButton.Name = "openCVOverlaysButton";
            this.openCVOverlaysButton.Size = new System.Drawing.Size(115, 19);
            this.openCVOverlaysButton.TabIndex = 29;
            this.openCVOverlaysButton.TabStop = true;
            this.openCVOverlaysButton.Text = "OpenCV overlays";
            this.openCVOverlaysButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.openCVOverlaysButton);
            this.groupBox1.Controls.Add(this.apiOverlaysButton);
            this.groupBox1.Location = new System.Drawing.Point(7, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(149, 74);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overlays type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.newDataButton);
            this.groupBox2.Controls.Add(this.updateButton);
            this.groupBox2.Location = new System.Drawing.Point(7, 556);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(140, 76);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update mode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button17);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(10, 735);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(164, 186);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2D";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button15);
            this.groupBox4.Controls.Add(this._simulateButton);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button13);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button12);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Location = new System.Drawing.Point(10, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(164, 714);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "3D";
            // 
            // FullExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1623, 931);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this._mainPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FullExampleForm";
            this.Text = "MulDisplay Test";
            this.Shown += new System.EventHandler(this.Form1_Shown);
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

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button _simulateButton;
        private System.Windows.Forms.RadioButton newDataButton;
        private System.Windows.Forms.RadioButton updateButton;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.RadioButton apiOverlaysButton;
        private System.Windows.Forms.RadioButton openCVOverlaysButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

