using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string checkOperater;
        private string firstOperand;
        private string operate;
        private int way = 0, checkStrat = 0;
        private string memory;
        private string addOperate;


        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
        }
        private CalculatorEngine engine;
        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            checkOperater = operate;
            checkStrat++;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
            if (checkStrat == 0) firstOperand = lblDisplay.Text;
             way = 1;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            string secondOperand;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            if (operate == "%")
            {
                secondOperand = lblDisplay.Text;
                lblDisplay.Text = engine.SystemOperater(operate, firstOperand, secondOperand);
                way = 0;
            }
            if (operate == "CE")
            {
                lblDisplay.Text = " ";
                way = 0;
            }
            else
            {
       
                    if (way == 1 && checkStrat == 2)
                    {
                        if (lblDisplay.Text is "Error")
                        {
                            return;
                        }

                        secondOperand = lblDisplay.Text;
                        string result = engine.calculate(checkOperater, firstOperand, secondOperand);
                        if (result is "E" || result.Length > 8)
                        {
                            lblDisplay.Text = "Error";
                        }
                        else
                        {
                            lblDisplay.Text = result;

                        }
                        isAfterEqual = true;
                        firstOperand = result;
                        checkStrat--;
                    }
                    else
                    {
                    isAfterOperater = true;
                    
                        switch (operate)
                        {
                            
                            case "1/x":
                                secondOperand = lblDisplay.Text;
                                lblDisplay.Text = engine.SystemOperater(operate, secondOperand, " ");
                                break;
                            case "SR":
                                secondOperand = lblDisplay.Text;
                                lblDisplay.Text = engine.SystemOperater(operate, secondOperand, " ");
                                // your code here
                                break;
                        }
                    }
                    if (operate == "%"||operate == "CE")
                    {
                        way = 1;

                    }
                    isAllowBack = false;

                }

            }
            

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(checkOperater, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
                if(way == 1)
                {
                    firstOperand = result;
                    secondOperand = string.Empty;
                    way = 0;
                }
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
            firstOperand = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }
        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void bntMR_click_Click(object sender, EventArgs e)
        {
            string sumMemory;
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "MR":
                    if(memory != null)
                    {
                    lblDisplay.Text = memory;
                    isAfterEqual = true;
                    }
                    break;
                case "M-":
                    sumMemory = lblDisplay.Text;
                    memory = (Convert.ToDouble(memory) - Convert.ToDouble(sumMemory)).ToString();
                    isAfterEqual = true;
                    break;
                case "M+":
                    sumMemory = lblDisplay.Text;
                    memory = (Convert.ToDouble(memory) + Convert.ToDouble(sumMemory)).ToString();
                    isAfterEqual = true;
                    break;
                case "MS":
                    memory = lblDisplay.Text;
                    isAfterEqual = true;
                    break;
                case "MC":
                    memory = "0";
                    lblDisplay.Text = "0";
                    sumMemory = string.Empty;
                    isAfterEqual = true;
                    break;
            }
        }
    }
}
