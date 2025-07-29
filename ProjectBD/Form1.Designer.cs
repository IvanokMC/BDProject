namespace ProjectBD
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGestionarMusica = new System.Windows.Forms.Button();
            this.btnGestionarVentas = new System.Windows.Forms.Button();
            this.btnGestionarClientes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionarMusica
            // 
            this.btnGestionarMusica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarMusica.Location = new System.Drawing.Point(100, 60);
            this.btnGestionarMusica.Name = "btnGestionarMusica";
            this.btnGestionarMusica.Size = new System.Drawing.Size(200, 60);
            this.btnGestionarMusica.TabIndex = 0;
            this.btnGestionarMusica.Text = "Gestionar Música";
            this.btnGestionarMusica.UseVisualStyleBackColor = true;
            this.btnGestionarMusica.Click += new System.EventHandler(this.btnGestionarMusica_Click);
            // 
            // btnGestionarVentas
            // 
            this.btnGestionarVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarVentas.Location = new System.Drawing.Point(100, 140);
            this.btnGestionarVentas.Name = "btnGestionarVentas";
            this.btnGestionarVentas.Size = new System.Drawing.Size(200, 60);
            this.btnGestionarVentas.TabIndex = 1;
            this.btnGestionarVentas.Text = "Gestionar Ventas";
            this.btnGestionarVentas.UseVisualStyleBackColor = true;
            this.btnGestionarVentas.Click += new System.EventHandler(this.btnGestionarVentas_Click);
            // 
            // btnGestionarClientes
            // 
            this.btnGestionarClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarClientes.Location = new System.Drawing.Point(100, 220);
            this.btnGestionarClientes.Name = "btnGestionarClientes";
            this.btnGestionarClientes.Size = new System.Drawing.Size(200, 60);
            this.btnGestionarClientes.TabIndex = 2;
            this.btnGestionarClientes.Text = "Gestionar Clientes";
            this.btnGestionarClientes.UseVisualStyleBackColor = true;
            this.btnGestionarClientes.Click += new System.EventHandler(this.btnGestionarClientes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.btnGestionarClientes);
            this.Controls.Add(this.btnGestionarVentas);
            this.Controls.Add(this.btnGestionarMusica);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Melodia Urbana - Menú Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionarMusica;
        private System.Windows.Forms.Button btnGestionarVentas;
        private System.Windows.Forms.Button btnGestionarClientes;
    }
}