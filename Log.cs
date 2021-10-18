using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConnect
{
    public class Log
    {
        private string _fileName; //ファイル名（絶対パスで指定する）
        private Boolean _isAppend; //true:追記モード、false:上書きモード（Writeメソッド、WriteLineメソッドで使用する）
        private Encoding _encoding; //エンコーディング

        /// <summary>
        /// インスタンス化を行います。
        /// </summary>
        public Log()
        {

        }

        /// <summary>
        /// ファイル名、追記モード/上書きモード、エンコーディングを指定してインスタンス化を行います。
        /// </summary>
        /// <param name="fileName">ファイル名（絶対パスで指定する）</param>
        /// <param name="isAppend">true:追記モード、false:上書きモード</param>
        /// <param name="encoding">エンコーディング</param>
        public Log(string fileName, Boolean isAppend, Encoding encoding)
        {
            _fileName = fileName;
            _isAppend = isAppend;
            _encoding = encoding;
        }

        /// <summary>
        /// ファイル名を絶対パスで指定します。
        /// </summary>
        public string FileName
        {
            set { _fileName = value; }
        }

        /// <summary>
        /// 追記モード/上書きモードを指定します。true:追記モード、false:上書きモード
        /// </summary>
        public Boolean IsAppend
        {
            set { _isAppend = value; }
        }

        /// <summary>
        /// エンコーディングを指定します。
        /// </summary>
        public Encoding Encoding
        {
            set { _encoding = value; }
        }

        /// <summary>
        /// ファイルに文字列を書き込みます。
        /// </summary>
        /// <param name="format">フォーマット</param>
        /// <param name="args">フォーマットに適用する値（任意指定）</param>
        public void Write(string format, params object[] args)
        {

            System.IO.StreamWriter sw = new System.IO.StreamWriter(_fileName, _isAppend, _encoding);

            try
            {
                sw.Write(format, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
            }

        }

        /// <summary>
        /// ファイルに行単位で文字列を書き込みます。
        /// </summary>
        /// <param name="format">フォーマット</param>
        /// <param name="args">フォーマットに適用する値（任意指定）</param>
        public void WriteLine(string format, params object[] args)
        {

            System.IO.StreamWriter sw = new System.IO.StreamWriter(_fileName, _isAppend, _encoding);

            try
            {
                sw.WriteLine(format, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
            }

        }

        /// <summary>
        /// 書き込み中のファイルを起動します。
        /// </summary>
        public void FileOpen()
        {

            System.Diagnostics.Process prc = new System.Diagnostics.Process();

            prc.StartInfo.FileName = _fileName;
            prc.StartInfo.UseShellExecute = true;
            prc.Start();

        }

    }
}


