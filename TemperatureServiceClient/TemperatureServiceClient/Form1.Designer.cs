namespace TemperatureServiceClient
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
            this.lstBox_Lista = new System.Windows.Forms.ListBox();
            this.txtNewItem = new System.Windows.Forms.TextBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnGetList = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnGetDate = new System.Windows.Forms.Button();
            this.lblTempC = new System.Windows.Forms.Label();
            this.txtTempC = new System.Windows.Forms.TextBox();
            this.lblTempF = new System.Windows.Forms.Label();
            this.txtTempF = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnFtoC = new System.Windows.Forms.Button();
            this.btnCtoF = new System.Windows.Forms.Button();
            this.lblEuro = new System.Windows.Forms.Label();
            this.txtEuro = new System.Windows.Forms.TextBox();
            this.lblRon = new System.Windows.Forms.Label();
            this.txtRon = new System.Windows.Forms.TextBox();
            this.btnEuroToRon = new System.Windows.Forms.Button();
            this.btnRonToEuro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBox_Lista
            // 
            this.lstBox_Lista.FormattingEnabled = true;
            this.lstBox_Lista.Location = new System.Drawing.Point(12, 42);
            this.lstBox_Lista.Name = "lstBox_Lista";
            this.lstBox_Lista.Size = new System.Drawing.Size(166, 95);
            this.lstBox_Lista.TabIndex = 0;
            // 
            // txtNewItem
            // 
            this.txtNewItem.Location = new System.Drawing.Point(12, 16);
            this.txtNewItem.Name = "txtNewItem";
            this.txtNewItem.Size = new System.Drawing.Size(166, 20);
            this.txtNewItem.TabIndex = 1;
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(12, 143);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(75, 23);
            this.btnAddList.TabIndex = 2;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnGetList
            // 
            this.btnGetList.Location = new System.Drawing.Point(93, 143);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(75, 23);
            this.btnGetList.TabIndex = 3;
            this.btnGetList.Text = "Get 5 Items";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 178);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Data";
            // 
            // btnGetDate
            // 
            this.btnGetDate.Location = new System.Drawing.Point(93, 194);
            this.btnGetDate.Name = "btnGetDate";
            this.btnGetDate.Size = new System.Drawing.Size(75, 23);
            this.btnGetDate.TabIndex = 5;
            this.btnGetDate.Text = "Get Date";
            this.btnGetDate.UseVisualStyleBackColor = true;
            this.btnGetDate.Click += new System.EventHandler(this.btnGetDate_Click);
            // 
            // lblTempC
            // 
            this.lblTempC.AutoSize = true;
            this.lblTempC.Location = new System.Drawing.Point(254, 42);
            this.lblTempC.Name = "lblTempC";
            this.lblTempC.Size = new System.Drawing.Size(45, 13);
            this.lblTempC.TabIndex = 6;
            this.lblTempC.Text = "Temp C";
            // 
            // txtTempC
            // 
            this.txtTempC.Location = new System.Drawing.Point(305, 39);
            this.txtTempC.Name = "txtTempC";
            this.txtTempC.Size = new System.Drawing.Size(100, 20);
            this.txtTempC.TabIndex = 7;
            // 
            // lblTempF
            // 
            this.lblTempF.AutoSize = true;
            this.lblTempF.Location = new System.Drawing.Point(254, 68);
            this.lblTempF.Name = "lblTempF";
            this.lblTempF.Size = new System.Drawing.Size(45, 13);
            this.lblTempF.TabIndex = 8;
            this.lblTempF.Text = "Temp F";
            // 
            // txtTempF
            // 
            this.txtTempF.Location = new System.Drawing.Point(305, 65);
            this.txtTempF.Name = "txtTempF";
            this.txtTempF.Size = new System.Drawing.Size(100, 20);
            this.txtTempF.TabIndex = 9;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(254, 94);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(45, 13);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Rezultat";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(305, 91);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 11;
            // 
            // btnFtoC
            // 
            this.btnFtoC.Location = new System.Drawing.Point(305, 117);
            this.btnFtoC.Name = "btnFtoC";
            this.btnFtoC.Size = new System.Drawing.Size(48, 23);
            this.btnFtoC.TabIndex = 12;
            this.btnFtoC.Text = "F to C";
            this.btnFtoC.UseVisualStyleBackColor = true;
            this.btnFtoC.Click += new System.EventHandler(this.btnFtoC_Click);
            // 
            // btnCtoF
            // 
            this.btnCtoF.Location = new System.Drawing.Point(359, 117);
            this.btnCtoF.Name = "btnCtoF";
            this.btnCtoF.Size = new System.Drawing.Size(46, 23);
            this.btnCtoF.TabIndex = 13;
            this.btnCtoF.Text = "C to F";
            this.btnCtoF.UseVisualStyleBackColor = true;
            this.btnCtoF.Click += new System.EventHandler(this.btnCtoF_Click);
            // 
            // lblEuro
            // 
            this.lblEuro.AutoSize = true;
            this.lblEuro.Location = new System.Drawing.Point(254, 178);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(65, 13);
            this.lblEuro.TabIndex = 14;
            this.lblEuro.Text = "Euro to Ron";
            // 
            // txtEuro
            // 
            this.txtEuro.Location = new System.Drawing.Point(325, 175);
            this.txtEuro.Name = "txtEuro";
            this.txtEuro.Size = new System.Drawing.Size(80, 20);
            this.txtEuro.TabIndex = 15;
            // 
            // lblRon
            // 
            this.lblRon.AutoSize = true;
            this.lblRon.Location = new System.Drawing.Point(254, 204);
            this.lblRon.Name = "lblRon";
            this.lblRon.Size = new System.Drawing.Size(29, 13);
            this.lblRon.TabIndex = 16;
            this.lblRon.Text = "RON";
            // 
            // txtRon
            // 
            this.txtRon.Location = new System.Drawing.Point(325, 201);
            this.txtRon.Name = "txtRon";
            this.txtRon.Size = new System.Drawing.Size(80, 20);
            this.txtRon.TabIndex = 17;
            // 
            // btnEuroToRon
            // 
            this.btnEuroToRon.Location = new System.Drawing.Point(325, 227);
            this.btnEuroToRon.Name = "btnEuroToRon";
            this.btnEuroToRon.Size = new System.Drawing.Size(80, 23);
            this.btnEuroToRon.TabIndex = 18;
            this.btnEuroToRon.Text = "€ → RON";
            this.btnEuroToRon.UseVisualStyleBackColor = true;
            this.btnEuroToRon.Click += new System.EventHandler(this.btnEuroToRon_Click);
            // 
            // btnRonToEuro
            // 
            this.btnRonToEuro.Location = new System.Drawing.Point(325, 256);
            this.btnRonToEuro.Name = "btnRonToEuro";
            this.btnRonToEuro.Size = new System.Drawing.Size(80, 23);
            this.btnRonToEuro.TabIndex = 19;
            this.btnRonToEuro.Text = "RON → €";
            this.btnRonToEuro.UseVisualStyleBackColor = true;
            this.btnRonToEuro.Click += new System.EventHandler(this.btnRonToEuro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 291);
            this.Controls.Add(this.btnRonToEuro);
            this.Controls.Add(this.btnEuroToRon);
            this.Controls.Add(this.txtRon);
            this.Controls.Add(this.lblRon);
            this.Controls.Add(this.txtEuro);
            this.Controls.Add(this.lblEuro);
            this.Controls.Add(this.btnCtoF);
            this.Controls.Add(this.btnFtoC);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtTempF);
            this.Controls.Add(this.lblTempF);
            this.Controls.Add(this.txtTempC);
            this.Controls.Add(this.lblTempC);
            this.Controls.Add(this.btnGetDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.txtNewItem);
            this.Controls.Add(this.lstBox_Lista);
            this.Name = "Form1";
            this.Text = "Temperature Web Service Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstBox_Lista;
        private System.Windows.Forms.TextBox txtNewItem;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnGetDate;
        private System.Windows.Forms.Label lblTempC;
        private System.Windows.Forms.TextBox txtTempC;
        private System.Windows.Forms.Label lblTempF;
        private System.Windows.Forms.TextBox txtTempF;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnFtoC;
        private System.Windows.Forms.Button btnCtoF;
        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.TextBox txtEuro;
        private System.Windows.Forms.Label lblRon;
        private System.Windows.Forms.TextBox txtRon;
        private System.Windows.Forms.Button btnEuroToRon;
        private System.Windows.Forms.Button btnRonToEuro;
    }
}