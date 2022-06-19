
namespace Aplicacion
{
    partial class FrmCargarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarCliente));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lstRegistroClientes = new System.Windows.Forms.ListBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscarPorDni = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtBuscarPorDni = new System.Windows.Forms.TextBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(216, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Seleccione el cliente:";
            // 
            // lstRegistroClientes
            // 
            this.lstRegistroClientes.BackColor = System.Drawing.Color.White;
            this.lstRegistroClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRegistroClientes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstRegistroClientes.ForeColor = System.Drawing.Color.Black;
            this.lstRegistroClientes.FormattingEnabled = true;
            this.lstRegistroClientes.ItemHeight = 30;
            this.lstRegistroClientes.Location = new System.Drawing.Point(12, 55);
            this.lstRegistroClientes.Name = "lstRegistroClientes";
            this.lstRegistroClientes.Size = new System.Drawing.Size(680, 210);
            this.lstRegistroClientes.TabIndex = 1;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSeleccionar.Location = new System.Drawing.Point(13, 321);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(122, 45);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtras.Location = new System.Drawing.Point(549, 321);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(144, 45);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(287, 321);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(122, 45);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscarPorDni
            // 
            this.btnBuscarPorDni.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscarPorDni.FlatAppearance.BorderSize = 0;
            this.btnBuscarPorDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPorDni.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuscarPorDni.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarPorDni.Location = new System.Drawing.Point(414, 20);
            this.btnBuscarPorDni.Name = "btnBuscarPorDni";
            this.btnBuscarPorDni.Size = new System.Drawing.Size(113, 29);
            this.btnBuscarPorDni.TabIndex = 6;
            this.btnBuscarPorDni.Text = "Buscar por DNI";
            this.btnBuscarPorDni.UseVisualStyleBackColor = false;
            this.btnBuscarPorDni.Click += new System.EventHandler(this.btnBuscarPorDni_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnModificar.Location = new System.Drawing.Point(150, 321);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(122, 45);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtBuscarPorDni
            // 
            this.txtBuscarPorDni.BackColor = System.Drawing.Color.DodgerBlue;
            this.txtBuscarPorDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarPorDni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscarPorDni.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarPorDni.Location = new System.Drawing.Point(547, 20);
            this.txtBuscarPorDni.MaxLength = 8;
            this.txtBuscarPorDni.Name = "txtBuscarPorDni";
            this.txtBuscarPorDni.PlaceholderText = "DNI";
            this.txtBuscarPorDni.Size = new System.Drawing.Size(144, 29);
            this.txtBuscarPorDni.TabIndex = 7;
            this.txtBuscarPorDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarPorDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarPorDni_KeyPress);
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormato.ForeColor = System.Drawing.Color.White;
            this.lblFormato.Location = new System.Drawing.Point(61, 272);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(581, 21);
            this.lblFormato.TabIndex = 8;
            this.lblFormato.Text = "Se muestran con el siguiente formato: Nombre - Apellido - DNI - Tipo - Puntos";
            // 
            // FrmCargarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(704, 378);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.txtBuscarPorDni);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscarPorDni);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.lstRegistroClientes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCargarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Cliente";
            this.Load += new System.EventHandler(this.FrmCargarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lstRegistroClientes;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscarPorDni;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtBuscarPorDni;
        private System.Windows.Forms.Label lblFormato;
    }
}