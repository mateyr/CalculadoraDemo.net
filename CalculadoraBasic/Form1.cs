using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraBasic
{
    public partial class Form1 : Form
    {
        private bool isOperationAdded;
        private String operacion;
        private double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void BtnOne_Click(object sender, EventArgs e)
        {
            if (lblOperaci.Text.Equals("0") || isOperationAdded)
            {
                lblOperaci.Text = "";
            }
            Button btn = (Button)sender;
            if (btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblOperaci.Text.Contains("."))
                {
                    return;
                }
            }

            lblOperaci.Text += btn.Text;

        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            if (lblOperaci.Text.Equals("0"))
            {
                lblOperaci.Text = "";
            }
            Button btn = (Button)sender;
            if (result == 0)
            {
                result = Double.Parse(lblOperaci.Text);
                lblOperaci.Text = lblOperaci.Text + " " + btn.Text;
                operacion = btn.Text;
                isOperationAdded = true;
            }
            else
            {
                operacion = btn.Text;
                isOperationAdded = true;
                PerformOperation(operacion);
            }

        }


        private void PerformOperation(String Operation)
        {

            switch (Operation)
            {
                case "+": result += Double.Parse(lblOperaci.Text); break;
                case "-": result -= Double.Parse(lblOperaci.Text); break;
                case "*": result *= Double.Parse(lblOperaci.Text); break;
                case "÷":
                    {
                        double temp = Double.Parse(lblOperaci.Text);
                        if (result == 0 && temp == 0)
                        {
                            lblOperaci.Text = "Undefined";
                        }
                        else if (temp == 0)
                        {
                            lblOperaci.Text = "Erro";
                        }
                        else
                        {
                            result /= temp;
                        }

                        break;
                    }


            }

        }
    }

}
