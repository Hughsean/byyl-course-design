using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BY.WinForm
{
    internal static partial class Program
    {
        /// <summary>
        /// 可视化获取文件路径
        /// </summary>
        /// <returns>
        /// 返回文件路径
        /// </returns>
        public static string GetFilePath()
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Title = "选择文件",
                Filter = "文本文件(*.txt)|*.*",
                InitialDirectory = @"D:\Data\Data\Desktop"

            };
            dialog.ShowDialog();
            if (Path.GetExtension(dialog.FileName) == ".txt" || dialog.FileName.Length == 0)
            { return dialog.FileName; }
            else
            {
                MessageBox.Show("文件类型错误，不为文本文件(.txt)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }
    }
}
