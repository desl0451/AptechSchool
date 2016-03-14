using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AptechSchoolCommon
{
    public class ClearValue
    {
        #region--重置指定容器内控件值
        public static void ClearValueClass(Control control)
        {
            foreach (Control c in control.Controls)
            {
                //清空文本框
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                //下拉列表为空
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
                //复选框为未选中
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
                //时间控件获取当前时间
                if (c is DateTimePicker)
                {
                    ((DateTimePicker)c).Text = DateTime.Now.ToString();
                }
            }
        }
        #endregion
    }
}
