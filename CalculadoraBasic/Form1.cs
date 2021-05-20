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
            if (lblInput.Text.Equals("0") || isOperationAdded)
            {
                lblOperaci.Text = "";
            }
            isOperationAdded = false;

            Button btn = (Button)sender;
            if (btn.Text.Equals(".", StringComparison.CurrentCultureIgnoreCase))
            {
                if (lblOperaci.Text.Contains("."))
                {
                    return;
                }
            }

            lblInput.Text += btn.Text;

        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (result == 0 || isOperationAdded)
            {
                result = Double.Parse(lblInput.Text);
            }else
            {
                PerformOperation();
            }

            operacion = btn.Text;
            isOperationAdded = true;
            lblOperaci.Text = lblOperaci.Text + operacion;
          
        }


        private void PerformOperation()
        {

            switch (operacion)
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

            lblOperaci.Text = result.ToString();
            lblInput.Text = "";

        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            PerformOperation();
        }
    }

}
