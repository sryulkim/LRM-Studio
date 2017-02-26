using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMIProject
{
    public partial class HMIMakeClickEventDialog : Form
    {
        public bool confirmFlag { get; set; }
        public HMIMakeClickEventDialog()
        {
            InitializeComponent();
            groupBoxChangeValue.Enabled = false;
            groupBoxIncreaseValue.Enabled = false;
            groupBoxDecreaseValue.Enabled = false;
            groupBoxChangeProperty.Enabled = false;
            groupBoxChangePage.Enabled = false;
        }

        private void HMIMakeClickEventDialog_Load(object sender, EventArgs e)
        {

            foreach (GVariable gvar in GViewDlg.SList)
            {
                comboBoxCVGVarName.Items.Add(gvar.name);
                comboBoxIVGVarName.Items.Add(gvar.name);
                comboBoxDVGVarName.Items.Add(gvar.name);
            }
            foreach (GVariable gvar in GViewDlg.MList)
            {
                comboBoxCVGVarName.Items.Add(gvar.name);
                comboBoxIVGVarName.Items.Add(gvar.name);
                comboBoxDVGVarName.Items.Add(gvar.name);
            }
            foreach (GVariable gvar in GViewDlg.NEList)
            {
                comboBoxCVGVarName.Items.Add(gvar.name);
                comboBoxIVGVarName.Items.Add(gvar.name);
                comboBoxDVGVarName.Items.Add(gvar.name);
            }

            foreach (HMIEditorPane pane in StaticMethods.hmIEditorPaneList)
            {
                foreach (GUIO guio in pane.GUIOList)
                {
                    comboBoxGUIOName.Items.Add(guio.name);
                }
            }
            foreach (HMIEditorPane pane in StaticMethods.hmIEditorPaneList)
            {
                comboBoxPageName.Items.Add(pane.thisPage.name);
            }
        }

            private void buttonConfirm_Click(object sender, EventArgs e)
        {
                clickEvent ce = new clickEvent();
                if (radioButtonChangeValue.Checked)
                {
                    ce.type = "ChangeValue";
                    if (comboBoxCVGVarName.SelectedItem != null)
                    {
                        ce.gName = comboBoxCVGVarName.SelectedItem.ToString();
                        if (textBoxCVValue.Text != "")
                        {
                            ce.value = textBoxCVValue.Text;
                            confirmFlag = true;
                        }
                    }
                }
                else if (radioButtonIncreaseValue.Checked)
                {
                    ce.type = "IncreaseValue";
                    if (comboBoxIVGVarName.SelectedItem != null)
                    {
                        ce.gName = comboBoxIVGVarName.SelectedItem.ToString();
                        if (textBoxIVValue.Text != "")
                        {
                            ce.value = textBoxIVValue.Text;
                            confirmFlag = true;
                        }
                    }
                }
                else if (radioButtonDecreaseValue.Checked)
                {
                    ce.type = "DecreaseValue";
                    if (comboBoxDVGVarName.SelectedItem != null)
                    {
                        ce.gName = comboBoxDVGVarName.SelectedItem.ToString();
                        if (textBoxDVValue.Text != "")
                        {
                            ce.value = textBoxDVValue.Text;
                            confirmFlag = true;
                        }
                    }
                }
                else if (radioButtonChangeProperty.Checked)
                {
                    ce.type = "ChangeProperty";
                    if (comboBoxProperty.SelectedItem != null)
                {
                    foreach (HMIEditorPane pane in StaticMethods.hmIEditorPaneList)
                    {
                        foreach (GUIO guio in pane.GUIOList)
                        {
                            if (guio.name == comboBoxGUIOName.SelectedItem.ToString())
                                ce.GUIOType = guio.type;
                        }
                    }
                    ce.gName = comboBoxGUIOName.SelectedItem.ToString();
                        ce.property = comboBoxProperty.SelectedItem.ToString();
                        if (textBoxCPValue.Text != "")
                        {
                            ce.value = textBoxCPValue.Text;
                            confirmFlag = true;
                        }
                    }
                }
                else if (radioButtonChangePage.Checked)
                {
                    ce.type = "ChangePage";
                    if (comboBoxPageName.SelectedItem != null)
                    {
                        ce.gName = comboBoxPageName.SelectedItem.ToString();
                        confirmFlag = true;
                    }
                }
                if (confirmFlag)
                {
                    HMIClickEventsDialog.button.clickEvents.Add(ce);
                    this.Close();
                }
                else
             MessageBox.Show("유효한 값을 입력해주세요");
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            confirmFlag = false;
            this.Close();
        }

        private void radioButtonChangeValue_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChangeValue.Enabled = true;
            groupBoxIncreaseValue.Enabled = false;
            groupBoxDecreaseValue.Enabled = false;
            groupBoxChangeProperty.Enabled = false;
            groupBoxChangePage.Enabled = false;
        }

        private void radioButtonIncreaseValue_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChangeValue.Enabled = false;
            groupBoxIncreaseValue.Enabled = true;
            groupBoxDecreaseValue.Enabled = false;
            groupBoxChangeProperty.Enabled = false;
            groupBoxChangePage.Enabled = false;
        }

        private void radioButtonDecreaseValue_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChangeValue.Enabled = false;
            groupBoxIncreaseValue.Enabled = false;
            groupBoxDecreaseValue.Enabled = true;
            groupBoxChangeProperty.Enabled = false;
            groupBoxChangePage.Enabled = false;
        }

        private void radioButtonChangeProperty_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChangeValue.Enabled = false;
            groupBoxIncreaseValue.Enabled = false;
            groupBoxDecreaseValue.Enabled = false;
            groupBoxChangeProperty.Enabled = true;
            groupBoxChangePage.Enabled = false;
        }

        private void radioButtonChangePage_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChangeValue.Enabled = false;
            groupBoxIncreaseValue.Enabled = false;
            groupBoxDecreaseValue.Enabled = false;
            groupBoxChangeProperty.Enabled = false;
            groupBoxChangePage.Enabled = true;
        }

        private void comboBoxGUIOName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemValue = comboBoxGUIOName.SelectedItem.ToString();
            string type = "";
            foreach (HMIEditorPane pane in StaticMethods.hmIEditorPaneList)
            {
                foreach (GUIO guio in pane.GUIOList)
                {
                    if (guio.name.Equals(itemValue))
                    {
                        type = guio.type;
                    }
                }
            }

            comboBoxProperty.Items.Clear();

            comboBoxProperty.Items.Add("Property");
            comboBoxProperty.Items.Add("x");
            comboBoxProperty.Items.Add("y");
            comboBoxProperty.Items.Add("width");
            comboBoxProperty.Items.Add("height");

            switch (type)
            {
                case "IpCamera":
                    comboBoxProperty.Items.Add("address");
                    break;
                case "Circle":
                case "Rectangle":
                    comboBoxProperty.Items.Add("fillColor");
                    comboBoxProperty.Items.Add("lineColor");
                    comboBoxProperty.Items.Add("lineThickness");

                    break;
                case "PushButton":
                    comboBoxProperty.Items.Add("text");
                    comboBoxProperty.Items.Add("buttonColor");
                    comboBoxProperty.Items.Add("thickness");
                    comboBoxProperty.Items.Add("borderColor");
                    comboBoxProperty.Items.Add("fontSize");
                    comboBoxProperty.Items.Add("fontColor");
                    comboBoxProperty.Items.Add("fontBold");
                    comboBoxProperty.Items.Add("fontUnderline");
                    break;
                case "Dial":
                    comboBoxProperty.Items.Add("max");
                    comboBoxProperty.Items.Add("min");
                    comboBoxProperty.Items.Add("major");
                    comboBoxProperty.Items.Add("minor");
                    comboBoxProperty.Items.Add("needleColor");
                    comboBoxProperty.Items.Add("dialColor");
                    comboBoxProperty.Items.Add("fontColor");

                    break;
                case "ProgressBar":
                    comboBoxProperty.Items.Add("max");
                    comboBoxProperty.Items.Add("min");
                    comboBoxProperty.Items.Add("major");
                    comboBoxProperty.Items.Add("minor");
                    comboBoxProperty.Items.Add("orientation");
                    comboBoxProperty.Items.Add("progressColor");

                    break;
                case "SliderBar":
                    comboBoxProperty.Items.Add("max");
                    comboBoxProperty.Items.Add("min");
                    comboBoxProperty.Items.Add("major");
                    comboBoxProperty.Items.Add("minor");
                    comboBoxProperty.Items.Add("orientation");
                    comboBoxProperty.Items.Add("sliderColor");
                    comboBoxProperty.Items.Add("handleColor");

                    break;
                case "NumPad":
                    comboBoxProperty.Items.Add("numColor");
                    comboBoxProperty.Items.Add("numButtonColor");
                    comboBoxProperty.Items.Add("resetColor");
                    comboBoxProperty.Items.Add("resetButtonColor");
                    comboBoxProperty.Items.Add("okColor");
                    comboBoxProperty.Items.Add("okButtonColor");
                    comboBoxProperty.Items.Add("borderColor");

                    break;
                case "LoginPad":
                    comboBoxProperty.Items.Add("password");
                    comboBoxProperty.Items.Add("numColor");
                    comboBoxProperty.Items.Add("numButtonColor");
                    comboBoxProperty.Items.Add("resetColor");
                    comboBoxProperty.Items.Add("resetButtonColor");
                    comboBoxProperty.Items.Add("loginColor");
                    comboBoxProperty.Items.Add("loginButtonColor");
                    comboBoxProperty.Items.Add("funcColor");
                    comboBoxProperty.Items.Add("funcButtonColor");
                    comboBoxProperty.Items.Add("borderColor");
                    comboBoxProperty.Items.Add("digitNumber");

                    break;
                case "Label":
                    comboBoxProperty.Items.Add("labelColor");
                    comboBoxProperty.Items.Add("text");
                    comboBoxProperty.Items.Add("borderColor");
                    comboBoxProperty.Items.Add("thickness");
                    comboBoxProperty.Items.Add("fontSize");
                    comboBoxProperty.Items.Add("fontColor");
                    comboBoxProperty.Items.Add("fontBold");
                    comboBoxProperty.Items.Add("fontUnderline");
                    break;
                case "DigitalClock":
                    comboBoxProperty.Items.Add("clockColor");
                    comboBoxProperty.Items.Add("borderColor");
                    comboBoxProperty.Items.Add("fontSize");
                    comboBoxProperty.Items.Add("fontColor");
                    comboBoxProperty.Items.Add("fontBold");

                    break;
                case "Rail":
                    comboBoxProperty.Items.Add("grayScale");
                    comboBoxProperty.Items.Add("imageName");
                    break;
                case "Image":
                    comboBoxProperty.Items.Add("grayScale");
                    comboBoxProperty.Items.Add("imageName");
                    comboBoxProperty.Items.Add("scale");
                    break;

                default:
                    break;

            }
        }
    }
}
